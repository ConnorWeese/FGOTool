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

            //temporary user declaration, will have to check user file later to see if a user exists to pull data from
            user = new User();

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
                    user.addServant(temp);
;

                    updateMyServantListVisuals(user.getAllServants());

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
                Button button = new Button();   //create a new button
                button.Width = splitContainer1.Panel1.Width-30; //set it's width to be 30 pixels less than the total width of panel 1
                button.Height = 50; //set the height to 50
                button.Text = ser.getName();    //set the text of the button to be the servant's name
                button.Location = new Point(splitContainer1.Location.X, splitContainer1.Location.Y+(50*counter));   //set the location of the button based on the number of buttons before it
                button.Click += servantButtonClickEvent;    //add a new event to the click
                splitContainer1.Panel1.Controls.Add(button);    //add the button to panel 1's control
                counter++;  //increment the button counter
            }
        }

        //event handler for when a user clicks on a servant button in the My Servants tab
        private void servantButtonClickEvent(Object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();    //clear everything from panel 2

            Servant servant = user.getServant((sender as Button).Text);    //get the servant to pull data from

            displayServantData(servant);
        }

        private void displayServantData(Servant servant)
        {
            Label serName = new Label();    //create a label for the servants name
            serName.AutoSize = true;    //set label autosize to true
            serName.Font = new Font(serName.Font.FontFamily, serName.Font.Size + 10.0f, serName.Font.Style);    //increase the label's font size
            serName.Location = new Point(splitContainer1.Location.X, splitContainer1.Location.Y);   //set the label's location
            serName.Text = servant.getName(); ; //set the label's text to the servant name
            splitContainer1.Panel2.Controls.Add(serName);   //add the label to panel 2's controls

            //base hp, max hp, grail hp
            Label serHPNames = new Label();
            serHPNames.AutoSize = true;
            serHPNames.Font = new Font(serHPNames.Font.FontFamily, serHPNames.Font.Size + 5.0f, serHPNames.Font.Style);
            serHPNames.Location = new Point(splitContainer1.Location.X + serName.Height + 10, splitContainer1.Location.Y + serName.Height + 10);
            serHPNames.Text = "";

            //hp numbers
            Label serHPNums = new Label();
            serHPNums.AutoSize = true;
            serHPNums.Font = new Font(serHPNums.Font.FontFamily, serHPNums.Font.Size + 5.0f, serHPNums.Font.Style);
            serHPNums.Location = new Point(splitContainer1.Location.X + serHPNames.Location.X + serHPNames.Width + 20, splitContainer1.Location.Y + serName.Height + 10);
            serHPNums.Text = "";
            serHPNums.TextAlign = ContentAlignment.TopRight;

            //base atk, max atk, grail atk
            Label serATKNames = new Label();
            serATKNames.AutoSize = true;
            serATKNames.Font = new Font(serATKNames.Font.FontFamily, serATKNames.Font.Size + 5.0f, serATKNames.Font.Style);
            serATKNames.Location = new Point(splitContainer1.Location.X + serHPNums.Location.X + 100, splitContainer1.Location.Y + serName.Height + 10);
            serATKNames.Text = "";

            //atk numbers
            Label serATKNums = new Label();
            serATKNums.AutoSize = true;
            serATKNums.Font = new Font(serATKNums.Font.FontFamily, serATKNums.Font.Size + 5.0f, serATKNums.Font.Style);
            serATKNums.Location = new Point(splitContainer1.Location.X + serATKNames.Location.X + serATKNames.Width + 20, splitContainer1.Location.Y + serName.Height + 10);
            serATKNums.Text = "";
            serATKNums.TextAlign = ContentAlignment.TopRight;

            int counter = 0;
            foreach (var stat in servant.getStats())
            {
                if (counter < 3)
                {
                    serHPNames.Text += stat.Key + ":" + Environment.NewLine;
                    serHPNums.Text += String.Format("{0:n0}", stat.Value) + Environment.NewLine;
                }
                else
                {
                    serATKNames.Text += stat.Key + ":" + Environment.NewLine;
                    serATKNums.Text += String.Format("{0:n0}", stat.Value) + Environment.NewLine;
                }
                counter++;
            }
            splitContainer1.Panel2.Controls.Add(serHPNames);
            splitContainer1.Panel2.Controls.Add(serHPNums);
            splitContainer1.Panel2.Controls.Add(serATKNames);
            splitContainer1.Panel2.Controls.Add(serATKNums);

            counter = 0;
            foreach (var mat in servant.getTotalMats())
            {
                //label to display the name of a material
                Label serMatNames = new Label();
                serMatNames.AutoSize = true;
                serMatNames.Font = new Font(serMatNames.Font.FontFamily, serMatNames.Font.Size + 5.0f, serMatNames.Font.Style);
                serMatNames.Location = new Point(splitContainer1.Location.X + serName.Height + 10, splitContainer1.Location.Y + serHPNames.Height + 65 + (35 * counter));
                serMatNames.Text += mat.Key + ":";

                

                //label to display the total number of a material that a servant needs
                Label serMatNums = new Label();
                serMatNums.Width = 110;
                serMatNums.Font = new Font(serMatNums.Font.FontFamily, serMatNums.Font.Size + 5.0f, serMatNums.Font.Style);
                serMatNums.Location = new Point(splitContainer1.Location.X + serMatNames.Location.X + serMatNames.Width + 100, splitContainer1.Location.Y + serHPNames.Height + 65 + (35 * counter));
                serMatNums.TextAlign = ContentAlignment.TopRight;
                serMatNums.Text += String.Format("{0:n0}", mat.Value);

                

                //skip the textbox for a servant's QP numbers, it won't be very usable to have a user increment QP by 1 each time
                //      or remember how much they've gone up by an manually type it in
                if (counter != 0)
                {
                    //textbox to display user entered values for the number of materials used
                    TextBox usedMatBox = new TextBox();
                    usedMatBox.Font = new Font(usedMatBox.Font.FontFamily, usedMatBox.Font.Size + 5.0f, usedMatBox.Font.Style);
                    usedMatBox.Location = new Point(splitContainer1.Location.X + serMatNums.Location.X + serMatNums.Width + 40, splitContainer1.Location.Y + serHPNames.Height + 63 + (35 * counter));
                    usedMatBox.TextAlign = HorizontalAlignment.Right;
                    usedMatBox.Text = String.Format("{0:n0}", servant.getMatCount()[mat.Key]);
                    
                    //add the textbox to the panel controls
                    splitContainer1.Panel2.Controls.Add(usedMatBox);
                }
                
                //increment the counter
                counter++;

                //adding the labels to the control earlier in the code ruins the layout

                //add the labels to the panel controls
                splitContainer1.Panel2.Controls.Add(serMatNames);
                splitContainer1.Panel2.Controls.Add(serMatNums);
            }
        }
    }
}
