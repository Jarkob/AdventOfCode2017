using System;

namespace Day20
{
    public class Particle
    {
        public Particle(int Xpos, int Ypos, int Zpos, int Xvel, int Yvel, int Zvel, int Xacc, int Yacc, int Zacc)
        {
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.Zpos = Zpos;

            this.Xvel = Xvel;
            this.Yvel = Yvel;
            this.Zvel = Zvel;

            this.Xacc = Xacc;
            this.Yacc = Yacc;
            this.Zacc = Zacc;
        }

        public int Xpos {get; set;}
        public int Ypos {get; set;}
        public int Zpos {get; set;}

        public int Xvel {get; set;}
        public int Yvel {get; set;}
        public int Zvel {get; set;}

        public int Xacc {get; set;}
        public int Yacc {get; set;}
        public int Zacc {get; set;}


        public void Update()
        {
            this.Xvel += this.Xacc;
            this.Yvel += this.Yacc;
            this.Zvel += this.Zacc;

            this.Xpos += this.Xvel;
            this.Ypos += this.Yvel;
            this.Zpos += this.Zvel;
        }


        public int GetDistance()
        {
            return Math.Abs(this.Xpos) + Math.Abs(this.Ypos) + Math.Abs(this.Zpos);
        }
    }
}
