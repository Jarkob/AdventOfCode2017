﻿using System;
namespace Day22
{
    public class Virus
    {
        public Virus(char[][] Grid, int X, int Y)
        {
            this.Grid = Grid;

            // Für Test
            this.X = X;
            this.Y = Y;

            this.Infections = 0;
        }

        public int Infections { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }

        public char[][] Grid { get; set; }

        public void Burst()
        {
            if(this.Grid[Y][X] == ' ')
            {
                this.Grid[Y][X] = '.';
            }

            if (this.Grid[Y][X] == '#')
            {
                switch (this.Direction)
                {
                    case "up":
                        this.Direction = "right";
                        break;
                    case "down":
                        this.Direction = "left";
                        break;
                    case "left":
                        this.Direction = "up";
                        break;
                    case "right":
                        this.Direction = "down";
                        break;
                    default:
                        this.Direction = "right";
                        break;
                }

                this.Grid[Y][X] = '.';
            }
            else
            {
                switch (this.Direction)
                {
                    case "up":
                        this.Direction = "left";
                        break;
                    case "down":
                        this.Direction = "right";
                        break;
                    case "left":
                        this.Direction = "down";
                        break;
                    case "right":
                        this.Direction = "up";
                        break;
                    default:
                        this.Direction = "left";
                        break;
                }

                this.Grid[Y][X] = '#';

                this.Infections++;
            }

            // Move
            switch (this.Direction)
            {
                case "up":
                    this.Y--;
                    break;
                case "down":
                    this.Y++;
                    break;
                case "left":
                    this.X--;
                    break;
                case "right":
                    this.X++;
                    break;
                default:
                    throw new Exception("No direction");
            }
        }

        public void Print()
        {
            for (int i = 0; i < this.Grid.Length; i++)
            {
                for (int j = 0; j < this.Grid[i].Length; j++)
                {
                    if (i != this.Y || j != this.X)
                    {
                        Console.Write(this.Grid[i][j]);
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
