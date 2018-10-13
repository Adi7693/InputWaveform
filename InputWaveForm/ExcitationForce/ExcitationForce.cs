using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeData;
using FrequencyData;

namespace ExcitationForce
{
    public class InputForce
    {
        private double _force;
        private Time _time;
        private Frequency _frequency;

        public bool NeedToCalculate;


        public InputForce(double F0, Frequency w, Time time)
        {
            Force = F0;
            Frequency = w;
            Time = time;


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

        public Time Time
        {
            get
            {
                return _time;
            }

            set
            {
                if (!value.Equals(_time))
                {
                    _time = value;
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



        public List<double> ForceOsciallations { get; private set; }

        public void ForceCalculate()
        {
            if (NeedToCalculate)
            {
                if (ForceOsciallations == null)
                {
                    ForceOsciallations = new List<double>();
                }


                ForceOsciallations.Clear();

                foreach (double item in Frequency.CosineOscillation)


                {
                    double force = Force * item;
                    double F = Math.Round(force, 6);

                    ForceOsciallations.Add(F);
                }
            }
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < Time.TimeIntervals.Count; i++)
            {
                //builder.AppendLine(Time.TimeIntervals[i].ToString());
                //builder.AppendLine(ForceOsciallations[i].ToString());
                builder.AppendLine(Time.TimeIntervals[i] + "," + ForceOsciallations[i]);

            }

            return builder.ToString();
        }
    }
}
