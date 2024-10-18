namespace CARGOBRIDGE
{
    partial class CompaniesForm
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
            this.DataGridCompaniesList = new System.Windows.Forms.DataGridView();
            this.companyNameTxt = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.listBtn = new System.Windows.Forms.Button();
            this.ss = new System.Windows.Forms.Label();
            this.cargosbacktoviewBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridCompaniesList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridCompaniesList
            // 
            this.DataGridCompaniesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridCompaniesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridCompaniesList.Location = new System.Drawing.Point(12, 12);
            this.DataGridCompaniesList.Name = "DataGridCompaniesList";
            this.DataGridCompaniesList.Size = new System.Drawing.Size(551, 289);
            this.DataGridCompaniesList.TabIndex = 0;
            this.DataGridCompaniesList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridCompaniesList_CellDoubleClick);
            // 
            // companyNameTxt
            // 
            this.companyNameTxt.Location = new System.Drawing.Point(22, 417);
            this.companyNameTxt.Name = "companyNameTxt";
            this.companyNameTxt.Size = new System.Drawing.Size(284, 20);
            this.companyNameTxt.TabIndex = 1;
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.Lime;
            this.addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addBtn.Location = new System.Drawing.Point(22, 501);
            this.addBtn.Name = "addBtn";
            this.addBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addBtn.Size = new System.Drawing.Size(136, 40);
            this.addBtn.TabIndex = 9;
            this.addBtn.Text = "EKLE";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Red;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteBtn.Location = new System.Drawing.Point(187, 501);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(136, 40);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "SİL";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.Cyan;
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.updateBtn.Location = new System.Drawing.Point(344, 501);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(136, 40);
            this.updateBtn.TabIndex = 11;
            this.updateBtn.Text = "GÜNCELLE";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // listBtn
            // 
            this.listBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.listBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBtn.Location = new System.Drawing.Point(506, 501);
            this.listBtn.Name = "listBtn";
            this.listBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBtn.Size = new System.Drawing.Size(136, 40);
            this.listBtn.TabIndex = 12;
            this.listBtn.Text = "LİSTELE";
            this.listBtn.UseVisualStyleBackColor = false;
            this.listBtn.Click += new System.EventHandler(this.listBtn_Click);
            // 
            // ss
            // 
            this.ss.AutoSize = true;
            this.ss.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ss.Location = new System.Drawing.Point(19, 399);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(59, 15);
            this.ss.TabIndex = 13;
            this.ss.Text = "Firma Adı";
            // 
            // cargosbacktoviewBtn
            // 
            this.cargosbacktoviewBtn.BackColor = System.Drawing.Color.Yellow;
            this.cargosbacktoviewBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cargosbacktoviewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cargosbacktoviewBtn.Location = new System.Drawing.Point(22, 595);
            this.cargosbacktoviewBtn.Name = "cargosbacktoviewBtn";
            this.cargosbacktoviewBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cargosbacktoviewBtn.Size = new System.Drawing.Size(136, 40);
            this.cargosbacktoviewBtn.TabIndex = 20;
            this.cargosbacktoviewBtn.Text = "KARGOLAR";
            this.cargosbacktoviewBtn.UseVisualStyleBackColor = false;
            this.cargosbacktoviewBtn.Click += new System.EventHandler(this.cargosbacktoviewBtn_Click);
            // 
            // CompaniesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 817);
            this.Controls.Add(this.cargosbacktoviewBtn);
            this.Controls.Add(this.ss);
            this.Controls.Add(this.listBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.companyNameTxt);
            this.Controls.Add(this.DataGridCompaniesList);
            this.Name = "CompaniesForm";
            this.Text = "CompaniesForm";
            this.Load += new System.EventHandler(this.CompaniesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridCompaniesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridCompaniesList;
        private System.Windows.Forms.TextBox companyNameTxt;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button listBtn;
        private System.Windows.Forms.Label ss;
        private System.Windows.Forms.Button cargosbacktoviewBtn;
    }
}