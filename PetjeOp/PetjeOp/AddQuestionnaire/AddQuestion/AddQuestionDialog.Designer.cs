﻿namespace PetjeOp.AddQuestionnaire.AddQuestion
{
    partial class AddQuestionDialog
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
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.addQuestionView1 = new PetjeOp.AddQuestionnaire.AddQuestionView();
            this.SuspendLayout();
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddQuestion.Enabled = false;
            this.btnAddQuestion.Location = new System.Drawing.Point(220, 189);
            this.btnAddQuestion.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(121, 21);
            this.btnAddQuestion.TabIndex = 1;
            this.btnAddQuestion.Text = "Vraag Toevoegen";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(344, 189);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 21);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // addQuestionView1
            // 
            this.addQuestionView1.AddQuestionDialog = null;
            this.addQuestionView1.Location = new System.Drawing.Point(6, 6);
            this.addQuestionView1.Margin = new System.Windows.Forms.Padding(1);
            this.addQuestionView1.Name = "addQuestionView1";
            this.addQuestionView1.Size = new System.Drawing.Size(460, 179);
            this.addQuestionView1.TabIndex = 0;
            // 
            // AddQuestionDialog
            // 
            this.AcceptButton = this.btnAddQuestion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(471, 214);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.addQuestionView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddQuestionDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Vraag Toevoegen";
            this.ResumeLayout(false);

        }

        #endregion

        public AddQuestionView addQuestionView1;
        public System.Windows.Forms.Button btnAddQuestion;
        public System.Windows.Forms.Button btnCancel;
    }
}