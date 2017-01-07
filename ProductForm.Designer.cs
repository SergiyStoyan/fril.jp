namespace Cliver.fril.jp
{
    partial class ProductForm
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
            this.time = new System.Windows.Forms.DateTimePicker();
            this.bAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.prices = new System.Windows.Forms.ListBox();
            this.bRemove = new System.Windows.Forms.Button();
            this.days = new System.Windows.Forms.ListBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            this.ScheduleName = new System.Windows.Forms.TextBox();
            this.SaveSchedule = new System.Windows.Forms.Button();
            this.Choose = new System.Windows.Forms.Button();
            this.addMinutes = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.subtractMinutes = new System.Windows.Forms.Button();
            this.subtractSeconds = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.addSeconds = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // time
            // 
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time.Location = new System.Drawing.Point(254, 55);
            this.time.Name = "time";
            this.time.ShowUpDown = true;
            this.time.Size = new System.Drawing.Size(75, 20);
            this.time.TabIndex = 0;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(335, 89);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(30, 23);
            this.bAdd.TabIndex = 1;
            this.bAdd.Text = ">>";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time:";
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(254, 99);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(75, 20);
            this.price.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Price:";
            // 
            // prices
            // 
            this.prices.FormattingEnabled = true;
            this.prices.IntegralHeight = false;
            this.prices.Location = new System.Drawing.Point(370, 33);
            this.prices.Name = "prices";
            this.prices.Size = new System.Drawing.Size(120, 101);
            this.prices.TabIndex = 5;
            // 
            // bRemove
            // 
            this.bRemove.Location = new System.Drawing.Point(335, 60);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(30, 23);
            this.bRemove.TabIndex = 6;
            this.bRemove.Text = "<<";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // days
            // 
            this.days.FormattingEnabled = true;
            this.days.IntegralHeight = false;
            this.days.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.days.Location = new System.Drawing.Point(167, 33);
            this.days.Name = "days";
            this.days.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.days.Size = new System.Drawing.Size(77, 101);
            this.days.TabIndex = 7;
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(416, 195);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 8;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(335, 195);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 9;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Days:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Prices && Times:";
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(12, 12);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(136, 122);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 12;
            this.image.TabStop = false;
            // 
            // ScheduleName
            // 
            this.ScheduleName.Location = new System.Drawing.Point(150, 143);
            this.ScheduleName.Name = "ScheduleName";
            this.ScheduleName.Size = new System.Drawing.Size(75, 20);
            this.ScheduleName.TabIndex = 14;
            // 
            // SaveSchedule
            // 
            this.SaveSchedule.Location = new System.Drawing.Point(82, 140);
            this.SaveSchedule.Name = "SaveSchedule";
            this.SaveSchedule.Size = new System.Drawing.Size(62, 23);
            this.SaveSchedule.TabIndex = 13;
            this.SaveSchedule.Text = "Save As:";
            this.SaveSchedule.UseVisualStyleBackColor = true;
            this.SaveSchedule.Click += new System.EventHandler(this.SaveSchedule_Click);
            // 
            // Choose
            // 
            this.Choose.Location = new System.Drawing.Point(12, 140);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(64, 23);
            this.Choose.TabIndex = 15;
            this.Choose.Text = "Choose";
            this.Choose.UseVisualStyleBackColor = true;
            this.Choose.Click += new System.EventHandler(this.Choose_Click);
            // 
            // addMinutes
            // 
            this.addMinutes.Location = new System.Drawing.Point(373, 162);
            this.addMinutes.Name = "addMinutes";
            this.addMinutes.Size = new System.Drawing.Size(24, 23);
            this.addMinutes.TabIndex = 17;
            this.addMinutes.Text = "+";
            this.addMinutes.UseVisualStyleBackColor = true;
            this.addMinutes.Click += new System.EventHandler(this.addMinutes_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Minutes:";
            // 
            // subtractMinutes
            // 
            this.subtractMinutes.Location = new System.Drawing.Point(403, 162);
            this.subtractMinutes.Name = "subtractMinutes";
            this.subtractMinutes.Size = new System.Drawing.Size(24, 23);
            this.subtractMinutes.TabIndex = 19;
            this.subtractMinutes.Text = "-";
            this.subtractMinutes.UseVisualStyleBackColor = true;
            this.subtractMinutes.Click += new System.EventHandler(this.subtractMinutes_Click);
            // 
            // subtractSeconds
            // 
            this.subtractSeconds.Location = new System.Drawing.Point(466, 162);
            this.subtractSeconds.Name = "subtractSeconds";
            this.subtractSeconds.Size = new System.Drawing.Size(24, 23);
            this.subtractSeconds.TabIndex = 22;
            this.subtractSeconds.Text = "-";
            this.subtractSeconds.UseVisualStyleBackColor = true;
            this.subtractSeconds.Click += new System.EventHandler(this.subtractSeconds_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(433, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Seconds:";
            // 
            // addSeconds
            // 
            this.addSeconds.Location = new System.Drawing.Point(436, 162);
            this.addSeconds.Name = "addSeconds";
            this.addSeconds.Size = new System.Drawing.Size(24, 23);
            this.addSeconds.TabIndex = 20;
            this.addSeconds.Text = "+";
            this.addSeconds.UseVisualStyleBackColor = true;
            this.addSeconds.Click += new System.EventHandler(this.addSeconds_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 230);
            this.Controls.Add(this.subtractSeconds);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addSeconds);
            this.Controls.Add(this.subtractMinutes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addMinutes);
            this.Controls.Add(this.Choose);
            this.Controls.Add(this.ScheduleName);
            this.Controls.Add(this.SaveSchedule);
            this.Controls.Add(this.image);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.days);
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.prices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.time);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker time;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox prices;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.ListBox days;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.TextBox ScheduleName;
        private System.Windows.Forms.Button SaveSchedule;
        private System.Windows.Forms.Button Choose;
        private System.Windows.Forms.Button addMinutes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button subtractMinutes;
        private System.Windows.Forms.Button subtractSeconds;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addSeconds;
    }
}