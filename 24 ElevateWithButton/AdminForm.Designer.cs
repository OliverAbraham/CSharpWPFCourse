namespace ElevateWithButton
{
    partial class AdminForm
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
            this.buttonGetElevation = new System.Windows.Forms.Button();
            this.buttonNoElevation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGetElevation
            // 
            this.buttonGetElevation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGetElevation.Location = new System.Drawing.Point(133, 152);
            this.buttonGetElevation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGetElevation.Name = "buttonGetElevation";
            this.buttonGetElevation.Size = new System.Drawing.Size(394, 82);
            this.buttonGetElevation.TabIndex = 0;
            this.buttonGetElevation.Text = "Request elevated rights from the operating system";
            this.buttonGetElevation.UseVisualStyleBackColor = true;
            this.buttonGetElevation.Click += new System.EventHandler(this.buttonGetElevation_Click);
            // 
            // buttonNoElevation
            // 
            this.buttonNoElevation.Location = new System.Drawing.Point(133, 54);
            this.buttonNoElevation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonNoElevation.Name = "buttonNoElevation";
            this.buttonNoElevation.Size = new System.Drawing.Size(394, 51);
            this.buttonNoElevation.TabIndex = 1;
            this.buttonNoElevation.Text = "Try todo a task that requires Admin rights";
            this.buttonNoElevation.UseVisualStyleBackColor = true;
            this.buttonNoElevation.Click += new System.EventHandler(this.buttonNoElevation_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 315);
            this.Controls.Add(this.buttonNoElevation);
            this.Controls.Add(this.buttonGetElevation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminForm";
            this.Text = "Admin Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGetElevation;
        private System.Windows.Forms.Button buttonNoElevation;
    }
}

