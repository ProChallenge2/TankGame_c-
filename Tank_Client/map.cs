using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Client
{

   
    class map
    {
        
        public static char[,] grid { get; set; }

        public map(){
            grid = new char[10, 10];
            initGrid();
        }

        public void initGrid() {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i,j] = '0';
                }
            }
        }

        public char[,] getGrid() {
            return grid;
        }

        public void setGrid(char[,] gd)
        {
            grid = gd;
        }


        public void showGrid() {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(grid[i, j]+" ");
                }
            }
            Console.WriteLine("");
        }

        public void setwaterCordinates(String[] array)
        {
            char[] waterD = { ';', ',', '#', '?' };
            String[] water = array[4].Split(waterD);

            for (int k = 0; k < water.Length - 1; k += 2)
            {
                //Console.WriteLine(water[k]);
                grid[Int32.Parse(water[k + 1]), Int32.Parse(water[k])] = 'W';
            }
            //Console.WriteLine("gggggggggg");
        }

        public void setBriksCordinates(String[] array)
        {


            char[] brickD = { ';', ',' };
            String[] bricks = array[2].Split(brickD);


            for (int k = 0; k < bricks.Length; k += 2)
            {
                grid[Int32.Parse(bricks[k + 1]), Int32.Parse(bricks[k])] = 'B';
            }


        }


        public void setStoneCordinates(String[] array)
        {


            char[] stoneD = { ';', ',' };
            String[] stones = array[3].Split(stoneD);

            for (int k = 0; k < stones.Length; k += 2)
            {
                grid[Int32.Parse(stones[k + 1]), Int32.Parse(stones[k])] = 'S';
            }

        }
    }
}
