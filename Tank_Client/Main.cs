using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Client
{
    class Main
    {

        private const String PLAYERS_FULL = "PLAYERS_FULL#";
        private const String ALREADY_ADDED = "ALREADY_ADDED#";
        private const String GAME_ALREADY_STARTED = "GAME_ALREADY_STARTED";
        private Player player = new Player();
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

        public int serverJoinMsg(String reply)
        {
            switch (reply)
            {
                case PLAYERS_FULL: return 1;
                case ALREADY_ADDED: return 2;
                case GAME_ALREADY_STARTED: return 3;
                default: return 0;
            }

        }

        public void tokenizeMessage(String reply) { 
          
             
            char [] del = {':','#'};
            String[] array= reply.Split(del);
            
            
            if(array[0]=="I"){
                
                
                mp.setBriksCordinates(array);
                mp.setStoneCordinates(array);
                mp.setwaterCordinates(array);
                a = true;


            }
            else if(array[0]=="S"){
                String[] arrayNew = array[1].Split(';');
                
                player.playerNumber = Int32.Parse(arrayNew[0].Substring(1)); 
                String[] location= arrayNew[1].Split(',');
                player.playerLocationX = Int32.Parse(location[0]);
                player.playerLocationY = Int32.Parse(location[1]);

                player.direction = Int32.Parse(arrayNew[2]);

                switch (player.direction) { 
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
            else if (array[0] == "G"){
               
                for (int i = 1; i < array.Length - 2; i++)
                {
                    if (playr[i-1] == null)
                    {
                        playr[i-1] = new Player();
                    }
                    playerDetails(array[i],playr[i-1]);
                }
                
            }
            mp.setGrid(grid);
            if (a & b)
            {
                mp.showGrid();
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
        }

     
    }
}
