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
            this.pitanjeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.odgovor1 = new System.Windows.Forms.Button();
            this.odgovor2 = new System.Windows.Forms.Button();
            this.odgovor3 = new System.Windows.Forms.Button();
            this.odgovor4 = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Label();
            this.bodoviLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pitanjeTextBox
            // 
            this.pitanjeTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pitanjeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pitanjeTextBox.Location = new System.Drawing.Point(39, 76);
            this.pitanjeTextBox.Multiline = true;
            this.pitanjeTextBox.Name = "pitanjeTextBox";
            this.pitanjeTextBox.ReadOnly = true;
            this.pitanjeTextBox.Size = new System.Drawing.Size(796, 93);
            this.pitanjeTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(36, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pitanje: ";
            // 
            // odgovor1
            // 
            this.odgovor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.odgovor1.Location = new System.Drawing.Point(144, 175);
            this.odgovor1.Name = "odgovor1";
            this.odgovor1.Size = new System.Drawing.Size(572, 60);
            this.odgovor1.TabIndex = 2;
            this.odgovor1.Text = "Odgovor1";
            this.odgovor1.UseVisualStyleBackColor = true;
            this.odgovor1.Click += new System.EventHandler(this.odgovor1_Click);
            // 
            // odgovor2
            // 
            this.odgovor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.odgovor2.Location = new System.Drawing.Point(144, 253);
            this.odgovor2.Name = "odgovor2";
            this.odgovor2.Size = new System.Drawing.Size(572, 60);
            this.odgovor2.TabIndex = 3;
            this.odgovor2.Text = "Odgovor2";
            this.odgovor2.UseVisualStyleBackColor = true;
            this.odgovor2.Click += new System.EventHandler(this.odgovor2_Click);
            // 
            // odgovor3
            // 
            this.odgovor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.odgovor3.Location = new System.Drawing.Point(144, 331);
            this.odgovor3.Name = "odgovor3";
            this.odgovor3.Size = new System.Drawing.Size(572, 60);
            this.odgovor3.TabIndex = 4;
            this.odgovor3.Text = "Odgovor2";
            this.odgovor3.UseVisualStyleBackColor = true;
            this.odgovor3.Click += new System.EventHandler(this.odgovor3_Click);
            // 
            // odgovor4
            // 
            this.odgovor4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.odgovor4.Location = new System.Drawing.Point(144, 412);
            this.odgovor4.Name = "odgovor4";
            this.odgovor4.Size = new System.Drawing.Size(572, 60);
            this.odgovor4.TabIndex = 5;
            this.odgovor4.Text = "Odgovor2";
            this.odgovor4.UseVisualStyleBackColor = true;
            this.odgovor4.Click += new System.EventHandler(this.odgovor4_Click);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.time.Location = new System.Drawing.Point(910, 27);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(53, 20);
            this.time.TabIndex = 6;
            this.time.Text = "label2";
            // 
            // bodoviLabel
            // 
            this.bodoviLabel.AutoSize = true;
            this.bodoviLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bodoviLabel.Location = new System.Drawing.Point(742, 412);
            this.bodoviLabel.Name = "bodoviLabel";
            this.bodoviLabel.Size = new System.Drawing.Size(53, 20);
            this.bodoviLabel.TabIndex = 7;
            this.bodoviLabel.Text = "label2";
            // 
            // Pitanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ucilica.Properties.Resources.ucionica;
            this.ClientSize = new System.Drawing.Size(1046, 487);
            this.Controls.Add(this.bodoviLabel);
            this.Controls.Add(this.time);
            this.Controls.Add(this.odgovor4);
            this.Controls.Add(this.odgovor3);
            this.Controls.Add(this.odgovor2);
            this.Controls.Add(this.odgovor1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pitanjeTextBox);
            this.Name = "Pitanje";
            this.Text = "Pitanje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pitanjeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button odgovor1;
        private System.Windows.Forms.Button odgovor2;
        private System.Windows.Forms.Button odgovor3;
        private System.Windows.Forms.Button odgovor4;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label bodoviLabel;
    }
}