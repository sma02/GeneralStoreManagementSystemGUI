
using GeneralStoreManagementSystemGUI.DL;

namespace GeneralStoreManagementSystemGUI.UI
{
    partial class ProductView
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
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelNetProfit = new System.Windows.Forms.Label();
            this.panelProductData = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.numericProfitPercentage = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelNetPrice = new System.Windows.Forms.Label();
            this.maskedID = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textQuantity = new System.Windows.Forms.TextBox();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.numericDiscountPercentage = new System.Windows.Forms.NumericUpDown();
            this.numericTaxPercentage = new System.Windows.Forms.NumericUpDown();
            this.textRate = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelProductData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericProfitPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscountPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTaxPercentage)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(8, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tax  %";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(100, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Rate";
            // 
            // labelNetProfit
            // 
            this.labelNetProfit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelNetProfit.BackColor = System.Drawing.Color.DimGray;
            this.labelNetProfit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNetProfit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelNetProfit.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelNetProfit.Location = new System.Drawing.Point(416, 334);
            this.labelNetProfit.Name = "labelNetProfit";
            this.labelNetProfit.Size = new System.Drawing.Size(150, 20);
            this.labelNetProfit.TabIndex = 23;
            this.labelNetProfit.Text = "0";
            this.labelNetProfit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelProductData
            // 
            this.panelProductData.Controls.Add(this.label10);
            this.panelProductData.Controls.Add(this.numericProfitPercentage);
            this.panelProductData.Controls.Add(this.buttonCancel);
            this.panelProductData.Controls.Add(this.buttonSave);
            this.panelProductData.Controls.Add(this.label8);
            this.panelProductData.Controls.Add(this.labelNetProfit);
            this.panelProductData.Controls.Add(this.label9);
            this.panelProductData.Controls.Add(this.labelNetPrice);
            this.panelProductData.Controls.Add(this.maskedID);
            this.panelProductData.Controls.Add(this.label2);
            this.panelProductData.Controls.Add(this.textQuantity);
            this.panelProductData.Controls.Add(this.textPrice);
            this.panelProductData.Controls.Add(this.numericDiscountPercentage);
            this.panelProductData.Controls.Add(this.numericTaxPercentage);
            this.panelProductData.Controls.Add(this.textRate);
            this.panelProductData.Controls.Add(this.label7);
            this.panelProductData.Controls.Add(this.textName);
            this.panelProductData.Controls.Add(this.label1);
            this.panelProductData.Controls.Add(this.label6);
            this.panelProductData.Controls.Add(this.label5);
            this.panelProductData.Controls.Add(this.label4);
            this.panelProductData.Controls.Add(this.label3);
            this.panelProductData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductData.Location = new System.Drawing.Point(0, 0);
            this.panelProductData.Name = "panelProductData";
            this.panelProductData.Size = new System.Drawing.Size(584, 411);
            this.panelProductData.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Gainsboro;
            this.label10.Location = new System.Drawing.Point(8, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Profit %";
            // 
            // numericProfitPercentage
            // 
            this.numericProfitPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericProfitPercentage.BackColor = System.Drawing.Color.DimGray;
            this.numericProfitPercentage.DecimalPlaces = 2;
            this.numericProfitPercentage.ForeColor = System.Drawing.Color.Gainsboro;
            this.numericProfitPercentage.Location = new System.Drawing.Point(12, 264);
            this.numericProfitPercentage.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericProfitPercentage.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericProfitPercentage.Name = "numericProfitPercentage";
            this.numericProfitPercentage.Size = new System.Drawing.Size(77, 26);
            this.numericProfitPercentage.TabIndex = 12;
            this.numericProfitPercentage.ValueChanged += new System.EventHandler(this.PercentageFields_ValueChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCancel.Location = new System.Drawing.Point(386, 373);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(186, 32);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSave.Location = new System.Drawing.Point(12, 373);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(186, 32);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(413, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Net Profit %";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(12, 303);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Net Price";
            // 
            // labelNetPrice
            // 
            this.labelNetPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNetPrice.BackColor = System.Drawing.Color.DimGray;
            this.labelNetPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNetPrice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelNetPrice.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelNetPrice.Location = new System.Drawing.Point(10, 334);
            this.labelNetPrice.Name = "labelNetPrice";
            this.labelNetPrice.Size = new System.Drawing.Size(150, 20);
            this.labelNetPrice.TabIndex = 21;
            this.labelNetPrice.Text = "0";
            this.labelNetPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maskedID
            // 
            this.maskedID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maskedID.BackColor = System.Drawing.Color.DimGray;
            this.maskedID.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.maskedID.Location = new System.Drawing.Point(12, 39);
            this.maskedID.Mask = "00000";
            this.maskedID.Name = "maskedID";
            this.maskedID.Size = new System.Drawing.Size(58, 26);
            this.maskedID.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Item ID";
            // 
            // textQuantity
            // 
            this.textQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textQuantity.BackColor = System.Drawing.Color.DimGray;
            this.textQuantity.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textQuantity.Location = new System.Drawing.Point(104, 264);
            this.textQuantity.Name = "textQuantity";
            this.textQuantity.Size = new System.Drawing.Size(468, 26);
            this.textQuantity.TabIndex = 13;
            this.textQuantity.Text = "0";
            // 
            // textPrice
            // 
            this.textPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textPrice.BackColor = System.Drawing.Color.DimGray;
            this.textPrice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textPrice.Location = new System.Drawing.Point(104, 193);
            this.textPrice.Name = "textPrice";
            this.textPrice.Size = new System.Drawing.Size(462, 26);
            this.textPrice.TabIndex = 11;
            this.textPrice.Text = "0.00";
            // 
            // numericDiscountPercentage
            // 
            this.numericDiscountPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericDiscountPercentage.BackColor = System.Drawing.Color.DimGray;
            this.numericDiscountPercentage.DecimalPlaces = 2;
            this.numericDiscountPercentage.ForeColor = System.Drawing.Color.Gainsboro;
            this.numericDiscountPercentage.Location = new System.Drawing.Point(12, 194);
            this.numericDiscountPercentage.Name = "numericDiscountPercentage";
            this.numericDiscountPercentage.Size = new System.Drawing.Size(77, 26);
            this.numericDiscountPercentage.TabIndex = 10;
            this.numericDiscountPercentage.ValueChanged += new System.EventHandler(this.PercentageFields_ValueChanged);
            // 
            // numericTaxPercentage
            // 
            this.numericTaxPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericTaxPercentage.BackColor = System.Drawing.Color.DimGray;
            this.numericTaxPercentage.DecimalPlaces = 2;
            this.numericTaxPercentage.ForeColor = System.Drawing.Color.Gainsboro;
            this.numericTaxPercentage.Location = new System.Drawing.Point(12, 116);
            this.numericTaxPercentage.Name = "numericTaxPercentage";
            this.numericTaxPercentage.Size = new System.Drawing.Size(77, 26);
            this.numericTaxPercentage.TabIndex = 8;
            // 
            // textRate
            // 
            this.textRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textRate.BackColor = System.Drawing.Color.DimGray;
            this.textRate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textRate.Location = new System.Drawing.Point(104, 115);
            this.textRate.Name = "textRate";
            this.textRate.Size = new System.Drawing.Size(462, 26);
            this.textRate.TabIndex = 9;
            this.textRate.Text = "0.00";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.BackColor = System.Drawing.Color.DimGray;
            this.textName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textName.Location = new System.Drawing.Point(83, 39);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(489, 26);
            this.textName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(79, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Name";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(100, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Quantity";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(100, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Price";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(8, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Discount  %";
            // 
            // ProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.panelProductData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProductView";
            this.Text = "ProductView";
            this.panelProductData.ResumeLayout(false);
            this.panelProductData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericProfitPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscountPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTaxPercentage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private SearchViewControl searchView;
        private ProductList list;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelNetProfit;
        private System.Windows.Forms.Panel panelProductData;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelNetPrice;
        private System.Windows.Forms.MaskedTextBox maskedID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textQuantity;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.NumericUpDown numericDiscountPercentage;
        private System.Windows.Forms.NumericUpDown numericTaxPercentage;
        private System.Windows.Forms.TextBox textRate;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericProfitPercentage;
    }
}