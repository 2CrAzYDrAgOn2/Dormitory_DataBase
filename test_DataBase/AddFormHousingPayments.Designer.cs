namespace test_DataBase
{
    partial class AddFormHousingPayments
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPostavshik = new System.Windows.Forms.Label();
            this.labelQuantinity = new System.Windows.Forms.Label();
            this.labelProdukciya = new System.Windows.Forms.Label();
            this.textBoxPaymentDate = new System.Windows.Forms.TextBox();
            this.textBoxPaidAmount = new System.Windows.Forms.TextBox();
            this.textBoxStudentID = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(207, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 21);
            this.label1.TabIndex = 38;
            this.label1.Text = "Оплата проживания";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(206, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(175, 25);
            this.labelTitle.TabIndex = 37;
            this.labelTitle.Text = "Создание записи:";
            // 
            // labelPostavshik
            // 
            this.labelPostavshik.AutoSize = true;
            this.labelPostavshik.Location = new System.Drawing.Point(152, 442);
            this.labelPostavshik.Name = "labelPostavshik";
            this.labelPostavshik.Size = new System.Drawing.Size(92, 13);
            this.labelPostavshik.TabIndex = 35;
            this.labelPostavshik.Text = "Номер студента:";
            // 
            // labelQuantinity
            // 
            this.labelQuantinity.AutoSize = true;
            this.labelQuantinity.Location = new System.Drawing.Point(153, 403);
            this.labelQuantinity.Name = "labelQuantinity";
            this.labelQuantinity.Size = new System.Drawing.Size(91, 13);
            this.labelQuantinity.TabIndex = 34;
            this.labelQuantinity.Text = "Сумма к оплате:";
            // 
            // labelProdukciya
            // 
            this.labelProdukciya.AutoSize = true;
            this.labelProdukciya.Location = new System.Drawing.Point(168, 364);
            this.labelProdukciya.Name = "labelProdukciya";
            this.labelProdukciya.Size = new System.Drawing.Size(76, 13);
            this.labelProdukciya.TabIndex = 33;
            this.labelProdukciya.Text = "Дата оплаты:";
            // 
            // textBoxPaymentDate
            // 
            this.textBoxPaymentDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPaymentDate.Location = new System.Drawing.Point(250, 352);
            this.textBoxPaymentDate.Name = "textBoxPaymentDate";
            this.textBoxPaymentDate.Size = new System.Drawing.Size(391, 33);
            this.textBoxPaymentDate.TabIndex = 32;
            // 
            // textBoxPaidAmount
            // 
            this.textBoxPaidAmount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPaidAmount.Location = new System.Drawing.Point(250, 391);
            this.textBoxPaidAmount.Name = "textBoxPaidAmount";
            this.textBoxPaidAmount.Size = new System.Drawing.Size(391, 33);
            this.textBoxPaidAmount.TabIndex = 31;
            // 
            // textBoxStudentID
            // 
            this.textBoxStudentID.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxStudentID.Location = new System.Drawing.Point(250, 430);
            this.textBoxStudentID.Name = "textBoxStudentID";
            this.textBoxStudentID.Size = new System.Drawing.Size(391, 33);
            this.textBoxStudentID.TabIndex = 30;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(281, 662);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(202, 56);
            this.buttonSave.TabIndex = 28;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // AddFormHousingPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 729);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelPostavshik);
            this.Controls.Add(this.labelQuantinity);
            this.Controls.Add(this.labelProdukciya);
            this.Controls.Add(this.textBoxPaymentDate);
            this.Controls.Add(this.textBoxPaidAmount);
            this.Controls.Add(this.textBoxStudentID);
            this.Controls.Add(this.buttonSave);
            this.Name = "AddFormHousingPayments";
            this.Text = "Добавить оплату проживания";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPostavshik;
        private System.Windows.Forms.Label labelQuantinity;
        private System.Windows.Forms.Label labelProdukciya;
        private System.Windows.Forms.TextBox textBoxPaymentDate;
        private System.Windows.Forms.TextBox textBoxPaidAmount;
        private System.Windows.Forms.TextBox textBoxStudentID;
        private System.Windows.Forms.Button buttonSave;
    }
}