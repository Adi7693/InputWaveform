using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeData
{
    public class Time
    {
        public Time(double startTime, double endTime, double step)
        {
            StartTime = startTime;
            EndTime = endTime;
            TimeStep = step;

            NeedsToRecalculate = true;
        }


        

        private bool NeedsToRecalculate;

        private double _startTime;
        public double StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                if (!value.Equals(_startTime))
                {
                    _startTime = value;

                    NeedsToRecalculate = true;
                }
            }
        }

        private double _timeStep;
        public double TimeStep
        {
            get
            {
                return _timeStep;
            }
            set
            {
                if (!value.Equals(_timeStep))
                {
                    _timeStep = value;

                    NeedsToRecalculate = true;
                }
            }
        }

        private double _endTime;
        public double EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                if (!value.Equals(_endTime))
                {
                    _endTime = value;

                    NeedsToRecalculate = true;
                }
            }
        }

        public List<double> TimeIntervals { get; private set; }

        public void Calculate()
        {
            if (NeedsToRecalculate)
            {
                if (TimeIntervals == null)
                {
                    TimeIntervals = new List<double>();
                }

                TimeIntervals.Clear();

                for (double i = StartTime; i <= EndTime + TimeStep / 2.0; i += TimeStep)
                {
                    double interval = Math.Round(i, 6);
                    TimeIntervals.Add(interval);
                }

                NeedsToRecalculate = false;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Start Time: " + StartTime.ToString() + " End Time: " + EndTime.ToString() + " Time Step: " + TimeStep.ToString());

            //builder.AppendLine("Start Time: {0:F4}  EndTime:{1:F4}  TimeStep: {2:F4}", StartTime.ToString(), EndTime.ToString(), TimeStep.ToString());

            for (int i = 0; i < TimeIntervals.Count; i++)
            {
                builder.AppendLine("Interval " + i.ToString() + ": " + TimeIntervals[i].ToString());
            }
            return builder.ToString();
        }

    }
}