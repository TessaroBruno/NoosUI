
namespace NoosUIDemo
{
    partial class Dialog
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
   this.noosDialogPanel1 = new Noos.UI.Components.NoosDialogPanel();
   this.noosComplementaryButton1 = new Noos.UI.Components.NoosComplementaryButton();
   this.noosDialogPanel1.SuspendLayout();
   this.SuspendLayout();
   // 
   // noosDialogPanel1
   // 
   this.noosDialogPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
   this.noosDialogPanel1.Controls.Add(this.noosComplementaryButton1);
   this.noosDialogPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
   this.noosDialogPanel1.Location = new System.Drawing.Point(8, 8);
   this.noosDialogPanel1.Name = "noosDialogPanel1";
   this.noosDialogPanel1.Padding = new System.Windows.Forms.Padding(8);
   this.noosDialogPanel1.Size = new System.Drawing.Size(784, 434);
   this.noosDialogPanel1.TabIndex = 0;
   // 
   // noosComplementaryButton1
   // 
   this.noosComplementaryButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
   this.noosComplementaryButton1.Cursor = System.Windows.Forms.Cursors.Hand;
   this.noosComplementaryButton1.FlatAppearance.BorderSize = 0;
   this.noosComplementaryButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
   this.noosComplementaryButton1.Font = new System.Drawing.Font("HP Simplified", 12F);
   this.noosComplementaryButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
   this.noosComplementaryButton1.Location = new System.Drawing.Point(568, 16);
   this.noosComplementaryButton1.Margin = new System.Windows.Forms.Padding(8);
   this.noosComplementaryButton1.Name = "noosComplementaryButton1";
   this.noosComplementaryButton1.Size = new System.Drawing.Size(200, 52);
   this.noosComplementaryButton1.TabIndex = 1;
   this.noosComplementaryButton1.Text = "Close";
   this.noosComplementaryButton1.UseVisualStyleBackColor = false;
   this.noosComplementaryButton1.Click += new System.EventHandler(this.noosComplementaryButton1_Click);
   // 
   // Dialog
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(800, 450);
   this.Controls.Add(this.noosDialogPanel1);
   this.Name = "Dialog";
   this.Text = "Dialog";
   this.noosDialogPanel1.ResumeLayout(false);
   this.ResumeLayout(false);

        }

        #endregion

        private Noos.UI.Components.NoosDialogPanel noosDialogPanel1;
        private Noos.UI.Components.NoosComplementaryButton noosComplementaryButton1;
    }
}