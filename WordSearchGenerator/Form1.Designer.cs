﻿namespace WordSearchGenerator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalWords = new System.Windows.Forms.TextBox();
            this.wordInput = new System.Windows.Forms.TextBox();
            this.wordList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.removeBtn = new System.Windows.Forms.Button();
            this.puzzleTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter a word to add to the puzzle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Words:";
            // 
            // totalWords
            // 
            this.totalWords.Location = new System.Drawing.Point(80, 115);
            this.totalWords.Name = "totalWords";
            this.totalWords.ReadOnly = true;
            this.totalWords.Size = new System.Drawing.Size(31, 20);
            this.totalWords.TabIndex = 3;
            // 
            // wordInput
            // 
            this.wordInput.Location = new System.Drawing.Point(15, 87);
            this.wordInput.Name = "wordInput";
            this.wordInput.Size = new System.Drawing.Size(163, 20);
            this.wordInput.TabIndex = 2;
            this.wordInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wordInput_KeyPress);
            // 
            // wordList
            // 
            this.wordList.ColumnWidth = 100;
            this.wordList.FormattingEnabled = true;
            this.wordList.Location = new System.Drawing.Point(12, 146);
            this.wordList.Name = "wordList";
            this.wordList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.wordList.Size = new System.Drawing.Size(166, 199);
            this.wordList.TabIndex = 5;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(117, 113);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(61, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(103, 351);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 7;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(15, 10);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(163, 16);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(12, 351);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 9;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // puzzleTitle
            // 
            this.puzzleTitle.Location = new System.Drawing.Point(41, 38);
            this.puzzleTitle.Name = "puzzleTitle";
            this.puzzleTitle.Size = new System.Drawing.Size(137, 20);
            this.puzzleTitle.TabIndex = 1;
            this.puzzleTitle.TextChanged += new System.EventHandler(this.puzzleTitle_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Title:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 382);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.puzzleTitle);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.wordList);
            this.Controls.Add(this.wordInput);
            this.Controls.Add(this.totalWords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Enter Words";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totalWords;
        private System.Windows.Forms.TextBox wordInput;
        private System.Windows.Forms.ListBox wordList;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.TextBox puzzleTitle;
        private System.Windows.Forms.Label label3;
    }
}

