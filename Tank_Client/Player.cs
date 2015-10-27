using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Client
{
    class Player
    {
        public int playerNumber { get; set; }
        public int playerLocationX { get; set; }
        public int playerLocationY { get; set; }
        public int direction { get; set; }


        public override string ToString()
        {
            return "Player Number " + this.playerNumber + "\n X Coordinate " + this.playerLocationX
                + "\n Y Coordinate " + this.playerLocationY + "\n Current Direction " + this.direction
                ;
        }

    }
}

