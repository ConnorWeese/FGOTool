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

            //add the tab switch event handler to the main tab controller
            mainTabControl.SelectedIndexChanged += mainTabControl_SelectedIndexChange;

        }

        //when a user clicks this button, a search will happen with the database to find a return a servant
        private void searchButton_Click(object sender, EventArgs e)
        {
            //need to add input error checking before we open a connection to the database

            servantToAdd = controller.getServant(searchBox.Text);
            if(servantToAdd != null)
            {
                addServantErrorLabel.Text = servantToAdd.getName(); //temp printout so I can read the results
            }
            else
            {
                addServantErrorLabel.Text = "Didn't work fam";  //temp printout so I can read the results
            }
        }

        //when a user clicks this button, the servant should be added into the user's list of servants
        private void addServantButton_Click(object sender, EventArgs e)
        {

        }

        //when a user clicks this button, the search resuslts text box, search bar, and any error labels should be cleared
        private void clearButton_Click(object sender, EventArgs e)
        {

        }

        //event handler for when a user switches tabs
        private void mainTabControl_SelectedIndexChange(Object sender, EventArgs e)
        {
            switch (mainTabControl.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    //this is where the update for the split panel will go, so that when a user adds a new servant it gets reflected

                    //temp thing in order to have stuff to iterate through before I finish the User class
                    Servant temp = controller.getServant("Ushiwakamaru");
                    List<Servant> tester = new List<Servant>();
                    for(int i=0; i<20; i++)
                    {
                        tester.Add(temp);
                    }
;

                    updateMyServantListVisuals(tester);

                    break;
            }
        }

        //method to add new items to the list of servants viewable in the My Servants Tab
        private void updateMyServantListVisuals(List<Servant> serList)
        {
            splitContainer1.Panel1.Controls.Clear();    //removes everything from the panel
            int counter = 0;    //offset multiplier
            
            foreach(var ser in serList)
            {
                Button button = new Button();
                button.Width = splitContainer1.Panel1.Width-30;
                button.Height = 50;
                button.Text = ser.getName();
                button.Location = new Point(splitContainer1.Location.X, splitContainer1.Location.Y+(50*counter));
                button.Click += servantButtonClickEvent;
                splitContainer1.Panel1.Controls.Add(button);
                counter++;
            }
        }

        private void servantButtonClickEvent(Object sender, EventArgs e)
        {
            searchErrorLabel.Text = "shit works fam, go ham";
        }
    }
}
