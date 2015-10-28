using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tank_Client
{
    public partial class ArrowKey : Form
    {

        Commiunicator com = new Commiunicator();
        public ArrowKey()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Commiunicator.sendData(Constant.RIGHT);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Commiunicator.sendData(Constant.UP);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Commiunicator.sendData(Constant.C2S_INITIALREQUEST);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Commiunicator.sendData(Constant.DOWN);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Commiunicator.sendData(Constant.LEFT);
        }

        
    }
}
