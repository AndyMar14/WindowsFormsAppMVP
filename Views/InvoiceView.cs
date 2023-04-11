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
    public partial class InvoiceView : Form , IInvoiceView
    {
        private string message;
        public InvoiceView()
        {
            InitializeComponent();
            tabControl1.TabPages.Remove(tabPage2);

            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            BtnInvoice.Click += delegate
            {
                ViewInvoice?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
            };

            BtnBack.Click += delegate
            {
                ViewInvoice?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
            };
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private static InvoiceView instance;
        public event EventHandler SearchEvent;
        public event EventHandler ViewInvoice;

        public string Id {
            get { return LbId.Text; }
            set { LbId.Text = value; }
        }
        public string CustName {
            get { return LbName.Text; }
            set { LbName.Text = value; }
        }
        public string Adress {
            get { return LbAdress.Text; }
            set { LbAdress.Text = value; }
        }
        public string CustomerType {
            get { return LbType.Text; }
            set { LbType.Text = value; }
        }
        public string Status {
            get { return LbStatus.Text; }
            set { LbStatus.Text = value; }
        }
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Total
        {
            get { return LbTotal.Text; }
            set { LbTotal.Text = value; }
        }
        public string Itbis
        {
            get { return LbItbis.Text; }
            set { LbItbis.Text = value; }
        }
        public string SubTotal
        {
            get { return LbSubTotal.Text; }
            set { LbSubTotal.Text = value; }
        }

        public static InvoiceView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new InvoiceView();
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

        public void SetInvoiceListBindingSource(BindingSource invoiceList)
        {
            DgvInvoice.DataSource = invoiceList;
        }
        public void SetInvoiceDetailListBindingSource(BindingSource invoiceDetailList)
        {
            DgvInvoiceDetail.DataSource = invoiceDetailList;
        }
    }
}
