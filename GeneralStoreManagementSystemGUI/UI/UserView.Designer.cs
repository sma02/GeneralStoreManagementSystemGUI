
using GeneralStoreManagementSystemGUI.DL;

namespace GeneralStoreManagementSystemGUI.UI
{
    partial class UserView
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
            this.panelUserData = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.customDateTimePicker1 = new GeneralStoreManagementSystemGUI.UI.CustomDateTimePicker();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.maskedTextID = new System.Windows.Forms.MaskedTextBox();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextPhone = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelUserData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUserData
            // 
            this.panelUserData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.panelUserData.Controls.Add(this.customDateTimePicker1);
            this.panelUserData.Controls.Add(this.textEmail);
            this.panelUserData.Controls.Add(this.maskedTextID);
            this.panelUserData.Controls.Add(this.textAddress);
            this.panelUserData.Controls.Add(this.label8);
            this.panelUserData.Controls.Add(this.label7);
            this.panelUserData.Controls.Add(this.maskedTextPhone);
            this.panelUserData.Controls.Add(this.label6);
            this.panelUserData.Controls.Add(this.label5);
            this.panelUserData.Controls.Add(this.label4);
            this.panelUserData.Controls.Add(this.textUsername);
            this.panelUserData.Controls.Add(this.label1);
            this.panelUserData.Controls.Add(this.buttonCancel);
            this.panelUserData.Controls.Add(this.buttonSave);
            this.panelUserData.Controls.Add(this.comboBoxRole);
            this.panelUserData.Controls.Add(this.label3);
            this.panelUserData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUserData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelUserData.Location = new System.Drawing.Point(0, 0);
            this.panelUserData.Name = "panelUserData";
            this.panelUserData.Size = new System.Drawing.Size(594, 450);
            this.panelUserData.TabIndex = 0;
            this.panelUserData.Paint += new System.Windows.Forms.PaintEventHandler(this.panelUserData_Paint);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonCancel.Location = new System.Drawing.Point(498, 402);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(84, 36);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonSave.Location = new System.Drawing.Point(38, 402);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(84, 36);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(40, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Role";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRole.BackColor = System.Drawing.Color.DimGray;
            this.comboBoxRole.DropDownWidth = 486;
            this.comboBoxRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRole.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Items.AddRange(new object[] {
            "Admin",
            "Cashier",
            "User"});
            this.comboBoxRole.Location = new System.Drawing.Point(38, 190);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(287, 28);
            this.comboBoxRole.TabIndex = 5;
            // 
            // customDateTimePicker1
            // 
            this.customDateTimePicker1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customDateTimePicker1.Enabled = false;
            this.customDateTimePicker1.Location = new System.Drawing.Point(344, 120);
            this.customDateTimePicker1.Name = "customDateTimePicker1";
            this.customDateTimePicker1.Size = new System.Drawing.Size(235, 26);
            this.customDateTimePicker1.TabIndex = 37;
            // 
            // textEmail
            // 
            this.textEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textEmail.Enabled = false;
            this.textEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEmail.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textEmail.Location = new System.Drawing.Point(38, 269);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(287, 29);
            this.textEmail.TabIndex = 36;
            // 
            // maskedTextID
            // 
            this.maskedTextID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.maskedTextID.Enabled = false;
            this.maskedTextID.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.maskedTextID.Location = new System.Drawing.Point(384, 272);
            this.maskedTextID.Mask = "AAA";
            this.maskedTextID.Name = "maskedTextID";
            this.maskedTextID.Size = new System.Drawing.Size(49, 26);
            this.maskedTextID.TabIndex = 31;
            // 
            // textAddress
            // 
            this.textAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textAddress.Enabled = false;
            this.textAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAddress.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textAddress.Location = new System.Drawing.Point(38, 346);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(541, 29);
            this.textAddress.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(464, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Phone Number";
            // 
            // maskedTextPhone
            // 
            this.maskedTextPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.maskedTextPhone.Enabled = false;
            this.maskedTextPhone.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.maskedTextPhone.Location = new System.Drawing.Point(468, 272);
            this.maskedTextPhone.Mask = "+\\92 000-0000000";
            this.maskedTextPhone.Name = "maskedTextPhone";
            this.maskedTextPhone.Size = new System.Drawing.Size(111, 26);
            this.maskedTextPhone.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(39, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(340, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Birth Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(380, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "ID";
            // 
            // textUsername
            // 
            this.textUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textUsername.Enabled = false;
            this.textUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textUsername.Location = new System.Drawing.Point(38, 120);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(287, 29);
            this.textUsername.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(39, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Username";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(39, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Address";
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 450);
            this.Controls.Add(this.panelUserData);
            this.Name = "UserView";
            this.Text = "UserView";
            this.Resize += new System.EventHandler(this.UserView_Resize);
            this.panelUserData.ResumeLayout(false);
            this.panelUserData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUserData;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private SearchViewControl searchView;
        private UserList list;
        private CustomDateTimePicker customDateTimePicker1;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.MaskedTextBox maskedTextID;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label label3;
    }
}