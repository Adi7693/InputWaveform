using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeData;

namespace FrequencyData
{
    public class Frequency
    {

        private bool NeedToCalculate;
        private double _excitationFrequency;


        public Frequency(double excitationFrequency, Time time)
        {
            ExcitationFrequency = excitationFrequency;
            Time = time;
            NeedToCalculate = true;

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

                    NeedToCalculate = true;
                }
            }
        }

        public double ExcitationFrequency
        {
            get
            {
                return _excitationFrequency;
            }

            set
            {
                if (!value.Equals(_excitationFrequency))
                {
                    _excitationFrequency = value;
                    NeedToCalculate = true;
                }
            }
        }

        public List<double> CosineOscillation { get; private set; }

        public void CosineCalculate()
        {
            if (NeedToCalculate)
            {
                if (CosineOscillation == null)
                {
                    CosineOscillation = new List<double>();
                }

                CosineOscillation.Clear();


                //Access Time Data from TimeData Project
                foreach (double item in Time.TimeIntervals)
                {
                    double frequency = Math.Cos(2 * Math.PI * ExcitationFrequency * item);
                    double w = Math.Round(frequency, 6);

                    CosineOscillation.Add(w);
                }

                NeedToCalculate = false;

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
