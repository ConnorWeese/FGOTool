using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FGOTool
{
    public partial class Form1 : Form
    {
        //create a global controller
        Controller controller;
        //create a global user
        User user;
        //create a global servant so we can use it's data throughout the app
        Servant servantToAdd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //autosizing will grow/shrink window to the dimensions of the controlls
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            //setting up the search error label
            searchErrorLabel.Text = "";
            searchErrorLabel.ForeColor = Color.Red;

            //setting up the add servant error label
            addServantErrorLabel.Text = "";
            addServantErrorLabel.ForeColor = Color.Red;

            //setting up the search results textbox
            //searchResultTextBox.Enabled = true;
            //searchResultTextBox.Visible = false;  //sets the results textbox to hidden, will unhide once we receive results to display

            controller = new Controller();
            //label1.Text = controller.getInfo();
            //controller.addUshi();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void addServantButton_Click(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {

        }
    }
}
