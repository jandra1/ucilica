﻿
namespace Ucilica
{
    partial class Pitanje
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.odgovor1 = new System.Windows.Forms.Button();
            this.odgovor2 = new System.Windows.Forms.Button();
            this.odgovor3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(39, 76);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(796, 93);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(36, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pitanje: ";
            // 
            // odgovor1
            // 
            this.odgovor1.Location = new System.Drawing.Point(144, 235);
            this.odgovor1.Name = "odgovor1";
            this.odgovor1.Size = new System.Drawing.Size(572, 60);
            this.odgovor1.TabIndex = 2;
            this.odgovor1.Text = "Odgovor1";
            this.odgovor1.UseVisualStyleBackColor = true;
            // 
            // odgovor2
            // 
            this.odgovor2.Location = new System.Drawing.Point(144, 301);
            this.odgovor2.Name = "odgovor2";
            this.odgovor2.Size = new System.Drawing.Size(572, 60);
            this.odgovor2.TabIndex = 3;
            this.odgovor2.Text = "Odgovor2";
            this.odgovor2.UseVisualStyleBackColor = true;
            // 
            // odgovor3
            // 
            this.odgovor3.Location = new System.Drawing.Point(144, 367);
            this.odgovor3.Name = "odgovor3";
            this.odgovor3.Size = new System.Drawing.Size(572, 60);
            this.odgovor3.TabIndex = 4;
            this.odgovor3.Text = "Odgovor2";
            this.odgovor3.UseVisualStyleBackColor = true;
            // 
            // Pitanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ucilica.Properties.Resources.ucionica;
            this.ClientSize = new System.Drawing.Size(876, 484);
            this.Controls.Add(this.odgovor3);
            this.Controls.Add(this.odgovor2);
            this.Controls.Add(this.odgovor1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Pitanje";
            this.Text = "Pitanje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button odgovor1;
        private System.Windows.Forms.Button odgovor2;
        private System.Windows.Forms.Button odgovor3;
    }
}