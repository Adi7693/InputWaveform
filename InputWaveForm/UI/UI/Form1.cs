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

        private bool NeedsToRecalculate;
        private InputData vehicleData = null;


        public InputData InputData
        {
            get
            {
                if (vehicleData == null)
                {
                    vehicleData = new InputData();
                }
                return vehicleData;
            }
            private set
            {
                if (!value.Equals(vehicleData))
                {
                    vehicleData = value;

                    NeedsToRecalculate = true;

                }
            }
        }




        private void StartTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            double newStartTime = 0.0;

            if(double.TryParse(StartTimeTextBox.Text,out newStartTime))
            {
                //InputData.InputData.InputData.InputData.StartTime = newStartTime;
                InputData.StartTime = newStartTime;
                NeedsToRecalculate = true;
            }
        }

        private void EndTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            double newEndTime = 0.0;

            if(double.TryParse(EndTimeTextBox.Text, out newEndTime))
            {
                //InputData.InputData.InputData.InputData.EndTime = newEndTime;
                InputData.EndTime = newEndTime;
                NeedsToRecalculate = true;
            }
        }

        private void TimeStepTextBox_TextChanged(object sender, EventArgs e)
        {
            double newTimeStep = 0.0;

            if(double.TryParse(TimeStepTextBox.Text, out newTimeStep))
            {
                //InputData.InputData.InputData.InputData.TimeStep = newTimeStep;
                InputData.TimeStep = newTimeStep;
                NeedsToRecalculate = true;
            }
        }

        private void ExcitationFrequencyHzTextBox_TextChanged(object sender, EventArgs e)
        {
            double newExcitationFrequencyHz = 0.0;

            if(double.TryParse(ExcitationFrequencyHzTextBox.Text, out newExcitationFrequencyHz))
            {
                //InputData.InputData.InputData.ExcitationFrequencyHz = newExcitationFrequencyHz;
                InputData.ExcitationFrequencyHz = newExcitationFrequencyHz;
                NeedsToRecalculate = true;
            }
        }

        private void InputForceTextBox_TextChanged(object sender, EventArgs e)
        {
            double newInputForce = 0.0;

            if(double.TryParse(InputForceTextBox.Text, out newInputForce))
            {
                //InputData.InputData.Force = newInputForce;
                InputData.Force = newInputForce;
                NeedsToRecalculate = true;
            }
        }

        private void VehicleMassTextBox_TextChanged(object sender, EventArgs e)
        {
            double newVehicleMass = 0.0;

            if(double.TryParse(VehicleMassTextBox.Text,out newVehicleMass))
            {
                InputData.VehicleMass = newVehicleMass;
                NeedsToRecalculate = true;
            }
        }

        private void SpringStiffnessTextBox_TextChanged(object sender, EventArgs e)
        {
            double newSpringStiffness = 0.0;

            if(double.TryParse(SpringStiffnessTextBox.Text,out newSpringStiffness))
            {
                InputData.SpringStiffness = newSpringStiffness;
                NeedsToRecalculate = true;
            }
        }

        private void DampingCoefficientTextLabel_TextChanged(object sender, EventArgs e)
        {
            double newDampingCoefficient = 0.0;

            if(double.TryParse(DampingCoefficientTextLabel.Text,out newDampingCoefficient))
            {
                InputData.DampingCoefficient = newDampingCoefficient;
                NeedsToRecalculate = true;
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            //InputData.InputData.InputData.InputData.Calculate();
            InputData.Calculate();
            
            FrequencyRatioTextBox.Text = Math.Round(InputData.FrequencyRatio,3).ToString();
            NaturalFrequencyHzTextBox.Text = Math.Round(InputData.NaturalFrequencyHz,3).ToString();
            ExcitationFrequencyRadTextBox.Text = Math.Round(InputData.ExcitationFrequencyRad,3).ToString();
            SCPhyTextBox.Text = Math.Round(InputData.Phy,3).ToString();
            DampingRatioTextBox.Text = Math.Round(InputData.DampingRatio,3).ToString();
            CriticalDampingTextBox.Text = Math.Round(InputData.CriticalDamping,3).ToString();
            NaturalFrequencyRadTextBox.Text = Math.Round(InputData.NaturalFrequencyRad,3).ToString();


        }

        private void PlotButton_Click(object sender, EventArgs e)
        {
            

            DataTable table = new DataTable("Input Force vs Time");
            table.Columns.Add("Time", typeof(double));
            table.Columns.Add("Input Force", typeof(double));

            for (int i = 0; i < InputData.TimeIntervals.Count; i++)
            {
                table.Rows.Add(InputData.TimeIntervals[i], InputData.ForceOscillations[i]);
            }

            //chart1.Series.Clear();
            chart1.Series["Input"].XValueMember = "Time";
            chart1.Series["Input"].YValueMembers = "Input Force";
            chart1.DataSource = table;
            chart1.DataBind();
            chart1.Update();

            //chart1
            //table.Columns[0].A
            //chart1.DataBind();


            //tabg
            InputDataGridView.DataSource = table;
            InputDataGridView.Update();
        }
    }
}
