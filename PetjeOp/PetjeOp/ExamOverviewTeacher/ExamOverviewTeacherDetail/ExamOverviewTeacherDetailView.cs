﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp.ExamOverviewTeacher.ExamOverviewTeacherDetail {
    public partial class ExamOverviewTeacherDetailView : UserControl {
        public ExamOverviewTeacherDetailView() {
            InitializeComponent();
        }

        private void btnEditExam_Click(object sender, EventArgs e) {
            ((ExamOverviewTeacherDetailDialog)Parent).EditExam();
        }

        private void lblPlannedInBy_Click(object sender, EventArgs e)
        {

        }
    }
}
