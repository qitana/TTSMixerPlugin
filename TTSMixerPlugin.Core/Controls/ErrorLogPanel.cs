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
    public partial class ErrorLogPanel : UserControl
    {
        public ErrorLogPanel(TinyIoCContainer container)
        {
            InitializeComponent();

            container.Resolve<ILogger>().RegisterListener((entry) =>
            {

                errorLogBox.AppendText($"[{entry.Time}] {entry.Level}: {entry.Message}" + Environment.NewLine);
            });
        }
    }
}
