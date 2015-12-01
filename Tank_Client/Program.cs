using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tank_Client
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // run gui to send key press message
           ThreadPool.QueueUserWorkItem(new WaitCallback(state =>Application.Run(new ArrowKey())));
            // run method to recive message from server continously
           ThreadPool.QueueUserWorkItem(new WaitCallback(state =>Commiunicator.receiveData()));
        
            while (true) { }
        }
    }
}
