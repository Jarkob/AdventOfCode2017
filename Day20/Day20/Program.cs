using System;
using System.IO;
using System.Collections.Generic;

namespace Day20
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Part1();
            Part2();
        }


        public static void Part1()
        {
            string[] ParticleCommands = File.ReadAllLines("../../Day20.txt");

            // Test
            //ParticleCommands = null;
            //ParticleCommands = new string[]
            //{
            //    "p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>",
            //    "p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>"
            //};

            // Create Particles
            Particle[] Particles = new Particle[ParticleCommands.Length];

            string Position;
            string Velocity;
            string Acceleration;

            string[] PositionCoordinates;
            string[] VelocityCoordinates;
            string[] AccelerationCoordinates;

            for (int i = 0; i < ParticleCommands.Length; i++)
            {
                Position = ParticleCommands[i].Split('>')[0].Split('<')[1].Trim();
                PositionCoordinates = Position.Split(',');

                Velocity = ParticleCommands[i].Split('>')[1].Split('<')[1].Trim();
                VelocityCoordinates = Velocity.Split(',');

                Acceleration = ParticleCommands[i].Split('>')[2].Split('<')[1].Trim();
                AccelerationCoordinates = Acceleration.Split(',');

                Particles[i] = new Particle
                (
                    Convert.ToInt32(PositionCoordinates[0]),
                    Convert.ToInt32(PositionCoordinates[1]),
                    Convert.ToInt32(PositionCoordinates[2]),
                    Convert.ToInt32(VelocityCoordinates[0]),
                    Convert.ToInt32(VelocityCoordinates[1]),
                    Convert.ToInt32(VelocityCoordinates[2]),
                    Convert.ToInt32(AccelerationCoordinates[0]),
                    Convert.ToInt32(AccelerationCoordinates[1]),
                    Convert.ToInt32(AccelerationCoordinates[2])
                );
            }


            // Ticking
            for (int k = 0; k < 1000; k++)
            {
                for (int l = 0; l < Particles.Length; l++)
                {
                    Particles[l].Update();
                }
            }

            // Closest distance getten
            int ClosestIndex = 0;

            for (int m = 1; m < Particles.Length; m++)
            {
                if (Particles[m].GetDistance() < Particles[ClosestIndex].GetDistance())
                {
                    ClosestIndex = m;
                }
            }

            Console.WriteLine("Closest particle: " + ClosestIndex);
            // 161
        }


        public static void Part2()
        {
            string[] ParticleCommands = File.ReadAllLines("../../Day20.txt");

            // Test
            //ParticleCommands = null;
            //ParticleCommands = new string[]
            //{
            //    "p=<-6,0,0>, v=< 3,0,0>, a=< 0,0,0>",
            //    "p=<-4,0,0>, v=< 2,0,0>, a=< 0,0,0>",
            //    "p=<-2,0,0>, v=< 1,0,0>, a=< 0,0,0>",
            //    "p=< 3,0,0>, v=<-1,0,0>, a=< 0,0,0>"
            //};

            // Create Particles
            Particle[] Particles = new Particle[ParticleCommands.Length];

            string Position;
            string Velocity;
            string Acceleration;

            string[] PositionCoordinates;
            string[] VelocityCoordinates;
            string[] AccelerationCoordinates;

            for (int i = 0; i < ParticleCommands.Length; i++)
            {
                Position = ParticleCommands[i].Split('>')[0].Split('<')[1].Trim();
                PositionCoordinates = Position.Split(',');

                Velocity = ParticleCommands[i].Split('>')[1].Split('<')[1].Trim();
                VelocityCoordinates = Velocity.Split(',');

                Acceleration = ParticleCommands[i].Split('>')[2].Split('<')[1].Trim();
                AccelerationCoordinates = Acceleration.Split(',');

                Particles[i] = new Particle
                (
                    Convert.ToInt32(PositionCoordinates[0]),
                    Convert.ToInt32(PositionCoordinates[1]),
                    Convert.ToInt32(PositionCoordinates[2]),
                    Convert.ToInt32(VelocityCoordinates[0]),
                    Convert.ToInt32(VelocityCoordinates[1]),
                    Convert.ToInt32(VelocityCoordinates[2]),
                    Convert.ToInt32(AccelerationCoordinates[0]),
                    Convert.ToInt32(AccelerationCoordinates[1]),
                    Convert.ToInt32(AccelerationCoordinates[2])
                );
            }


            // Ticking
            for (int k = 0; k < 1000; k++)
            {
                // Update particles
                for (int l = 0; l < Particles.Length; l++)
                {
                    if (Particles[l] != null)
                    {
                        Particles[l].Update();
                    }
                }

                // Check for Collisions
                List<int> Delete = new List<int>();

                // so geht das nicht mit den Schleifen
                for (int m = 0; m < Particles.Length; m++)
                {
                    for (int n = 0; n < Particles.Length; n++)
                    {
                        if (n != m && Particles[m] != null && Particles[n] != null)
                        {
                            if (Particles[m].Xpos == Particles[n].Xpos
                               && Particles[m].Ypos == Particles[n].Ypos
                               && Particles[m].Zpos == Particles[n].Zpos)
                            {
                                Delete.Add(m);
                            }
                        }
                    }
                }

                // Delete collided particles
                foreach(var element in Delete)
                {
                    Particles[element] = null;
                }
            }

            // Count remaining particles
            int RemainingParticles = 0;
            for (int o = 0; o < Particles.Length; o++)
            {
                if(Particles[o] != null)
                {
                    RemainingParticles++;
                }
            }

            Console.WriteLine("Remaining Particles: "+ RemainingParticles);
            // 438
        }
    }
}
