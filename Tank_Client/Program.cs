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


            Thread t1 = new Thread(
                    new ThreadStart(
                            delegate()
                            {
                                Application.Run(new ArrowKey());
                            }
                        )
                );

            Thread t2 = new Thread(
                   new ThreadStart(
                           delegate()
                           {
                               Commiunicator.receiveData();
                           }
                       )
               );

            t1.Start();
            t2.Start();


            while (true) { }
        }
    }
}
