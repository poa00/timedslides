﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public partial class QuestionnaireDetailView : UserControl {
        public QuestionnaireDetailController Controller;

        public QuestionnaireDetailView(QuestionnaireDetailController controller) {
            InitializeComponent();

            Controller = controller;
        }

        private void btnStudentLogin_Click(object sender, EventArgs e) {

        }

        private void btnLoginTeacher_Click(object sender, EventArgs e) {

        }
    }
}