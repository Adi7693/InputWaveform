using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Input;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool NeedToRecalculate;
        private VehicleData vehicleData = null;


        public VehicleData VehicleData
        {
            get
            {
                if (vehicleData == null)
                {
                    vehicleData = new VehicleData();
                }
                return vehicleData;
            }
            private set
            {
                if (!value.Equals(vehicleData))
                {
                    vehicleData = value;

                    NeedToRecalculate = true;

                }
            }
        }

        private InputForce force;

        public InputForce Force
        {
            get
            {
                if (force == null)
                {
                    force = new InputForce();
                }
                return force;
            }
            private set
            {
                if (!value.Equals(force))
                {
                    force = value;

                    NeedToRecalculate = true;

                }
            }
        }


        private Frequency frequency;

        public Frequency Frequency
        {
            get
            {
                if (frequency == null)
                {
                    frequency = new Frequency();
                }
                return frequency;
            }
            private set
            {
                if (!value.Equals(frequency))
                {
                    frequency = value;

                    NeedToRecalculate = true;

                }
            }
        }

        private Time time;

        public Time Time
        {
            get
            {
                if (time == null)
                {
                    time = new Time();
                }
                return time;
            }
            private set
            {
                if (!value.Equals(vehicleData))
                {
                    time = value;

                    NeedToRecalculate = true;

                }
            }
        }




        private void StartTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            double newStartTime = 0.0;

            if(double.TryParse(StartTimeTextBox.Text,out newStartTime))
            {
                //VehicleData.Force.Frequency.Time.StartTime = newStartTime;
                Time.StartTime = newStartTime;
                NeedToRecalculate = true;
            }
        }

        private void EndTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            double newEndTime = 0.0;

            if(double.TryParse(EndTimeTextBox.Text, out newEndTime))
            {
                //VehicleData.Force.Frequency.Time.EndTime = newEndTime;
                Time.EndTime = newEndTime;
                NeedToRecalculate = true;
            }
        }

        private void TimeStepTextBox_TextChanged(object sender, EventArgs e)
        {
            double newTimeStep = 0.0;

            if(double.TryParse(TimeStepTextBox.Text, out newTimeStep))
            {
                //VehicleData.Force.Frequency.Time.TimeStep = newTimeStep;
                Time.TimeStep = newTimeStep;
                NeedToRecalculate = true;
            }
        }

        private void ExcitationFrequencyHzTextBox_TextChanged(object sender, EventArgs e)
        {
            double newExcitationFrequencyHz = 0.0;

            if(double.TryParse(ExcitationFrequencyHzTextBox.Text, out newExcitationFrequencyHz))
            {
                //VehicleData.Force.Frequency.ExcitationFrequencyHz = newExcitationFrequencyHz;
                Frequency.ExcitationFrequencyHz = newExcitationFrequencyHz;
                NeedToRecalculate = true;
            }
        }

        private void InputForceTextBox_TextChanged(object sender, EventArgs e)
        {
            double newInputForce = 0.0;

            if(double.TryParse(InputForceTextBox.Text, out newInputForce))
            {
                //VehicleData.Force.Force = newInputForce;
                Force.Force = newInputForce;
                NeedToRecalculate = true;
            }
        }

        private void VehicleMassTextBox_TextChanged(object sender, EventArgs e)
        {
            double newVehicleMass = 0.0;

            if(double.TryParse(VehicleMassTextBox.Text,out newVehicleMass))
            {
                VehicleData.VehicleMass = newVehicleMass;
                NeedToRecalculate = true;
            }
        }

        private void SpringStiffnessTextBox_TextChanged(object sender, EventArgs e)
        {
            double newSpringStiffness = 0.0;

            if(double.TryParse(SpringStiffnessTextBox.Text,out newSpringStiffness))
            {
                VehicleData.SpringStiffness = newSpringStiffness;
                NeedToRecalculate = true;
            }
        }

        private void DampingCoefficientTextLabel_TextChanged(object sender, EventArgs e)
        {
            double newDampingCoefficient = 0.0;

            if(double.TryParse(DampingCoefficientTextLabel.Text,out newDampingCoefficient))
            {
                VehicleData.DampingCoefficient = newDampingCoefficient;
                NeedToRecalculate = true;
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            //VehicleData.Force.Frequency.Time.Calculate();
            Time.Calculate();
            //VehicleData.Force.Frequency.CosineCalculate();
            Frequency.Time = Time;
            Frequency.CosineCalculate();
            Force.Frequency = Frequency;
            //VehicleData.Force.ForceCalculate();
            Force.ForceCalculate();
            VehicleData.Force = Force;
            VehicleData.CalculateDisplacement();
            
            FrequencyRatioTextBox.Text = Math.Round(VehicleData.FrequencyRatio,3).ToString();
            NaturalFrequencyHzTextBox.Text = Math.Round(VehicleData.NaturalFrequencyHz,3).ToString();
            ExcitationFrequencyRadTextBox.Text = Math.Round(Frequency.ExcitationFrequencyRad,3).ToString();
            SCPhyTextBox.Text = Math.Round(VehicleData.Phy,3).ToString();
            DampingRatioTextBox.Text = Math.Round(VehicleData.DampingRatio,3).ToString();
            CriticalDampingTextBox.Text = Math.Round(VehicleData.CriticalDamping,3).ToString();
            NaturalFrequencyRadTextBox.Text = Math.Round(VehicleData.NaturalFrequencyRad,3).ToString();


        }

        private void PlotButton_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable("Input Force vs Time");
            table.Columns.Add("Time", typeof(double));
            table.Columns.Add("Input Force", typeof(double));

            for (int i = 0; i < Time.TimeIntervals.Count; i++)
            {
                table.Rows.Add(Time.TimeIntervals[i], Force.ForceOscillations[i]);
            }

            chart1.Series["Input"].XValueMember = "Time";
            chart1.Series["Input"].YValueMembers = "Input Force";
            chart1.DataSource = table;
            chart1.DataBind();
            chart1.Update();
            //chart1
            //table.Columns[0].A
            //chart1.DataBind();
            //chart1.Poin

            //tabg
            InputDataGridView.DataSource = table;
            InputDataGridView.Update();
        }
    }
}
