using NAudio.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.Resources;

namespace Qitana.TTSMixerPlugin
{
    public partial class ControlPanel : UserControl
    {

        private readonly TinyIoCContainer _container;
        private readonly ILogger _logger;

        PluginMain _pluginMain;
        IPluginConfig _config;
        GeneralConfigTabControl generalConfigTabControl;
        TabPage _generalConfigTabPage;

        bool logAreaResized = false;
        bool logConnected = false;

        public ControlPanel(TinyIoCContainer container)
        {
            InitializeComponent();

            this._container = container;
            _logger = container.Resolve<ILogger>();
            _logger.RegisterListener(AddLogEntry);
            _pluginMain = container.Resolve<PluginMain>();
            _config = container.Resolve<IPluginConfig>();

            generalConfigTabControl = new GeneralConfigTabControl(container);
            _generalConfigTabPage = new ConfigTabPage
            {
                Name = "General",
                Text = "",
            };
            _generalConfigTabPage.Controls.Add(generalConfigTabControl);

            Resize += (o, e) =>
            {
                if (!logAreaResized && Height > 500 && tabControl.TabCount > 0)
                {
                    ResizeLogArea();
                }
            };

        }

        public void ResizeLogArea()
        {
            if (!logAreaResized)
            {
                logAreaResized = Height > 500;
                splitContainer1.SplitterDistance = (int)Math.Round(Height * 0.75);
            }
        }

        public void InitializeTabs()
        {
            tabControl.TabPages.Clear();
            tabControl.TabPages.Add(_generalConfigTabPage);
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged; 
            foreach (var profile in _pluginMain.Profiles)
            {
                AddProfileTab(profile);
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == _generalConfigTabPage)
            {
                generalConfigTabControl.RefreshDefaultProfileComboBox();
            }
        }

        private void AddProfileTab(IProfile profile)
        {
            var tabPage = new ConfigTabPage
            {
                Name = profile.Name,
                Text = profile.TypeFriendlyName,
                IsProfile = true,
            };

            var configControl = profile.CreateConfigControl();
            if (configControl != null)
            {
                configControl.Dock = DockStyle.Fill;
                configControl.BackColor = SystemColors.ControlLightLight;
                var control = new ProfileConfigTabControl(_container, profile, configControl);
                control.Dock = DockStyle.Fill;
                tabPage.Controls.Add(control);

                this.tabControl.TabPages.Add(tabPage);
            }
        }

        private void AddLogEntry(LogEntry entry)
        {
            Action appendText = () =>
            {
                var msg = $"[{entry.Time}] {entry.Level}: {entry.Message}" + Environment.NewLine;

                if (!logConnected)
                {
                    // Remove the error message about the log not being connected since it is now.
                    logConnected = true;
                    logBox.Text = "";
                }
                else if (logBox.TextLength > 200 * 1024)
                {
                    logBox.Text = "============ LOG TRUNCATED ==============\nThe log was truncated to reduce memory usage.\n=========================================\n" + msg;
                    return;
                }

                if (checkBoxFollowLog.Checked)
                {
                    logBox.AppendText(msg);
                }
                else
                {
                    // This is based on https://stackoverflow.com/q/1743448
                    bool bottomFlag = false;
                    int sbOffset;
                    int savedVpos;

                    // Win32 magic to keep the textbox scrolling to the newest append to the textbox unless
                    // the user has moved the scrollbox up
                    sbOffset = (int)((logBox.ClientSize.Height - SystemInformation.HorizontalScrollBarHeight) / (logBox.Font.Height));
                    savedVpos = NativeMethods.GetScrollPos(logBox.Handle, NativeMethods.SB_VERT);
                    NativeMethods.GetScrollRange(logBox.Handle, NativeMethods.SB_VERT, out _, out int VSmax);

                    if (savedVpos >= (VSmax - sbOffset - 1))
                        bottomFlag = true;

                    logBox.AppendText(msg);

                    if (bottomFlag)
                    {
                        NativeMethods.GetScrollRange(logBox.Handle, NativeMethods.SB_VERT, out _, out VSmax);
                        savedVpos = VSmax - sbOffset;
                    }
                    NativeMethods.SetScrollPos(logBox.Handle, NativeMethods.SB_VERT, savedVpos, true);
                    NativeMethods.PostMessageA(logBox.Handle, NativeMethods.WM_VSCROLL, NativeMethods.SB_THUMBPOSITION + 0x10000 * savedVpos, 0);
                }
            };

            // Invoke in UI thread if needed to avoid WinForms issues.
            // See https://github.com/OverlayPlugin/OverlayPlugin/issues/254
            if (ActGlobals.oFormActMain.InvokeRequired)
            {
                ActGlobals.oFormActMain.Invoke(appendText);
            }
            else
            {
                appendText();
            }
        }

        private class ConfigTabPage : TabPage
        {
            public bool IsProfile = false;
        }

