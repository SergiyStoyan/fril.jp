namespace Cliver.fril.jp
{
    partial class ScheduleForm
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
            this.schedules = new System.Windows.Forms.ListBox();
            this.bRemove = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // schedules
            // 
            this.schedules.FormattingEnabled = true;
            this.schedules.IntegralHeight = false;
            this.schedules.Location = new System.Drawing.Point(12, 25);
            this.schedules.Name = "schedules";
            this.schedules.Size = new System.Drawing.Size(120, 164);
            this.schedules.TabIndex = 5;
            this.schedules.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.schedules_MouseDoubleClick);
            // 
            // bRemove
            // 
            this.bRemove.Location = new System.Drawing.Point(138, 25);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(78, 23);
            this.bRemove.TabIndex = 6;
            this.bRemove.Text = "Delete";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(141, 137);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 8;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(141, 166);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 9;
            this.bOK.Text = "Choose";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Schedules:";
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 201);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.schedules);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleForm";
            this.Text = "ScheduleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox schedules;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Label label4;
    }
}