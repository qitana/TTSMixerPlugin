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
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog(string message, string title)
        {
            InitializeComponent();
            labelMessage.Text = message;
            Text = title;
            buttonNo.Focus();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
