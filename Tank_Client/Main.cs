using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Client
{
    class Main
    {
        private Player player = new Player();
        beans.LifePack lifePack = new beans.LifePack();
        beans.Treasure treasure = new beans.Treasure();
        private Player[] playr = new Player[5];
        public map mp= new map();
        public static char[,] grid=null;
        bool a = false;
        bool b = false;


        public Main()
        {

            grid=mp.getGrid();

        }

       
        public String jointoserver()
        {
            return "JOIN#";
        }

       /*
        this method is used to tokenize and identify the server message
        */
        public void tokenizeMessage(String msg) {

            // split from #
            String[] reply = msg.Split('#');


            
            if (reply[0] == Constant.S2C_GAMESTARTED) 
            {
                Console.WriteLine("Game is started.");
            }
            else if (reply[0] == Constant.S2C_NOTSTARTED)
            {
                Console.WriteLine("Game is not started yet.");
            }

            else if (reply[0] == Constant.S2C_GAMEOVER)
            {
                Console.WriteLine("Game Over");
            }
            else if (reply[0] == Constant.S2C_GAMEJUSTFINISHED)
            {
                Console.WriteLine("Game just finished");
            }
            else if (reply[0] == Constant.S2C_CONTESTANTSFULL)
            {
                Console.WriteLine("Players full");
            }
            else if (reply[0] == Constant.S2C_ALREADYADDED)
            {
                Console.WriteLine("Player is already added.");
            }
            else if (reply[0] == Constant.S2C_INVALIDCELL)
            {
                Console.WriteLine("INVALID_CELL");
            }

            else if (reply[0] == Constant.S2C_NOTACONTESTANT)
            {
                Console.WriteLine("NOT_A_VALID_CONTESTANT");
            }
            else if (reply[0] == Constant.S2C_TOOEARLY)
            {
                Console.WriteLine(" TOO_QUICK");
            }
            else if (reply[0] == Constant.S2C_CELLOCCUPIED)
            {
                Console.WriteLine("CELL_OCCUPIED");
            }
            else if (reply[0] == Constant.S2C_HITONOBSTACLE)
            {
                Console.WriteLine("OBSTACLE");
            }
            else if (reply[0] == Constant.S2C_NOTALIVE)
            {
                Console.WriteLine("DEAD");
            }

            else
            {

                char[] del = { ':' };
                String[] array = reply[0].Split(del);
                // identify whether the message is initial meg

                if (array[0] == "I")
                {


                    mp.setBriksCordinates(array);
                    mp.setStoneCordinates(array);
                    mp.setwaterCordinates(array);
                    a = true;


                }

                // identify the message is about response to join
                else if (array[0] == "S")
                {
                    String[] arrayNew = array[1].Split(';');

                    player.playerNumber = Int32.Parse(arrayNew[0].Substring(1));
                    String[] location = arrayNew[1].Split(',');
                    player.playerLocationX = Int32.Parse(location[0]);
                    player.playerLocationY = Int32.Parse(location[1]);

                    player.direction = Int32.Parse(arrayNew[2]);

                    switch (player.direction)
                    {
                        case 0:
                            grid[player.playerLocationY, player.playerLocationX] = '^';
                            break;
                        case 1:
                            grid[player.playerLocationY, player.playerLocationX] = '>';
                            break;
                        case 2:
                            grid[player.playerLocationY, player.playerLocationX] = 'V';
                            break;
                        case 3:
                            grid[player.playerLocationY, player.playerLocationX] = '<';
                            break;

                    }
                    b = true;

                }
                else if (array[0] == "G")
                {
                    Console.WriteLine("");
                    Console.WriteLine("------------------------Player Score------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Player    Health    Coins    Points");
                    for (int i = 1; i < array.Length - 1; i++)
                    {
                        if (playr[i - 1] == null)
                        {
                            playr[i - 1] = new Player();
                        }
                        playerDetails(array[i], playr[i - 1]);
                    }
                    Console.WriteLine("-----------------------------------------------------------");
                }
                else if (array[0] == "L")
                {
                    String[] location = array[1].Split(',');
                    lifePack.locationX = Int32.Parse(location[0]);
                    lifePack.locationY = Int32.Parse(location[1]);
                    lifePack.time = Int32.Parse(array[2]);
                    grid[lifePack.locationY, lifePack.locationX] = 'L';
                }

                else if (array[0] == "C")
                {
                    String[] location = array[1].Split(',');
                    treasure.locationX = Int32.Parse(location[0]);
                    treasure.locationY = Int32.Parse(location[1]);
                    treasure.time = Int32.Parse(array[2]);
                    treasure.value = Int32.Parse(array[3]);
                    grid[treasure.locationY, treasure.locationX] = 'C';
                }


                mp.setGrid(grid);
                if (a & b)
                {
                    mp.showGrid();
                }
            }

        }
        public void playerDetails(String det,Player player)
        {

            String[] arNew = det.Split(';');
            grid[player.playerLocationY, player.playerLocationX] = '0';
                
            player.playerNumber = Int32.Parse(arNew[0].Substring(1));
            String[] location = arNew[1].Split(',');
            
            player.playerLocationX = Int32.Parse(location[0]);
            player.playerLocationY = Int32.Parse(location[1]);

            player.direction = Int32.Parse(arNew[2]);

            switch (player.direction)
            {
                case 0:
                    grid[player.playerLocationY, player.playerLocationX] = '^';
                    break;
                case 1:
                    grid[player.playerLocationY, player.playerLocationX] = '>';
                    break;
                case 2:
                    grid[player.playerLocationY, player.playerLocationX] = 'v';
                    break;
                case 3:
                    grid[player.playerLocationY, player.playerLocationX] = '<';
                    break;

            }

            if (arNew[3] == "0")
            {
                player.Shot = false;
            }
            else
                player.Shot = true;

            player.Health = Int32.Parse(arNew[4]);
            player.Coins = Int32.Parse(arNew[5]);
            player.Points = Int32.Parse(arNew[6]);
           
            Console.WriteLine(player.playerNumber+"        "+player.Health+"        "+player.Coins+"         "+player.Points);
            
        }

     
    }
}
