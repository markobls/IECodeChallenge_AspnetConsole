using IECodeChallenge.Domain.Enums;
using IECodeChallenge.Domain.Models;
using System;

namespace IECodeChallenge
{
    class Program
    {
        protected static Pacman _pacman = new Pacman();

        //history of commands
        static void Main(string[] args)
        {
            Console.WriteLine(">>>>>>>>>>>>>>>> IE - Code Challenge - Pacman Simulator <<<<<<<<<<<<<<<<<<<");
            Console.WriteLine("");
            Console.WriteLine("");
            LoadCommands();
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("--------------------YOU MUST NEED TO PLACE FIRST -----------------------------------");
            Console.WriteLine("");


            string command;
            bool quitNow = false;


            while(!quitNow)
            {

                command = Console.ReadLine().ToUpper();
                ExecuteCommand(command);
            }
            




            System.Console.ReadKey();
        }


        static void ExecuteCommand(string command)
        {
            int x = 0;
            int y = 0;
            EDirection f = 0;

            if(string.IsNullOrEmpty(command))
            {
                Console.WriteLine("Unknown Command");
                return;
            }

            if (!_pacman.CanExecuteCommand(command))
            {
                Console.WriteLine("Firsly, you must need to place Pacman");
                return;
            }

            if(command.Contains("PLACE"))
            {
                var itensPlace = command.Split(',');


                if(itensPlace.Length  == 3)
                {
                    try
                    {
                        command = "PLACE";
                        x = Convert.ToInt32(itensPlace[0].Split(' ')[1]);
                        y = Convert.ToInt32(itensPlace[1]);
                        f = (EDirection)System.Enum.Parse(typeof(EDirection), itensPlace[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Unknown Command");
                        return;
                    }

                }
               
            }
            

            switch (command)
            {
                case "L":
                    LookLeft();
                    break;
                case "R":
                    LookRight();
                    break;
                case "I":
                    Report();
                    break;
                case "M":
                    MovePacman();
                    break;
                case "PLACE":
                    PlacePacman(x, y, (int)f);
                    break;
                default:
                    Console.WriteLine("Unknown Command: " + command);
                    break;
            }
        }

        static void LoadCommands()
        {
            var t = new TablePrinter("KEY", "COMMAND");
            t.AddRow("L", "Look Left");
            t.AddRow("R", "Look Right");
            t.AddRow("M", "Move Forward");
            t.AddRow("I", "Report");
            t.AddRow("PLACE X,Y,F", "Ex: 0,0,EAST");

            t.Print();
        }       

        static void LookRight()
        {
            _pacman.RotateRight();
            Console.WriteLine(_pacman.F);

        }

        static void LookLeft()
        {
            _pacman.RotateLeft();
            Console.WriteLine(_pacman.F);
        }

        static void Report()
        {
            Console.WriteLine("Position X: " + _pacman.X);
            Console.WriteLine("Position Y: " + _pacman.Y);
            Console.WriteLine("Position F: " + _pacman.F + "(" + (int)_pacman.F + ")");
            Console.WriteLine("Total Commands Done: " + _pacman.TotalCommands);
        }

        static void MovePacman()
        {
            if(_pacman.Move())
                Console.WriteLine("Moved");
            else
                Console.WriteLine("You can't move");
        }

        static void PlacePacman(int x, int y, int f)
        {
            if (x > 4)
                Console.WriteLine("Impossible. Maximmum to X is 4");
            else if (y > 4)
                Console.WriteLine("Impossible. Maximmum to Y is 4");
            else if (f > 3)
                Console.WriteLine("Impossible. Maximmum to F is 3");
            else
            {
                _pacman.Place(x, y, (EDirection)f);
                Console.WriteLine("Placed");

            }
        }


    }


}
