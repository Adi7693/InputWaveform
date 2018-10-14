using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input
{
    public class InputForce
    {
        private double _force;
        private Frequency _frequency;

        public bool NeedToCalculate;


        public InputForce(double F0, Frequency w, Time time)
        {
            Force = F0;
            Frequency = w;

            NeedToCalculate = true;
        }


        public double Force
        {
            get
            {
                return _force;
            }

            set
            {
                if (!value.Equals(_force))
                {
                    _force = value;
                    NeedToCalculate = true;
                }
            }
        }


        public Frequency Frequency
        {
            get
            {
                return _frequency;
            }

            set
            {
                if (!value.Equals(_frequency))
                {
                    _frequency = value;
                    NeedToCalculate = true;
                }
            }

        }



        public List<double> ForceOscillations { get; private set; }

        public void ForceCalculate()
        {
            if (NeedToCalculate)
            {
                if (ForceOscillations == null)
                {
                    ForceOscillations = new List<double>();
                }


                ForceOscillations.Clear();

                foreach (double item in Frequency.CosineOscillation)


                {
                    double force = Force * item;
                    double F = Math.Round(force, 6);

                    ForceOscillations.Add(F);
                }
                NeedToCalculate = false;
            }
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < Frequency.Time.TimeIntervals.Count; i++)
            {
                //builder.AppendLine(Time.TimeIntervals[i].ToString());
                //builder.AppendLine(ForceOsciallations[i].ToString());
                builder.AppendLine(Frequency.Time.TimeIntervals[i] + "," + ForceOscillations[i]);

            }

            return builder.ToString();
        }
    }
}
