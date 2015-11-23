﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp.AddQuestionnaire
{
    public partial class AddQuestionnaireView : UserControl
    {
        public AddQuestionnaireController Controller { get; set; }

        public AddQuestionnaireView(AddQuestionnaireController controller)
        {
            Controller = controller;
            InitializeComponent();

            Controller = controller;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            Controller.ShowQuestionDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tvQuestions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Controller.ControlEditDeleteButtons();
        }
    }
}
