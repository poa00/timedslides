﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;

namespace PetjeOp {
    public partial class MasterController : Form {
        // Declareer hieronder alle controllers
        private ExampleController ExampleController { get; set; }
        private ExampleTwoController ExampleTwoController { get; set; }
        private AddQuestionnaireController AddQuestionnaireController { get; set; }

        // Declareer hier ook wanneer je een nieuwe controller toevoegt
        public enum Controllers {
            ExampleController,
            ExampleControllerTwo,
            AddQuestionnaireController
        }

        public MasterController() {
            InitializeComponent();

            // Initialiseer de controllers
            ExampleController = new ExampleController(this);
            ExampleTwoController = new ExampleTwoController(this);
            AddQuestionnaireController = new AddQuestionnaireController(this);

            // We beginnen met deze view
            mainPanel.Controls.Add(AddQuestionnaireController.View);
            if (AddQuestionnaireController != null)
            {
                AddQuestionnaireController.View.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                mainPanel.AutoScroll = true;
                AddQuestionnaireController.View.Width -= 180;
                AddQuestionnaireController.View.Height += 10;
            }
        }

        // Dit wordt bijvoorbeeld aangeroepen wanneer we op een knop klikken (zie ExampleView.button1_Click)
        public void SetController(Controllers controller) {
            // Eerst verwijderen we de view
            mainPanel.Controls.Clear();

            // We voegen dan de view toe aan het paneel
            if(controller == Controllers.ExampleController) {
                mainPanel.Controls.Add(ExampleController.View);
            }
            else if (controller == Controllers.ExampleControllerTwo) {
                mainPanel.Controls.Add(ExampleTwoController.View);
            } else if (controller == Controllers.AddQuestionnaireController)
            {
                mainPanel.Controls.Add(AddQuestionnaireController.View);
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
