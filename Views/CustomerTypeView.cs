using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppMVP.Models;

namespace WindowsFormsAppMVP.Views
{
    public partial class CustomerTypeView : Form,ICustomerTypeView
    {
        private bool isSuccessful;
        private bool isEdit;
        private string message;
        public CustomerTypeView()
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

            BtnAdd.Click += delegate {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControlDetail.TabPages.Remove(tabPage1);
                tabControlDetail.TabPages.Add(tabPage2);
            };
            BtnEdit.Click += delegate {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControlDetail.TabPages.Remove(tabPage1);
                tabControlDetail.TabPages.Add(tabPage2);
            };
            BtnDelete.Click += delegate {
                var result = MessageBox.Show("Are you sure you want to delete the selected customer?", "Warning",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
            BtnCancel.Click += delegate {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControlDetail.TabPages.Remove(tabPage2);
                tabControlDetail.TabPages.Add(tabPage1);
            };
            //Save changes
            BtnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControlDetail.TabPages.Remove(tabPage2);
                    tabControlDetail.TabPages.Add(tabPage1);
                }
                MessageBox.Show(Message);
            };

        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ViewLoad;

        public string Id
        {
            get { return CustomerTypeId.Text; }
            set { CustomerTypeId.Text = value; }
        }
        public string Description {
            get { return CustomerTypeDescription.Text; }
            set { CustomerTypeDescription.Text = value; }
        }
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        //Singleton pattern (Open a single form instance)
        private static CustomerTypeView instance;
        public static CustomerTypeView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CustomerTypeView();
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
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        public void SetCustomerListBindingSource(BindingSource customerList)
        {
            dataGridView1.DataSource = customerList;
        }
    }
}
