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
    public partial class CustomerView : Form,ICustomerView
    {
        private bool isSuccessful;
        private bool isEdit;
        private string message;

        public CustomerView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControlDetail.TabPages.Remove(tabPage2);
            btnClose.Click += delegate { this.Close(); };
        }
        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Others
        }

        public string Id {
            get { return CustomerId.Text; }
            set { CustomerId.Text = value; }
        }
        public string CustName {
            get { return CustomerName.Text; }
            set { CustomerName.Text = value; }
        }
        public string Adress {
            get { return CustomerAdress.Text; }
            set { CustomerAdress.Text = value; }
        }
        public int CustomerTypeId {
            get { return CustomerType.SelectedIndex; }
            set { CustomerType.SelectedIndex = value; }
        }
        public int Status {
            get { return CustomerStatus.SelectedIndex; }
            set { CustomerStatus.SelectedIndex = value; }
        }
        public string SearchValue {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public bool IsEdit {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public bool IsSuccessful {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }
        public string Message {
            get { return message; }
            set { message = value; }
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetCustomerListBindingSource(BindingSource petList)
        {
            dataGridView1.DataSource = petList;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        //Singleton pattern (Open a single form instance)
        private static CustomerView instance;
        public static CustomerView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CustomerView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
    }
}
