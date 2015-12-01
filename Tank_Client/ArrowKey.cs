using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tank_Client
{
    public partial class ArrowKey : Form
    {

        public ArrowKey()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state =>Commiunicator.sendData(Constant.RIGHT)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state =>Commiunicator.sendData(Constant.UP)));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state =>Commiunicator.sendData(Constant.C2S_INITIALREQUEST)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state =>Commiunicator.sendData(Constant.DOWN)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state =>Commiunicator.sendData(Constant.LEFT)));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state =>Commiunicator.sendData(Constant.SHOOT)));
        }

        private void ArrowKey_Load(object sender, EventArgs e)
        {

        }

            
    }
}
