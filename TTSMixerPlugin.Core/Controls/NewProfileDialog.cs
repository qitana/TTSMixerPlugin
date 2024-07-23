using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qitana.TTSMixerPlugin
{
    public partial class NewProfileDialog : Form
    {
        public IProfile SelectedProfile { get; private set; }

        private readonly TinyIoCContainer _container;
        private Registry _registry;


        public NewProfileDialog(TinyIoCContainer container)
        {
            InitializeComponent();

            _container = container;
            _registry = container.Resolve<Registry>();

            foreach (var profileType in _registry.Profiles)
            {
                comboBoxType.Items.Add(new KeyValuePair<string, Type>(profileType.Name, profileType));
            }
            comboBoxType.DisplayMember = "Key";
            textBox1.Focus();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var type = ((KeyValuePair<string, Type>)comboBoxType.SelectedItem).Value;

            SelectedProfile = (IProfile)_container.Resolve(type, new NamedParameterOverloads
            {
                {"container", _container },
                { "name", name }
            });

            DialogResult = DialogResult.OK;
        }
    }
}
