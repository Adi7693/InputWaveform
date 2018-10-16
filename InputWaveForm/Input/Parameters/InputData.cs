using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MathNet.Numerics;

namespace Input
{
    public class InputData
    {
        private bool TimeNeedsToRecalculate;
        private bool FrequencyNeedsToRecalculate;
        private bool ForceNeedsToRecalculate;
        private bool VehicleDataNeedsToRecalculate;
        #region Constructor

        public InputData()
        {
            StartTime = 0.0;
            EndTime = 0.0;
            TimeStep = 0.0;
            ExcitationFrequencyHz = 0.0;
            Force = 0.0;
            VehicleMass = 0.0;
            SpringStiffness = 0.0;
            DampingCoefficient = 0.0;

            TimeNeedsToRecalculate = false;
            FrequencyNeedsToRecalculate = false;
            ForceNeedsToRecalculate = false;
            VehicleDataNeedsToRecalculate = false;
        } 
        #endregion

        #region Input Properties
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

                    TimeNeedsToRecalculate = true;
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

                    TimeNeedsToRecalculate = true;
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

                    TimeNeedsToRecalculate = true;
                }
            }
        }


        private double _excitationFrequencyHz;
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
                    FrequencyNeedsToRecalculate = true;
                }
            }
        }


        private double _force;
        // In N
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
                    ForceNeedsToRecalculate = true;
                }
            }
        }


        private double _vehicleMass;
        // In Kg
        public double VehicleMass
        {
            get
            {
                return _vehicleMass;
            }

            set
            {
                if (!value.Equals(_vehicleMass))
                {
                    if (value > 0)
                    {
                        _vehicleMass = value;
                        VehicleDataNeedsToRecalculate = true;
                    }
                }
            }
        }


        private double _springStiffness;
        // In N/m
        public double SpringStiffness
        {
            get
            {
                return _springStiffness;
            }

            set
            {
                if (!value.Equals(_springStiffness))
                {
                    _springStiffness = value;
                    VehicleDataNeedsToRecalculate = true;
                }

            }
        }


        private double _dampingCoefficient;
        // In N/(m/s)
        public double DampingCoefficient
        {
            get
            {
                return _dampingCoefficient;
            }

            set
            {
                if (!value.Equals(_dampingCoefficient))
                {
                    _dampingCoefficient = value;
                    VehicleDataNeedsToRecalculate = true;
                }
            }

        }
        #endregion

        #region Derived Properties
        // In rad/s
        public double ExcitationFrequencyRad
        {
            get
            {
                return 2 * Math.PI * ExcitationFrequencyHz;
            }

        }


        // In rad/s
        public double NaturalFrequencyRad
        {
            get
            {
                return Math.Sqrt(SpringStiffness / VehicleMass);
            }

        }

        // In Hz
        public double NaturalFrequencyHz
        {
            get
            {
                return (1 / (2 * Math.PI)) * Math.Sqrt(SpringStiffness / VehicleMass);
            }
        }

        // In N/(m/s)
        public double CriticalDamping
        {
            get
            {
                return 2 * Math.Sqrt(VehicleMass * SpringStiffness);
            }
        }

        public double DampingRatio
        {
            get
            {
                return DampingCoefficient / CriticalDamping;
            }
        }



        public double FrequencyRatio
        {
            get
            {
                return ExcitationFrequencyRad / NaturalFrequencyRad;
            }
        }


        public double Phy
        {
            get
            {
                double num = -2.0 * DampingRatio * FrequencyRatio;
                double den = 1.0 - Math.Pow(FrequencyRatio, 2);
                return Math.Atan(num / den);
            }
        }

        public double StaticDisplacement
        {
            get
            {
                return Force / SpringStiffness;
            }
        }


        public double TransferFunction
        {
            get
            {
                double denFirstTerm = Math.Pow(1.0 - Math.Pow(FrequencyRatio, 2), 2);
                double denSecondTerm = Math.Pow(2.0 * DampingRatio * FrequencyRatio, 2);
                return 1.0 / Math.Sqrt(denFirstTerm + denSecondTerm);

            }
        }
        #endregion

        #region Calculation Methods
        public List<double> TimeIntervals { get; private set; }

        public List<double> CosineOscillation { get; private set; }

        public List<double> ForceOscillations { get; private set; }

        public List<double> Displacement { get; private set; }

        private void TimeCalculate()
        {
            if (TimeNeedsToRecalculate)
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

                TimeNeedsToRecalculate = false;

                FrequencyNeedsToRecalculate = true;
            }
        }

        private void CosineCalculate()
        {
            if (FrequencyNeedsToRecalculate)
            {
                if (CosineOscillation == null)
                {
                    CosineOscillation = new List<double>();
                }

                CosineOscillation.Clear();


                //Access Time Data from TimeData Project
                foreach (double item in TimeIntervals)
                {
                    double frequency = Math.Cos(2 * Math.PI * ExcitationFrequencyHz * item);
                    double w = Math.Round(frequency, 6);

                    CosineOscillation.Add(w);
                }

                FrequencyNeedsToRecalculate = false;

                ForceNeedsToRecalculate = true;

            }
        }

        private void ForceCalculate()
        {
            if (ForceNeedsToRecalculate)
            {
                if (ForceOscillations == null)
                {
                    ForceOscillations = new List<double>();
                }


                ForceOscillations.Clear();

                foreach (double item in CosineOscillation)


                {
                    double force = Force * item;
                    double F = Math.Round(force, 6);

                    ForceOscillations.Add(F);
                }
                ForceNeedsToRecalculate = false;

                VehicleDataNeedsToRecalculate = true;
            }
        }

        private void DisplacementCalculate()
        {
            if (VehicleDataNeedsToRecalculate)
            {
                if (Displacement == null)
                {
                    Displacement = new List<double>();
                }

                Displacement.Clear();

                foreach (double item in TimeIntervals)
                {
                    double xOfTime = 1000.0 * StaticDisplacement * TransferFunction * Math.Cos((ExcitationFrequencyRad * item) + Phy);
                    Displacement.Add(xOfTime);
                }
                VehicleDataNeedsToRecalculate = false;
            }
        }

        public void Calculate()
        {
            TimeCalculate();
            CosineCalculate();
            ForceCalculate();
            DisplacementCalculate();
        }    
#endregion





        







    }
}
