using System;
using System.Windows.Forms;

namespace Ttu.Library
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogOnForm logOnForm = new LogOnForm();
            logOnForm.ShowDialog(this);
        }
    }
}
