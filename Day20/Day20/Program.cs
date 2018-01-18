using System;
using System.IO;

namespace Day20
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] ParticleCommands = File.ReadAllLines("../../Day20.txt");
            
            // Test
            ParticleCommands = null;
            ParticleCommands = new string[]
            {
                "p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>",
                "p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>"
            };

            // Create Particles
            Particle[] Particles = new Particle[ParticleCommands.Length];

            string Position;
            string Velocity;
            string Acceleration;

            string[] PositionCoordinates;
            string[] VelocityCoordinates;
            string[] AccelerationCoordinates;
		
            for(int i = 0; i < ParticleCommands.Length; i++)
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
            for(int k = 0; k < 1000; k++)
            {
                for(int l = 0; l < Particles.Length; l++)
                {
                    Particles[l].Update();
                }
            }

            // Closest distance getten
            int ClosestIndex = 0;

            for(int m = 1; m < Particles.Length; m++)
            {
                if(Particles[m].GetDistance() < Particles[ClosestIndex].GetDistance())
                {
                    ClosestIndex = m;
                }
            }

            Console.WriteLine("Closest particle: "+ ClosestIndex);
        }
    }
}
