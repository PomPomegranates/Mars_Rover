using MarsRover.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarsRover.User_Interface
{
    public class Display
    {
        char marsRover = (char)164;
        char martian = (char)165;
        char soil = (char)160;
        static Plateau plateau;
        static char[,] map; 
        static Display instance;
        public bool isOn = true;

        private Display()
        {
            if (plateau == null)
            {
                plateau = Plateau.GetMap();
            }
            map = new char[plateau.MapSize.x, plateau.MapSize.y];
        }

        public static void CreateMap()
        {
            
            if (instance == null)
            {
                instance = new Display();
            }

            
            for (int i = 0; i < plateau.MapSize.x; i++) 
            {
                for (int j = 0; j < plateau.MapSize.y; j++)
                {
                    map[i, j] = (char)129;
                }
            }
        }

        public static void ShowMap()
        {
            
            for (int i = plateau.MapSize.x -1; i>=0; i--)
            {
                for (int j = 0; j < plateau.MapSize.y; j++)
                {
                    
                    Console.Write(' ');
                    Console.Write(map[i, j]);
                    Console.Write(' ');
                }
                Console.Write("\n");

            }
            


        }

        public static bool IsRunning()
        {
            if (instance == null)
            {
                instance = new Display();
            }
            return instance.isOn;
        }

        public static void TurnOff()
        {
            if (instance == null)
            {
                instance = new Display();
            }
            instance.isOn = false;
        }
        public static void TurnOn()
        {
            if (instance == null)
            {
                instance = new Display();
            }
            instance.isOn = true;
        }

    }

}
