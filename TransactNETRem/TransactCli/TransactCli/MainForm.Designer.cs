namespace TransactCli
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuGBox = new System.Windows.Forms.GroupBox();
            this.ReqCashBtn = new System.Windows.Forms.Button();
            this.CancelChBtn = new System.Windows.Forms.Button();
            this.SaveChBtn = new System.Windows.Forms.Button();
            this.ObjGBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipnInput = new System.Windows.Forms.TextBox();
            this.AgeInput = new System.Windows.Forms.TextBox();
            this.CityInput = new System.Windows.Forms.TextBox();
            this.zipInput = new System.Windows.Forms.TextBox();
            this.SalaryInput = new System.Windows.Forms.TextBox();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.ModifyBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.CurrObjGBox = new System.Windows.Forms.GroupBox();
            this.ObjectList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExportLogBtn = new System.Windows.Forms.Button();
            this.AppConsoleTV = new System.Windows.Forms.RichTextBox();
            this.SaveLogDia = new System.Windows.Forms.SaveFileDialog();
            this.MenuGBox.SuspendLayout();
            this.ObjGBox.SuspendLayout();
            this.CurrObjGBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuGBox
            // 
            this.MenuGBox.Controls.Add(this.ReqCashBtn);
            this.MenuGBox.Controls.Add(this.CancelChBtn);
            this.MenuGBox.Controls.Add(this.SaveChBtn);
            this.MenuGBox.Location = new System.Drawing.Point(12, 12);
            this.MenuGBox.Name = "MenuGBox";
            this.MenuGBox.Size = new System.Drawing.Size(611, 56);
            this.MenuGBox.TabIndex = 0;
            this.MenuGBox.TabStop = false;
            this.MenuGBox.Text = "Menu";
            // 
            // ReqCashBtn
            // 
            this.ReqCashBtn.Location = new System.Drawing.Point(210, 20);
            this.ReqCashBtn.Name = "ReqCashBtn";
            this.ReqCashBtn.Size = new System.Drawing.Size(92, 23);
            this.ReqCashBtn.TabIndex = 2;
            this.ReqCashBtn.Text = "Request cashe";
            this.ReqCashBtn.UseVisualStyleBackColor = true;
            this.ReqCashBtn.Click += new System.EventHandler(this.ReqCashBtn_Click);
            // 
            // CancelChBtn
            // 
            this.CancelChBtn.Location = new System.Drawing.Point(101, 20);
            this.CancelChBtn.Name = "CancelChBtn";
            this.CancelChBtn.Size = new System.Drawing.Size(103, 23);
            this.CancelChBtn.TabIndex = 1;
            this.CancelChBtn.Text = "Discard changes";
            this.CancelChBtn.UseVisualStyleBackColor = true;
            this.CancelChBtn.Click += new System.EventHandler(this.CancelChBtn_Click);
            // 
            // SaveChBtn
            // 
            this.SaveChBtn.Location = new System.Drawing.Point(7, 20);
            this.SaveChBtn.Name = "SaveChBtn";
            this.SaveChBtn.Size = new System.Drawing.Size(88, 23);
            this.SaveChBtn.TabIndex = 0;
            this.SaveChBtn.Text = "Save changes";
            this.SaveChBtn.UseVisualStyleBackColor = true;
            this.SaveChBtn.Click += new System.EventHandler(this.SaveChBtn_Click);
            // 
            // ObjGBox
            // 
            this.ObjGBox.Controls.Add(this.label6);
            this.ObjGBox.Controls.Add(this.label5);
            this.ObjGBox.Controls.Add(this.label4);
            this.ObjGBox.Controls.Add(this.label3);
            this.ObjGBox.Controls.Add(this.label2);
            this.ObjGBox.Controls.Add(this.ipnInput);
            this.ObjGBox.Controls.Add(this.AgeInput);
            this.ObjGBox.Controls.Add(this.CityInput);
            this.ObjGBox.Controls.Add(this.zipInput);
            this.ObjGBox.Controls.Add(this.SalaryInput);
            this.ObjGBox.Controls.Add(this.NameInput);
            this.ObjGBox.Controls.Add(this.label1);
            this.ObjGBox.Controls.Add(this.RemoveBtn);
            this.ObjGBox.Controls.Add(this.ModifyBtn);
            this.ObjGBox.Controls.Add(this.AddBtn);
            this.ObjGBox.Location = new System.Drawing.Point(12, 91);
            this.ObjGBox.Name = "ObjGBox";
            this.ObjGBox.Size = new System.Drawing.Size(423, 103);
            this.ObjGBox.TabIndex = 2;
            this.ObjGBox.TabStop = false;
            this.ObjGBox.Text = "Object actions ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "IndPlantNum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "City";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "ZIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Salary";
            // 
            // ipnInput
            // 
            this.ipnInput.Location = new System.Drawing.Point(251, 76);
            this.ipnInput.Name = "ipnInput";
            this.ipnInput.Size = new System.Drawing.Size(91, 20);
            this.ipnInput.TabIndex = 9;
            // 
            // AgeInput
            // 
            this.AgeInput.Location = new System.Drawing.Point(251, 36);
            this.AgeInput.Name = "AgeInput";
            this.AgeInput.Size = new System.Drawing.Size(91, 20);
            this.AgeInput.TabIndex = 8;
            // 
            // CityInput
            // 
            this.CityInput.Location = new System.Drawing.Point(133, 76);
            this.CityInput.Name = "CityInput";
            this.CityInput.Size = new System.Drawing.Size(100, 20);
            this.CityInput.TabIndex = 7;
            // 
            // zipInput
            // 
            this.zipInput.Location = new System.Drawing.Point(133, 35);
            this.zipInput.Name = "zipInput";
            this.zipInput.Size = new System.Drawing.Size(100, 20);
            this.zipInput.TabIndex = 6;
            // 
            // SalaryInput
            // 
            this.SalaryInput.Location = new System.Drawing.Point(7, 76);
            this.SalaryInput.Name = "SalaryInput";
            this.SalaryInput.Size = new System.Drawing.Size(100, 20);
            this.SalaryInput.TabIndex = 5;
            // 
            // NameInput
            // 
            this.NameInput.Location = new System.Drawing.Point(7, 36);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(100, 20);
            this.NameInput.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Location = new System.Drawing.Point(348, 74);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.RemoveBtn.TabIndex = 2;
            this.RemoveBtn.Text = "Remove";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // ModifyBtn
            // 
            this.ModifyBtn.Location = new System.Drawing.Point(348, 48);
            this.ModifyBtn.Name = "ModifyBtn";
            this.ModifyBtn.Size = new System.Drawing.Size(75, 23);
            this.ModifyBtn.TabIndex = 1;
            this.ModifyBtn.Text = "Modify";
            this.ModifyBtn.UseVisualStyleBackColor = true;
            this.ModifyBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(348, 19);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // CurrObjGBox
            // 
            this.CurrObjGBox.Controls.Add(this.ObjectList);
            this.CurrObjGBox.Location = new System.Drawing.Point(441, 91);
            this.CurrObjGBox.Name = "CurrObjGBox";
            this.CurrObjGBox.Size = new System.Drawing.Size(182, 113);
            this.CurrObjGBox.TabIndex = 3;
            this.CurrObjGBox.TabStop = false;
            this.CurrObjGBox.Text = "Current objects";
            // 
            // ObjectList
            // 
            this.ObjectList.FormattingEnabled = true;
            this.ObjectList.Location = new System.Drawing.Point(6, 19);
            this.ObjectList.Name = "ObjectList";
            this.ObjectList.Size = new System.Drawing.Size(170, 82);
            this.ObjectList.TabIndex = 0;
            this.ObjectList.SelectedIndexChanged += new System.EventHandler(this.ObjectList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExportLogBtn);
            this.groupBox1.Controls.Add(this.AppConsoleTV);
            this.groupBox1.Location = new System.Drawing.Point(12, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 122);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // ExportLogBtn
            // 
            this.ExportLogBtn.Location = new System.Drawing.Point(34, 0);
            this.ExportLogBtn.Name = "ExportLogBtn";
            this.ExportLogBtn.Size = new System.Drawing.Size(75, 23);
            this.ExportLogBtn.TabIndex = 3;
            this.ExportLogBtn.Text = "Export log";
            this.ExportLogBtn.UseVisualStyleBackColor = true;
            this.ExportLogBtn.Click += new System.EventHandler(this.ExportLogBtn_Click);
            // 
            // AppConsoleTV
            // 
            this.AppConsoleTV.Location = new System.Drawing.Point(7, 29);
            this.AppConsoleTV.Name = "AppConsoleTV";
            this.AppConsoleTV.Size = new System.Drawing.Size(598, 84);
            this.AppConsoleTV.TabIndex = 2;
            this.AppConsoleTV.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 344);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CurrObjGBox);
            this.Controls.Add(this.ObjGBox);
            this.Controls.Add(this.MenuGBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Remoting client";
            this.MenuGBox.ResumeLayout(false);
            this.ObjGBox.ResumeLayout(false);
            this.ObjGBox.PerformLayout();
            this.CurrObjGBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MenuGBox;
        private System.Windows.Forms.GroupBox ObjGBox;
        private System.Windows.Forms.Button CancelChBtn;
        private System.Windows.Forms.Button SaveChBtn;
        private System.Windows.Forms.Button ReqCashBtn;
        private System.Windows.Forms.GroupBox CurrObjGBox;
        private System.Windows.Forms.ListBox ObjectList;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.Button ModifyBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox AppConsoleTV;
        private System.Windows.Forms.SaveFileDialog SaveLogDia;
        private System.Windows.Forms.Button ExportLogBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipnInput;
        private System.Windows.Forms.TextBox AgeInput;
        private System.Windows.Forms.TextBox CityInput;
        private System.Windows.Forms.TextBox zipInput;
        private System.Windows.Forms.TextBox SalaryInput;
        private System.Windows.Forms.TextBox NameInput;
        private System.Windows.Forms.Label label1;
    }
}

