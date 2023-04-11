
namespace WindowsFormsAppMVP.Views
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnInvoice = new System.Windows.Forms.Button();
            this.BtnCustomerType = new System.Windows.Forms.Button();
            this.BtnCustomerView = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnInvoice);
            this.panel1.Controls.Add(this.BtnCustomerType);
            this.panel1.Controls.Add(this.BtnCustomerView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 576);
            this.panel1.TabIndex = 0;
            // 
            // BtnInvoice
            // 
            this.BtnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInvoice.Location = new System.Drawing.Point(3, 164);
            this.BtnInvoice.Name = "BtnInvoice";
            this.BtnInvoice.Size = new System.Drawing.Size(252, 48);
            this.BtnInvoice.TabIndex = 2;
            this.BtnInvoice.Text = "Facturas";
            this.BtnInvoice.UseVisualStyleBackColor = true;
            // 
            // BtnCustomerType
            // 
            this.BtnCustomerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCustomerType.Location = new System.Drawing.Point(3, 110);
            this.BtnCustomerType.Name = "BtnCustomerType";
            this.BtnCustomerType.Size = new System.Drawing.Size(252, 48);
            this.BtnCustomerType.TabIndex = 1;
            this.BtnCustomerType.Text = "Tipos de Clientes";
            this.BtnCustomerType.UseVisualStyleBackColor = true;
            // 
            // BtnCustomerView
            // 
            this.BtnCustomerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCustomerView.Location = new System.Drawing.Point(3, 56);
            this.BtnCustomerView.Name = "BtnCustomerView";
            this.BtnCustomerView.Size = new System.Drawing.Size(252, 48);
            this.BtnCustomerView.TabIndex = 0;
            this.BtnCustomerView.Text = "Clientes";
            this.BtnCustomerView.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 576);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "MainView";
            this.Text = "MainView";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCustomerView;
        private System.Windows.Forms.Button BtnCustomerType;
        private System.Windows.Forms.Button BtnInvoice;
    }
}