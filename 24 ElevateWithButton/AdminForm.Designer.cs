namespace hackman3vilGuy.CodeProject.VistaSecurity.ElevateWithButton
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
            this.buttonGetElevation.Location = new System.Drawing.Point(12, 12);
            this.buttonGetElevation.Name = "buttonGetElevation";
            this.buttonGetElevation.Size = new System.Drawing.Size(155, 53);
            this.buttonGetElevation.TabIndex = 0;
            this.buttonGetElevation.Text = "Do Admin Task";
            this.buttonGetElevation.UseVisualStyleBackColor = true;
            this.buttonGetElevation.Click += new System.EventHandler(this.buttonGetElevation_Click);
            // 
            // buttonNoElevation
            // 
            this.buttonNoElevation.Location = new System.Drawing.Point(13, 72);
            this.buttonNoElevation.Name = "buttonNoElevation";
            this.buttonNoElevation.Size = new System.Drawing.Size(154, 33);
            this.buttonNoElevation.TabIndex = 1;
            this.buttonNoElevation.Text = "Try Admin Task";
            this.buttonNoElevation.UseVisualStyleBackColor = true;
            this.buttonNoElevation.Click += new System.EventHandler(this.buttonNoElevation_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 116);
            this.Controls.Add(this.buttonNoElevation);
            this.Controls.Add(this.buttonGetElevation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdminForm";
            this.Text = "Admin Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGetElevation;
        private System.Windows.Forms.Button buttonNoElevation;
    }
}

