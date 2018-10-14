using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input
{
    public class VehicleData
    {

        private double _vehicleMass;
        private double _springStiffness;
        private double _dampingCoefficient;
        private double _naturalFrequency;
        private double _naturalFrequencyHz;
        private double _criticalDamping;
        private double _dampingRatio;
        private double _frequencyRatio;

        public bool NeedToCalculate;

        public VehicleData(double vehicleMass, double springStiffness, double dampingCoefficient)
        {
            VehicleMass = vehicleMass;
            SpringStiffness = springStiffness;
            DampingCoefficient = dampingCoefficient;

            NeedToCalculate = true;
        }

        // In Kg
        public double VehicleMass
        {
            get
            {
                return _vehicleMass;
            }

            private set
            {
                if(!value.Equals(_vehicleMass))
                {
                    if(VehicleMass > 0)
                    {
                        _vehicleMass = value;
                        NeedToCalculate = true;
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

            private set
            {
                if (!value.Equals(_springStiffness))
                {
                    _springStiffness = value;
                    NeedToCalculate = true;
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

            private set
            {
                if(!value.Equals(_dampingCoefficient))
                {
                    _dampingCoefficient = value;
                    NeedToCalculate = true;
                }
            }

        }

     // In rad/s
        public double NaturalFrequency
        {
            get
            {
                return _naturalFrequency;
            }

            private set
            {
                if (NeedToCalculate)
                {
                    double wn = Math.Sqrt(SpringStiffness / VehicleMass);
                    _naturalFrequency = wn;
                }
                
            }
            
        }

        // In Hz
        public double NaturalFrequencyHz
        {
            get
            {
                return _naturalFrequencyHz;
            }

            private set
            {
                if (NeedToCalculate)
                {
                    double fn = (1 / (2 * Math.PI)) * Math.Sqrt(SpringStiffness / VehicleMass);
                    _naturalFrequencyHz = fn;
                }
            }
        }

        // In N/(m/s)
        public double CriticalDamping
        {
            get
            {
                return _criticalDamping;
            }

            private set
            {
                if(NeedToCalculate)
                {
                    double cc = 2 * Math.Sqrt(VehicleMass * SpringStiffness);
                    _criticalDamping = cc;
                }
            }
        }

        public double DampingRatio
        {
            get
            {
                return _dampingRatio;
            }

            private set
            {
                if(NeedToCalculate)
                {
                    double zeta = DampingCoefficient / CriticalDamping;
                    _dampingRatio = zeta;
                }
            }
        }

        // In rad/s
        private Frequency _inputFrequency;

        public Frequency InputFrequency
        {
            get
            {
                return _inputFrequency;
            }

            set
            {
                if (NeedToCalculate)
                {
                    if (!value.Equals(_inputFrequency))
                    {
                        _inputFrequency = value;
                        NeedToCalculate = true;
                    }
                }
                    
            }
        }

        
        public double FrequencyRatio
        {
            get
            {
                return _frequencyRatio;
            }

            private set
            {
                if(NeedToCalculate)
                {

                }
            }
        }


        




        
           

    }
}
