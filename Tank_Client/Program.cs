using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Client
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Commiunicator c = new Commiunicator();
            ArrowKey form = new ArrowKey();

            form.Show();
            //init client connection to server
          //  Commiunicator.sendData();


            //init a socket for call back from the server to fetch messages
            Commiunicator.receiveData();
            while (true) { }
        }
    }
}
