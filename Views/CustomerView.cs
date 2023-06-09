﻿using System;
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
    public partial class CustomerView : Form,ICustomerView
    {
        private bool isSuccessful;
        private bool isEdit;
        private string message;
        private IEnumerable<CustomerTypeModel> customerTypes;
        public CustomerView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControlDetail.TabPages.Remove(tabPage2);
            btnClose.Click += delegate { this.Close(); };
            CustomerId.Text = "0";
            CustomerType.DisplayMember = "Value";
            CustomerType.ValueMember = "Key";
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
            get {
                KeyValuePair<int, string> elementoSeleccionado = (KeyValuePair<int, string>)CustomerType.Items[CustomerType.SelectedIndex];
                int idSeleccionado = elementoSeleccionado.Key;
                return idSeleccionado;
            }
            set {
                foreach (KeyValuePair<int, string> item in CustomerType.Items)
                {
                    if (item.Key == value)
                    {
                        CustomerType.SelectedItem = item;
                        break;
                    }
                }
            }
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

        public IEnumerable<CustomerTypeModel> CustomerTypeList
        {
            get { return customerTypes; }
            set { customerTypes = value; }
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ViewLoad;

        public void SetCustomerListBindingSource(BindingSource customerList)
        {
            dataGridView1.DataSource = customerList;
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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void CustomerView_Load(object sender, EventArgs e)
        {
            ViewLoad?.Invoke(this, EventArgs.Empty);

            foreach (CustomerTypeModel type in customerTypes)
            {
                CustomerType.Items.Add(new KeyValuePair<int, string>(type.Id, type.Description));
            }
        }
    }
}
