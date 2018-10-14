using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Input;
namespace Utilities
{
    public class SaveToCSV
    {
        private Time _time;
        private InputForce _force;

        public bool NeedToConvert;

        public SaveToCSV(Time time, InputForce force)
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

        public StringBuilder CSV { get; private set; }

        public void Convert()
        {
            if (NeedToConvert)
            {
                if (CSV == null)
                {
                    CSV = new StringBuilder();
                }
            }

            CSV.Clear();

            for (int i = 0; i < Time.TimeIntervals.Count; i++)
            {
                CSV.AppendLine(Time.TimeIntervals[i].ToString()+" , "+ Force.ForceOscillations[i].ToString());
            }
        }

        public void Print()
        {
            Console.WriteLine(CSV);
        }

        //public void SaveAsCSV()
        //{
        //    File.WriteAllLines(@"C:\Users\Aditya\Documents\VS\GitHub\InputWaveForm\InputWaveform1.csv", CSV);

            
        //}
    }
}
