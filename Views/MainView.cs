using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppMVP.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            BtnCustomerView.Click += delegate { ShowCustomerView?.Invoke(this, EventArgs.Empty); };
            BtnCustomerType.Click += delegate { ShowTypeView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowCustomerView;
        public event EventHandler ShowTypeView;

        private void MainView_Load(object sender, EventArgs e)
        {

        }
    }
}
