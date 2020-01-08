using IECodeChallenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IECodeChallenge.Domain.Models
{
    public class Pacman
    {

        List<string> _commands = new List<string>();
        public int X { get; set; }
        public int Y { get; set; }
        public EDirection F { get; protected set; }
        public int TotalCommands => _commands.Count;



        public bool CanExecuteCommand(string command)
        {
            if (_commands.Count == 0)
            {
                if (!command.Contains("PLACE"))
                    return false;
            }

            _commands.Add(command);

            return true;
        }
        public void Place(int x, int y, EDirection f)
        {
            X = x;
            Y = y;
            F = f;
        }

        public void RotateLeft()
        {
            if (F == 0)
                F = EDirection.NORTH;
            else
                F--;
        }
        public void RotateRight()
        {
            if ((int)F == 3)
                F = 0;
            else
                F++;
        }

        public bool Move()
        {
            switch (F)
            {
                case EDirection.EAST:
                    return MoveX();
                case EDirection.SOUTH:
                    return MoveY();
                case EDirection.WEST:
                    return MoveX();
                case EDirection.NORTH:
                    return MoveY();
                default:
                    return false;
            }
        }

        private bool MoveX()
        {
            if (F == EDirection.EAST)
            {
                if (X < 4)
                    X++;
                else
                    return false;
            }
            if (F == EDirection.WEST)
            {
                if (X > 0)
                    X--;
                else
                    return false;
            }

            return true;

        }
        private bool MoveY()
        {
            if (F == EDirection.NORTH)
            {
                if (Y < 4)
                    Y++;
                else
                    return false;
            }
            if (F == EDirection.SOUTH)
            {
                if (Y > 0)
                    Y--;
                else
                    return false;
            }

            return true;
        }
    }

}
