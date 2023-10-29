namespace test_DataBase
{
    partial class AddFormStudents
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
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelPostavshik = new System.Windows.Forms.Label();
            this.labelQuantinity = new System.Windows.Forms.Label();
            this.labelProdukciya = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.textBoxGroupID = new System.Windows.Forms.TextBox();
            this.textBoxFacultyID = new System.Windows.Forms.TextBox();
            this.textBoxPassportNumber = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(207, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 38;
            this.label1.Text = "Студент";
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
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(150, 481);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(94, 13);
            this.labelPrice.TabIndex = 36;
            this.labelPrice.Text = "Номер паспорта:";
            // 
            // labelPostavshik
            // 
            this.labelPostavshik.AutoSize = true;
            this.labelPostavshik.Location = new System.Drawing.Point(138, 442);
            this.labelPostavshik.Name = "labelPostavshik";
            this.labelPostavshik.Size = new System.Drawing.Size(106, 13);
            this.labelPostavshik.TabIndex = 35;
            this.labelPostavshik.Text = "Номер факультета:";
            // 
            // labelQuantinity
            // 
            this.labelQuantinity.AutoSize = true;
            this.labelQuantinity.Location = new System.Drawing.Point(161, 403);
            this.labelQuantinity.Name = "labelQuantinity";
            this.labelQuantinity.Size = new System.Drawing.Size(83, 13);
            this.labelQuantinity.TabIndex = 34;
            this.labelQuantinity.Text = "Номер группы:";
            // 
            // labelProdukciya
            // 
            this.labelProdukciya.AutoSize = true;
            this.labelProdukciya.Location = new System.Drawing.Point(173, 364);
            this.labelProdukciya.Name = "labelProdukciya";
            this.labelProdukciya.Size = new System.Drawing.Size(71, 13);
            this.labelProdukciya.TabIndex = 33;
            this.labelProdukciya.Text = "Полное имя:";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFullName.Location = new System.Drawing.Point(250, 352);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(391, 33);
            this.textBoxFullName.TabIndex = 32;
            // 
            // textBoxGroupID
            // 
            this.textBoxGroupID.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxGroupID.Location = new System.Drawing.Point(250, 391);
            this.textBoxGroupID.Name = "textBoxGroupID";
            this.textBoxGroupID.Size = new System.Drawing.Size(391, 33);
            this.textBoxGroupID.TabIndex = 31;
            // 
            // textBoxFacultyID
            // 
            this.textBoxFacultyID.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFacultyID.Location = new System.Drawing.Point(250, 430);
            this.textBoxFacultyID.Name = "textBoxFacultyID";
            this.textBoxFacultyID.Size = new System.Drawing.Size(391, 33);
            this.textBoxFacultyID.TabIndex = 30;
            // 
            // textBoxPassportNumber
            // 
            this.textBoxPassportNumber.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassportNumber.Location = new System.Drawing.Point(250, 469);
            this.textBoxPassportNumber.Name = "textBoxPassportNumber";
            this.textBoxPassportNumber.Size = new System.Drawing.Size(391, 33);
            this.textBoxPassportNumber.TabIndex = 29;
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
            // AddFormStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 729);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelPostavshik);
            this.Controls.Add(this.labelQuantinity);
            this.Controls.Add(this.labelProdukciya);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.textBoxGroupID);
            this.Controls.Add(this.textBoxFacultyID);
            this.Controls.Add(this.textBoxPassportNumber);
            this.Controls.Add(this.buttonSave);
            this.Name = "AddFormStudents";
            this.Text = "Добавить студента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelPostavshik;
        private System.Windows.Forms.Label labelQuantinity;
        private System.Windows.Forms.Label labelProdukciya;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.TextBox textBoxGroupID;
        private System.Windows.Forms.TextBox textBoxFacultyID;
        private System.Windows.Forms.TextBox textBoxPassportNumber;
        private System.Windows.Forms.Button buttonSave;
    }
}