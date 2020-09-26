using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FGOTool
{
    public partial class Form1 : Form
    {
        //create a global controller
        Controller controller;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controller = new Controller();
            //label1.Text = controller.getInfo();
            //controller.addUshi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = controller.getServant(textBox1.Text);
        }
    }
}
