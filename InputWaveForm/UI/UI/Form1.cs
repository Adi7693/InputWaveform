﻿using System;
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

        private bool needsToRecalculate;

        public bool NeedsToRecalculate
        {
            get
            {
                return needsToRecalculate;
            }

            set
            {
                if(!value.Equals(needsToRecalculate))
                {
                    needsToRecalculate = value;
                    
                    PlotButton.Enabled=!needsToRecalculate;
                }
            }
        }

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

            if (double.TryParse(EndTimeTextBox.Text, out newEndTime))
            {
                if (newEndTime > InputData.StartTime)
                {
                    //InputData.InputData.InputData.InputData.EndTime = newEndTime;
                    InputData.EndTime = newEndTime;
                    NeedsToRecalculate = true;
                }
                else
                {
                    MessageBox.Show("End Time Must Be Greater Than Start Time");
                    StartTimeTextBox.Text = "";
                    EndTimeTextBox.Text = "";
                }
            }
        }

        private void TimeStepTextBox_TextChanged(object sender, EventArgs e)
        {
            double newTimeStep = 0.0;

            if(double.TryParse(TimeStepTextBox.Text, out newTimeStep))
            {
                if (newTimeStep <= 0.01)
                {
                    //InputData.InputData.InputData.InputData.TimeStep = newTimeStep;
                    InputData.TimeStep = newTimeStep;
                    NeedsToRecalculate = true;
                }

                else
                {
                    MessageBox.Show("Time Step Must Be Less Than or Equal To 0.01 Seconds");
                    TimeStepTextBox.Text = "";
                }
            }
        }

        private void ExcitationFrequencyHzTextBox_TextChanged(object sender, EventArgs e)
        {
            double newExcitationFrequencyHz = 0.0;

            if(double.TryParse(ExcitationFrequencyHzTextBox.Text, out newExcitationFrequencyHz))
            {
                if (newExcitationFrequencyHz > 0)
                {
                    //InputData.InputData.InputData.ExcitationFrequencyHz = newExcitationFrequencyHz;
                    InputData.ExcitationFrequencyHz = newExcitationFrequencyHz;
                    NeedsToRecalculate = true;
                }

                else
                {
                    MessageBox.Show("Enter Non Zero Value");
                    ExcitationFrequencyHzTextBox.Text = "";
                }
            }
        }

        private void InputForceTextBox_TextChanged(object sender, EventArgs e)
        {
            double newInputForce = 0.0;

            if (double.TryParse(InputForceTextBox.Text, out newInputForce))
            {
                if (newInputForce > 0)
                {
                    //InputData.InputData.Force = newInputForce;
                    InputData.Force = newInputForce;
                    NeedsToRecalculate = true;
                }

                else
                {
                    MessageBox.Show("Enter Non Zero Value");
                    InputForceTextBox.Text = "";
                }
            }
        }

        private void VehicleMassTextBox_TextChanged(object sender, EventArgs e)
        {
            double newVehicleMass = 0.0;

            if(double.TryParse(VehicleMassTextBox.Text,out newVehicleMass))
            {
                if (newVehicleMass > 0)
                {
                    InputData.VehicleMass = newVehicleMass;
                    NeedsToRecalculate = true;
                }

                else
                {
                    MessageBox.Show("Vehicle Mass Must be Greater Than Zero");
                    VehicleMassTextBox.Text = "";
                }
                
            }
        }

        private void SpringStiffnessTextBox_TextChanged(object sender, EventArgs e)
        {
            double newSpringStiffness = 0.0;

            if(double.TryParse(SpringStiffnessTextBox.Text,out newSpringStiffness))
            {
                if(newSpringStiffness>0)
                {
                    InputData.SpringStiffness = newSpringStiffness;
                    NeedsToRecalculate = true;
                }

                else
                {
                    MessageBox.Show("Spring Stiffness Must Be Greater Than Zero");
                    SpringStiffnessTextBox.Text = "";
                }
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
            if (NeedsToRecalculate)
            {
                //InputData.InputData.InputData.InputData.Calculate();
                InputData.Calculate();

                FrequencyRatioTextBox.Text = Math.Round(InputData.FrequencyRatio, 3).ToString();
                NaturalFrequencyHzTextBox.Text = Math.Round(InputData.NaturalFrequencyHz, 3).ToString();
                ExcitationFrequencyRadTextBox.Text = Math.Round(InputData.ExcitationFrequencyRad, 3).ToString();
                SCPhyTextBox.Text = Math.Round(InputData.Phy, 3).ToString();
                DampingRatioTextBox.Text = Math.Round(InputData.DampingRatio, 3).ToString();
                CriticalDampingTextBox.Text = Math.Round(InputData.CriticalDamping, 3).ToString();
                NaturalFrequencyRadTextBox.Text = Math.Round(InputData.NaturalFrequencyRad, 3).ToString();
                NeedsToRecalculate = false;

            }

            else
            {
                MessageBox.Show("Enter All The Input Parameters Before Attempting To Calculate");
            }
            


        }

        private void PlotButton_Click(object sender, EventArgs e)
        {
            if (!NeedsToRecalculate)
            {
                DataTable table = new DataTable("Input Force vs Time");
                table.Columns.Add("Time", typeof(double));
                table.Columns.Add("Input Force", typeof(double));

                for (int i = 0; i < InputData.TimeIntervals.Count; i++)
                {
                    table.Rows.Add(InputData.TimeIntervals[i], InputData.ForceOscillations[i]);
                }


                chart1.Series["Input Force"].XValueMember = "Time";
                chart1.Series["Input Force"].YValueMembers = "Input Force";
                chart1.DataSource = table;
                chart1.DataBind();
                chart1.Update();

                //chart1.ChartAreas["Input"].AxisY.Maximum = InputData.ForceOscillations.Max();
                //chart1.ChartAreas["Input"].AxisY.Minimum = InputData.ForceOscillations.Min();


                chart1.ChartAreas["Input"].AxisX.MajorGrid.Interval = 1;
                chart1.ChartAreas["Input"].AxisX.Minimum = 0;
                chart1.ChartAreas["Input"].AxisY.MajorGrid.Interval = 100;




                DataTable outputTable = new DataTable("Displacement vs Time");
                outputTable.Columns.Add("Time", typeof(double));
                outputTable.Columns.Add("Displacement", typeof(double));

                for (int i = 0; i < InputData.TimeIntervals.Count; i++)
                {
                    outputTable.Rows.Add(InputData.TimeIntervals[i], InputData.Displacement[i]);
                }

                DisplacementChart.Series["Displacement"].XValueMember = "Time";
                DisplacementChart.Series["Displacement"].YValueMembers = "Displacement";
                DisplacementChart.DataSource = outputTable;
                DisplacementChart.DataBind();
                DisplacementChart.Update();
                DisplacementChart.ChartAreas["Displacement"].AxisX.MajorGrid.Interval = 1;
                DisplacementChart.ChartAreas["Displacement"].AxisX.Minimum = 0;
            }

            

        }
    }
}
