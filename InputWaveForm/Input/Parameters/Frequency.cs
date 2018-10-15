using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input
{
    public class Frequency
    {

        public Frequency()
        {
            ExcitationFrequencyHz = 0.0;

            NeedToRecalculate = false;
            
        }

        private bool NeedToRecalculate;
        private double _excitationFrequency;
        private double _excitationFrequencyHz;


        public Frequency(double excitationFrequency, Time time)
        {
            ExcitationFrequencyHz = excitationFrequency;
            Time = time;
            NeedToRecalculate = true;

        }

        private Time _time;

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

                    NeedToRecalculate = true;
                }
            }
        }

        // In Hz
        public double ExcitationFrequencyHz
        {
            get
            {
                return _excitationFrequencyHz;
            }

            set
            {
                if (!value.Equals(_excitationFrequencyHz))
                {
                    _excitationFrequencyHz = value;
                    NeedToRecalculate = true;
                }
            }
        }

        // In rad/s
        public double ExcitationFrequencyRad
        {
            get
            {
                return 2 * Math.PI * ExcitationFrequencyHz;
            }
                    
        }

        public List<double> CosineOscillation { get; private set; }

        public void CosineCalculate()
        {
            if (NeedToRecalculate)
            {
                if (CosineOscillation == null)
                {
                    CosineOscillation = new List<double>();
                }

                CosineOscillation.Clear();


                //Access Time Data from TimeData Project
                foreach (double item in Time.TimeIntervals)
                {
                    double frequency = Math.Cos(2 * Math.PI * ExcitationFrequencyHz * item);
                    double w = Math.Round(frequency, 6);

                    CosineOscillation.Add(w);
                }

                NeedToRecalculate = false;

            }
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //builder.AppendLine("Times: " + Time.ToString() + "Frequency: " + .ToString() + " Time Step: " + TimeStep.ToString());

            //builder.AppendLine("Start Time: {0:F4}  EndTime:{1:F4}  TimeStep: {2:F4}", StartTime.ToString(), EndTime.ToString(), TimeStep.ToString());

            for (int i = 0; i < Time.TimeIntervals.Count; i++)
            {
                builder.AppendLine("Time: " + Time.TimeIntervals[i].ToString() + "\tFrequency:" + CosineOscillation[i].ToString());
            }
            return builder.ToString();
        }
    }
}