        private void buttonNewProfile_Click(object sender, EventArgs e)
        {
            var newProfileDialog = new NewProfileDialog(_container);
            if (newProfileDialog.ShowDialog(this.ParentForm) == DialogResult.OK)
            {

                // check duplicate profile name
                _pluginMain.Config.Profiles.ForEach(p =>
                {
                    if (p.Name == newProfileDialog.SelectedProfile.Config.Name)
                    {
                        MessageBox.Show($"Profile name '{newProfileDialog.SelectedProfile.Config.Name}' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                });

                var profile = newProfileDialog.SelectedProfile;
                _pluginMain.Config.Profiles.Add(profile.Config);
                _pluginMain.Config.MarkDirty();
                _pluginMain.Profiles.Add(profile);
                AddProfileTab(profile);
            }
        }

        private void buttonRemoveProfile_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == null)
            {
                return;
            }

            if (!(tabControl.SelectedTab is ConfigTabPage tabPage && tabPage.IsProfile))
            {
                return;
            }

            string selectedProfileName = tabPage.Name;
            int selectedIndex = tabControl.TabPages.IndexOf(tabPage);

            var ConfirmMessagResult = new ConfirmDialog($"Are you sure you want to remove profile '{selectedProfileName}'?", "Delete profile").ShowDialog(this.ParentForm);
            if (ConfirmMessagResult == DialogResult.Yes)
            {
                // remove config
                var profile = _pluginMain.Profiles.FirstOrDefault(p => p.Name == selectedProfileName);
                _logger.Log(LogLevel.Info, $"Removing profile '{selectedProfileName}'...");
                if (profile != null)
                {
                    try
                    {
                        _pluginMain.Config.Profiles.Remove(profile.Config);
                        _pluginMain.Config.MarkDirty();
                        _pluginMain.Profiles.Remove(profile);
                        tabControl.TabPages.RemoveAt(selectedIndex);
                        _logger.Log(LogLevel.Info, $"Profile '{selectedProfileName}' removed.");
                    }
                    catch
                    {
                        _logger.Log(LogLevel.Error, $"Failed to remove profile '{selectedProfileName}'.");
                        MessageBox.Show($"Failed to remove profile '{selectedProfileName}'. There may be a conflict, so please restart the app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonRenameProfile_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == null)
            {
                _logger.Log(LogLevel.Debug, "No tab selected.");
                return;
            }

            if (!(tabControl.SelectedTab is ConfigTabPage tabPage && tabPage.IsProfile))
            {
                _logger.Log(LogLevel.Debug, "this tab is not a profile tab.");
                return;
            }

            string selectedProfileName = tabPage.Name;
            int selectedIndex = tabControl.TabPages.IndexOf(tabPage);
            var renameProfileDialog = new RenameProfileDialog(selectedProfileName);
            if (renameProfileDialog.ShowDialog(this.ParentForm) == DialogResult.OK)
            {
                _logger.Log(LogLevel.Debug, $"Renaming profile '{selectedProfileName}' to '{renameProfileDialog.ProfileName}'...");

                foreach (var item in _pluginMain.Profiles)
                {
                    _logger.Log(LogLevel.Debug, $"Current Profile: {item.Name}");
                }

                // check duplicate profile name
                _pluginMain.Config.Profiles.ForEach(p =>
                {
                    if (p.Name == renameProfileDialog.ProfileName)
                    {
                        MessageBox.Show($"Profile name '{renameProfileDialog.ProfileName}' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                });

                var profile = _pluginMain.Profiles.FirstOrDefault(p => p.Name == selectedProfileName);
                _logger.Log(LogLevel.Debug, $"Profile Config found: {profile}");

                if (profile != null)
                {
                    // update profile
                    profile.Name = renameProfileDialog.ProfileName;

                    // update config
                    profile.Config.Name = renameProfileDialog.ProfileName;
                    _pluginMain.Config.MarkDirty();
                    
                    // if defaultProfile is the renamed profile, update it
                    if (_pluginMain.Config.DefaultProfile == selectedProfileName)
                    {
                        _pluginMain.Config.DefaultProfile = renameProfileDialog.ProfileName;
                    }
                    
                    // update tab name
                    _logger.Log(LogLevel.Debug, $"Tab Name changing from {tabPage.Name} to {renameProfileDialog.ProfileName}");
                    ActGlobals.oFormActMain.Invoke((Action)(() =>
                    {
                        // Prevent flickering
                        tabControl.SuspendLayout();
                        tabPage.Name = renameProfileDialog.ProfileName;
                        // update tab text requires to change the selected index
                        tabControl.SelectedIndex = 0;
                        tabControl.SelectedIndex = selectedIndex;
                        tabControl.ResumeLayout();
                    }));


                    foreach (var item in _pluginMain.Profiles)
                    {
                        _logger.Log(LogLevel.Debug, $"New Profile: {item.Name}");
                    }
                }
            }
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            logBox.Clear();
        }

        private void checkBoxFollowLog_CheckedChanged(object sender, EventArgs e)
        {
            _config.FollowLatestLog = checkBoxFollowLog.Checked;
            _config.MarkDirty();
        }
    }
}
