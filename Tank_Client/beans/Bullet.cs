﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tank_Client.beans
{
    class Bullet
    {
        Player shooter;
        int[] dirData = new Int32[2];
        int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int[] DirData
        {
            get { return dirData; }
            set { dirData = value; }
        }

        public Player Shooter
        {
            get { return shooter; }
            set { shooter = value; }
        }
        Point pos;

        public Point Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        int direction;

        public int Direction
        {
            get { return direction; }
            set
            {
                direction = value;

                switch (direction)
                {
                    case 0:
                        dirData[0] = 0;
                        dirData[1] = -1;
                        break;
                    case 1:
                        dirData[0] = 1;
                        dirData[1] = 0;
                        break;
                    case 2:
                        dirData[0] = 0;
                        dirData[1] = 1;
                        break;
                    case 3:
                        dirData[0] = -1;
                        dirData[1] = 0;
                        break;
                    default:
                        break;
                }


            }
        }

        public Bullet(Player con, Point origin, int dir)
        {
            shooter = con;
            pos = origin;
            Direction = dir;
            Console.WriteLine("Bullet shot at " + pos.X + "," + pos.Y + "," + direction);

        }

    }
}
