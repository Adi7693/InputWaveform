using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeData;
using ExcitationForce;

namespace SaveToCSV
{
    public class ConvertToCSV
    {
        private Time _time;
        private InputForce _force;

        public bool NeedToConvert;

        public ConvertToCSV(Time time, InputForce force)
        {
            Time = time;
            Force = force;

            NeedToConvert = true;
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
                    NeedToConvert = true;
                }
            }
        }

        public InputForce Force
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
                    NeedToConvert = true;
                }
            }
        }

        public List<string> CSV { get; private set; }

        public void Convert()
        {
            if (NeedToConvert)
            {
                if (CSV == null)
                {
                    CSV = new List<string>();
                }
            }

            CSV.Clear();

            for (int i = 0; i < Time.TimeIntervals.Count; i++)
            {
                string time = Time.TimeIntervals[i].ToString();
                string force = Force.ForceOsciallations[i].ToString();

                string CSVData = time + " , " + force;
                CSV.Add(CSVData);
            }
        }

        public void Print()
        {
            foreach (object item in CSV)
            {
                Console.WriteLine(item);
            }
        }
    }
}
