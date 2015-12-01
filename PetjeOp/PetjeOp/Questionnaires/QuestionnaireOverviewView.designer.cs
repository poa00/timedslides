﻿namespace PetjeOp.Questionnaires
{
    partial class QuestionnaireOverviewView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAddQuestionnaire = new System.Windows.Forms.Label();
            this.tvQuestionnaires = new System.Windows.Forms.TreeView();
            this.btnAddQuestionnaire = new System.Windows.Forms.Button();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cbSubjects = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblAddQuestionnaire
            // 
            this.lblAddQuestionnaire.AutoSize = true;
            this.lblAddQuestionnaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddQuestionnaire.Location = new System.Drawing.Point(2, 2);
            this.lblAddQuestionnaire.Margin = new System.Windows.Forms.Padding(2);
            this.lblAddQuestionnaire.Name = "lblAddQuestionnaire";
            this.lblAddQuestionnaire.Size = new System.Drawing.Size(301, 55);
            this.lblAddQuestionnaire.TabIndex = 1;
            this.lblAddQuestionnaire.Text = "Vragenlijsten";
            // 
            // tvQuestionnaires
            // 
            this.tvQuestionnaires.Location = new System.Drawing.Point(12, 182);
            this.tvQuestionnaires.Name = "tvQuestionnaires";
            this.tvQuestionnaires.Size = new System.Drawing.Size(1123, 581);
            this.tvQuestionnaires.TabIndex = 2;
            // 
            // btnAddQuestionnaire
            // 
            this.btnAddQuestionnaire.Location = new System.Drawing.Point(12, 780);
            this.btnAddQuestionnaire.Name = "btnAddQuestionnaire";
            this.btnAddQuestionnaire.Size = new System.Drawing.Size(291, 76);
            this.btnAddQuestionnaire.TabIndex = 3;
            this.btnAddQuestionnaire.Text = "+ Vragenlijst Toevoegen";
            this.btnAddQuestionnaire.UseVisualStyleBackColor = true;
            this.btnAddQuestionnaire.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(12, 118);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(55, 25);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Vak:";
            // 
            // cbSubjects
            // 
            this.cbSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubjects.FormattingEnabled = true;
            this.cbSubjects.Items.AddRange(new object[] {
            "Alle vakken"});
            this.cbSubjects.Location = new System.Drawing.Point(74, 118);
            this.cbSubjects.Name = "cbSubjects";
            this.cbSubjects.Size = new System.Drawing.Size(327, 33);
            this.cbSubjects.TabIndex = 5;
            this.cbSubjects.SelectedIndexChanged += new System.EventHandler(this.cbSubjects_SelectedIndexChanged);
            // 
            // QuestionnaireOverviewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbSubjects);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.btnAddQuestionnaire);
            this.Controls.Add(this.tvQuestionnaires);
            this.Controls.Add(this.lblAddQuestionnaire);
            this.Name = "QuestionnaireOverviewView";
            this.Size = new System.Drawing.Size(1160, 888);
            this.Load += new System.EventHandler(this.QuestionnaireOverviewView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddQuestionnaire;
        public System.Windows.Forms.TreeView tvQuestionnaires;
        private System.Windows.Forms.Button btnAddQuestionnaire;
        private System.Windows.Forms.Label lblSubject;
        public System.Windows.Forms.ComboBox cbSubjects;
    }
}
