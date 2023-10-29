namespace test_DataBase
{
    partial class AddFormDormitories
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
            this.labelProdukciya = new System.Windows.Forms.Label();
            this.textBoxDormitoryName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProdukciya
            // 
            this.labelProdukciya.AutoSize = true;
            this.labelProdukciya.Location = new System.Drawing.Point(123, 363);
            this.labelProdukciya.Name = "labelProdukciya";
            this.labelProdukciya.Size = new System.Drawing.Size(121, 13);
            this.labelProdukciya.TabIndex = 16;
            this.labelProdukciya.Text = "Название общежития:";
            // 
            // textBoxDormitoryName
            // 
            this.textBoxDormitoryName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDormitoryName.Location = new System.Drawing.Point(252, 351);
            this.textBoxDormitoryName.Name = "textBoxDormitoryName";
            this.textBoxDormitoryName.Size = new System.Drawing.Size(391, 33);
            this.textBoxDormitoryName.TabIndex = 15;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(283, 661);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(202, 56);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(208, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(175, 25);
            this.labelTitle.TabIndex = 20;
            this.labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(209, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "Общежитие";
            // 
            // AddFormDormitories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 729);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelProdukciya);
            this.Controls.Add(this.textBoxDormitoryName);
            this.Controls.Add(this.buttonSave);
            this.Name = "AddFormDormitories";
            this.Text = "Добавить общежитие";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelProdukciya;
        private System.Windows.Forms.TextBox textBoxDormitoryName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
    }
}