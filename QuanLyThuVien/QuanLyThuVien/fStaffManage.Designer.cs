namespace QuanLyThuVien
{
    partial class fStaffManage
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
            this.RbtnNu = new System.Windows.Forms.RadioButton();
            this.RbtnNam = new System.Windows.Forms.RadioButton();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtStaffID = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblStaffSex = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblStaffID = new System.Windows.Forms.Label();
            this.lblStaffUpdate = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.RbtnNu);
            this.panel1.Controls.Add(this.RbtnNam);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.txtStaffName);
            this.panel1.Controls.Add(this.txtStaffID);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lblPhone);
            this.panel1.Controls.Add(this.lblStaffSex);
            this.panel1.Controls.Add(this.lblBirthDate);
            this.panel1.Controls.Add(this.lblStaffName);
            this.panel1.Controls.Add(this.lblStaffID);
            this.panel1.Controls.Add(this.lblStaffUpdate);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 426);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(144, 177);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(247, 22);
            this.dateTimePicker1.TabIndex = 39;
            // 
            // RbtnNu
            // 
            this.RbtnNu.AutoSize = true;
            this.RbtnNu.Location = new System.Drawing.Point(245, 227);
            this.RbtnNu.Name = "RbtnNu";
            this.RbtnNu.Size = new System.Drawing.Size(45, 20);
            this.RbtnNu.TabIndex = 38;
            this.RbtnNu.TabStop = true;
            this.RbtnNu.Text = "Nữ";
            this.RbtnNu.UseVisualStyleBackColor = true;
            // 
            // RbtnNam
            // 
            this.RbtnNam.AutoSize = true;
            this.RbtnNam.Location = new System.Drawing.Point(144, 227);
            this.RbtnNam.Name = "RbtnNam";
            this.RbtnNam.Size = new System.Drawing.Size(57, 20);
            this.RbtnNam.TabIndex = 37;
            this.RbtnNam.TabStop = true;
            this.RbtnNam.Text = "Nam";
            this.RbtnNam.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(144, 272);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(247, 22);
            this.txtPhone.TabIndex = 36;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(144, 124);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(247, 22);
            this.txtStaffName.TabIndex = 34;
            // 
            // txtStaffID
            // 
            this.txtStaffID.Location = new System.Drawing.Point(144, 78);
            this.txtStaffID.Name = "txtStaffID";
            this.txtStaffID.Size = new System.Drawing.Size(247, 22);
            this.txtStaffID.TabIndex = 33;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(236, 332);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 50);
            this.btnEdit.TabIndex = 32;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(126, 332);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 50);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 332);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 50);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(19, 278);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(85, 16);
            this.lblPhone.TabIndex = 29;
            this.lblPhone.Text = "Số điện thoại";
            // 
            // lblStaffSex
            // 
            this.lblStaffSex.AutoSize = true;
            this.lblStaffSex.Location = new System.Drawing.Point(19, 227);
            this.lblStaffSex.Name = "lblStaffSex";
            this.lblStaffSex.Size = new System.Drawing.Size(54, 16);
            this.lblStaffSex.TabIndex = 28;
            this.lblStaffSex.Text = "Giới tính";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(19, 177);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(67, 16);
            this.lblBirthDate.TabIndex = 27;
            this.lblBirthDate.Text = "Ngày sinh";
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Location = new System.Drawing.Point(19, 130);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(91, 16);
            this.lblStaffName.TabIndex = 26;
            this.lblStaffName.Text = "Tên nhân viên";
            // 
            // lblStaffID
            // 
            this.lblStaffID.AutoSize = true;
            this.lblStaffID.Location = new System.Drawing.Point(19, 84);
            this.lblStaffID.Name = "lblStaffID";
            this.lblStaffID.Size = new System.Drawing.Size(86, 16);
            this.lblStaffID.TabIndex = 25;
            this.lblStaffID.Text = "Mã nhân viên";
            // 
            // lblStaffUpdate
            // 
            this.lblStaffUpdate.AutoSize = true;
            this.lblStaffUpdate.BackColor = System.Drawing.Color.Khaki;
            this.lblStaffUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffUpdate.Location = new System.Drawing.Point(42, 23);
            this.lblStaffUpdate.Name = "lblStaffUpdate";
            this.lblStaffUpdate.Size = new System.Drawing.Size(289, 25);
            this.lblStaffUpdate.TabIndex = 24;
            this.lblStaffUpdate.Text = "Cập nhật thông tin nhân viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.lblNhanVien);
            this.panel2.Location = new System.Drawing.Point(425, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(639, 426);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(617, 338);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick_1);
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.BackColor = System.Drawing.Color.Khaki;
            this.lblNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVien.Location = new System.Drawing.Point(277, 23);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(109, 25);
            this.lblNhanVien.TabIndex = 25;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // fStaffManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fStaffManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân viên";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStaffUpdate;
        private System.Windows.Forms.Label lblStaffID;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblStaffSex;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton RbtnNu;
        private System.Windows.Forms.RadioButton RbtnNam;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.TextBox txtStaffID;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}