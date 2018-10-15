using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MathNet.Numerics;

namespace Input
{
    public class VehicleData
    {
        private double _vehicleMass;
        private double _springStiffness;
        private double _dampingCoefficient;

        public bool NeedsToRecalculate;

        public VehicleData()
        {
            VehicleMass = 0.0;
            SpringStiffness = 0.0;
            DampingCoefficient = 0.0;

            NeedsToRecalculate = false;
        }


        public bool NeedToRecalculate;

        public VehicleData(double vehicleMass, double springStiffness, double dampingCoefficient, InputForce force)
        {
            VehicleMass = vehicleMass;
            SpringStiffness = springStiffness;
            DampingCoefficient = dampingCoefficient;
            Force = force;

            NeedToRecalculate = true;
        }

        // In Kg
        public double VehicleMass
        {
            get
            {
                return _vehicleMass;
            }

            set
            {
                if(!value.Equals(_vehicleMass))
                {
                    if (value > 0)
                    {
                        _vehicleMass = value;
                        NeedToRecalculate = true;
                    }
                }
            }
        }

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
                    NeedToRecalculate = true;
                }
                
            }
        }

        // In N/(m/s)
        public double DampingCoefficient
        {
            get
            {
                return _dampingCoefficient;
            }

            set
            {
                if(!value.Equals(_dampingCoefficient))
                {
                    _dampingCoefficient = value;
                    NeedToRecalculate = true;
                }
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
                return Force.Frequency.ExcitationFrequencyRad / NaturalFrequencyRad;
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


        public double TransferFunction
        {
            get
            {
                double denFirstTerm = Math.Pow(1.0 - Math.Pow(FrequencyRatio, 2), 2);
                double denSecondTerm = Math.Pow(2.0 * DampingRatio * FrequencyRatio, 2);
                return 1.0 / Math.Sqrt(denFirstTerm + denSecondTerm);
                
            }
        }



        private InputForce _force;

        public InputForce Force
        {
            get
            {
                return _force;
            }

            set
            {
                if(!value.Equals(_force))
                {
                    _force = value;
                    NeedToRecalculate = true;
                }
            }
        }


        public double StaticDisplacement
        {
            get
            {
                return Force.Force / SpringStiffness;
            }
        }




        public List<double> Displacement { get; set; }

        public void CalculateDisplacement()
        {
            if (NeedToRecalculate)
            {
                if (Displacement == null)
                {
                    Displacement = new List<double>();
                }

                Displacement.Clear();

                foreach (double item in Force.Frequency.Time.TimeIntervals)
                {
                    double xOfTime = 1000.0*StaticDisplacement * TransferFunction * Math.Cos((Force.Frequency.ExcitationFrequencyRad * item)+Phy);
                    Displacement.Add(xOfTime);
                }
                NeedToRecalculate = false;
            }
        }

        public void SaveAsCSV(string FilePath)
        {
            StringBuilder CSV = new StringBuilder();

            List<double> Intervals = Force.Frequency.Time.TimeIntervals;
            List<double> ForceOscillation = Force.ForceOscillations;

            CSV.AppendLine("Time (s),InputForce (N), Displacement (mm) ");

            for (int i = 0; i < Intervals.Count; i++)
            {
                CSV.AppendLine(Intervals[i].ToString() + " , " + ForceOscillation[i].ToString() + " , " + Displacement[i].ToString());
            }

            if (File.Exists(FilePath))
            {
                FilePath.Replace(".csv", DateTime.Now.ToString() + ".csv");
            }

            try
            {
                File.WriteAllText(FilePath, CSV.ToString());
            }
            catch
            {
            }
        }







    }
}
