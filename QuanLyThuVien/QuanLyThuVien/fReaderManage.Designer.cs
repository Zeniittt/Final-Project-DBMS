namespace QuanLyThuVien
{
    partial class fReaderManage
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtReaderPhone = new System.Windows.Forms.TextBox();
            this.txtReaderAddress = new System.Windows.Forms.TextBox();
            this.lblReaderPhone = new System.Windows.Forms.Label();
            this.lblReaderAddress = new System.Windows.Forms.Label();
            this.lblReaderBirthDate = new System.Windows.Forms.Label();
            this.RbtnNu = new System.Windows.Forms.RadioButton();
            this.RbtnNam = new System.Windows.Forms.RadioButton();
            this.lblReaderSex = new System.Windows.Forms.Label();
            this.txtReaderName = new System.Windows.Forms.TextBox();
            this.lblReaderName = new System.Windows.Forms.Label();
            this.txtReaderID = new System.Windows.Forms.TextBox();
            this.lblReaderID = new System.Windows.Forms.Label();
            this.lblReaderUpdate = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbReaderList = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtReaderPhone);
            this.panel1.Controls.Add(this.txtReaderAddress);
            this.panel1.Controls.Add(this.lblReaderPhone);
            this.panel1.Controls.Add(this.lblReaderAddress);
            this.panel1.Controls.Add(this.lblReaderBirthDate);
            this.panel1.Controls.Add(this.RbtnNu);
            this.panel1.Controls.Add(this.RbtnNam);
            this.panel1.Controls.Add(this.lblReaderSex);
            this.panel1.Controls.Add(this.txtReaderName);
            this.panel1.Controls.Add(this.lblReaderName);
            this.panel1.Controls.Add(this.txtReaderID);
            this.panel1.Controls.Add(this.lblReaderID);
            this.panel1.Controls.Add(this.lblReaderUpdate);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 565);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(136, 285);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(225, 22);
            this.dateTimePicker1.TabIndex = 50;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(229, 486);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 50);
            this.btnEdit.TabIndex = 49;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(118, 486);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 50);
            this.btnDelete.TabIndex = 48;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 486);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 50);
            this.btnAdd.TabIndex = 47;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtReaderPhone
            // 
            this.txtReaderPhone.Location = new System.Drawing.Point(136, 393);
            this.txtReaderPhone.Name = "txtReaderPhone";
            this.txtReaderPhone.Size = new System.Drawing.Size(226, 22);
            this.txtReaderPhone.TabIndex = 46;
            // 
            // txtReaderAddress
            // 
            this.txtReaderAddress.Location = new System.Drawing.Point(135, 338);
            this.txtReaderAddress.Name = "txtReaderAddress";
            this.txtReaderAddress.Size = new System.Drawing.Size(226, 22);
            this.txtReaderAddress.TabIndex = 44;
            // 
            // lblReaderPhone
            // 
            this.lblReaderPhone.AutoSize = true;
            this.lblReaderPhone.Location = new System.Drawing.Point(18, 399);
            this.lblReaderPhone.Name = "lblReaderPhone";
            this.lblReaderPhone.Size = new System.Drawing.Size(85, 16);
            this.lblReaderPhone.TabIndex = 43;
            this.lblReaderPhone.Text = "Số điện thoại";
            // 
            // lblReaderAddress
            // 
            this.lblReaderAddress.AutoSize = true;
            this.lblReaderAddress.Location = new System.Drawing.Point(18, 344);
            this.lblReaderAddress.Name = "lblReaderAddress";
            this.lblReaderAddress.Size = new System.Drawing.Size(47, 16);
            this.lblReaderAddress.TabIndex = 41;
            this.lblReaderAddress.Text = "Địa chỉ";
            // 
            // lblReaderBirthDate
            // 
            this.lblReaderBirthDate.AutoSize = true;
            this.lblReaderBirthDate.Location = new System.Drawing.Point(18, 285);
            this.lblReaderBirthDate.Name = "lblReaderBirthDate";
            this.lblReaderBirthDate.Size = new System.Drawing.Size(67, 16);
            this.lblReaderBirthDate.TabIndex = 40;
            this.lblReaderBirthDate.Text = "Ngày sinh";
            // 
            // RbtnNu
            // 
            this.RbtnNu.AutoSize = true;
            this.RbtnNu.Location = new System.Drawing.Point(229, 215);
            this.RbtnNu.Name = "RbtnNu";
            this.RbtnNu.Size = new System.Drawing.Size(45, 20);
            this.RbtnNu.TabIndex = 39;
            this.RbtnNu.TabStop = true;
            this.RbtnNu.Text = "Nữ";
            this.RbtnNu.UseVisualStyleBackColor = true;
            // 
            // RbtnNam
            // 
            this.RbtnNam.AutoSize = true;
            this.RbtnNam.Location = new System.Drawing.Point(136, 215);
            this.RbtnNam.Name = "RbtnNam";
            this.RbtnNam.Size = new System.Drawing.Size(57, 20);
            this.RbtnNam.TabIndex = 38;
            this.RbtnNam.TabStop = true;
            this.RbtnNam.Text = "Nam";
            this.RbtnNam.UseVisualStyleBackColor = true;
            // 
            // lblReaderSex
            // 
            this.lblReaderSex.AutoSize = true;
            this.lblReaderSex.Location = new System.Drawing.Point(18, 219);
            this.lblReaderSex.Name = "lblReaderSex";
            this.lblReaderSex.Size = new System.Drawing.Size(54, 16);
            this.lblReaderSex.TabIndex = 35;
            this.lblReaderSex.Text = "Giới tính";
            // 
            // txtReaderName
            // 
            this.txtReaderName.Location = new System.Drawing.Point(135, 148);
            this.txtReaderName.Name = "txtReaderName";
            this.txtReaderName.Size = new System.Drawing.Size(226, 22);
            this.txtReaderName.TabIndex = 32;
            // 
            // lblReaderName
            // 
            this.lblReaderName.AutoSize = true;
            this.lblReaderName.Location = new System.Drawing.Point(18, 154);
            this.lblReaderName.Name = "lblReaderName";
            this.lblReaderName.Size = new System.Drawing.Size(79, 16);
            this.lblReaderName.TabIndex = 31;
            this.lblReaderName.Text = "Tên độc giả";
            // 
            // txtReaderID
            // 
            this.txtReaderID.Location = new System.Drawing.Point(135, 96);
            this.txtReaderID.Name = "txtReaderID";
            this.txtReaderID.Size = new System.Drawing.Size(226, 22);
            this.txtReaderID.TabIndex = 30;
            // 
            // lblReaderID
            // 
            this.lblReaderID.AutoSize = true;
            this.lblReaderID.Location = new System.Drawing.Point(18, 102);
            this.lblReaderID.Name = "lblReaderID";
            this.lblReaderID.Size = new System.Drawing.Size(74, 16);
            this.lblReaderID.TabIndex = 29;
            this.lblReaderID.Text = "Mã độc giả";
            // 
            // lblReaderUpdate
            // 
            this.lblReaderUpdate.AutoSize = true;
            this.lblReaderUpdate.BackColor = System.Drawing.Color.IndianRed;
            this.lblReaderUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReaderUpdate.Location = new System.Drawing.Point(84, 36);
            this.lblReaderUpdate.Name = "lblReaderUpdate";
            this.lblReaderUpdate.Size = new System.Drawing.Size(265, 25);
            this.lblReaderUpdate.TabIndex = 25;
            this.lblReaderUpdate.Text = "Cập nhật thông tin độc giả";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.lbReaderList);
            this.panel2.Location = new System.Drawing.Point(468, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(887, 565);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(864, 478);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lbReaderList
            // 
            this.lbReaderList.AutoSize = true;
            this.lbReaderList.BackColor = System.Drawing.Color.IndianRed;
            this.lbReaderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReaderList.Location = new System.Drawing.Point(368, 36);
            this.lbReaderList.Name = "lbReaderList";
            this.lbReaderList.Size = new System.Drawing.Size(191, 25);
            this.lbReaderList.TabIndex = 50;
            this.lbReaderList.Text = "Danh sách độc giả";
            // 
            // fReaderManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 575);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fReaderManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý độc giả";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReaderUpdate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtReaderName;
        private System.Windows.Forms.Label lblReaderName;
        private System.Windows.Forms.TextBox txtReaderID;
        private System.Windows.Forms.Label lblReaderID;
        private System.Windows.Forms.Label lblReaderSex;
        private System.Windows.Forms.RadioButton RbtnNam;
        private System.Windows.Forms.TextBox txtReaderPhone;
        private System.Windows.Forms.TextBox txtReaderAddress;
        private System.Windows.Forms.Label lblReaderPhone;
        private System.Windows.Forms.Label lblReaderAddress;
        private System.Windows.Forms.Label lblReaderBirthDate;
        private System.Windows.Forms.RadioButton RbtnNu;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lbReaderList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}