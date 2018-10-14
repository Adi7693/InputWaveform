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

namespace _1DoFSimulator
{
    public partial class Form1 : Form
    {
        private bool NeedsToRecalculate;

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

                    NeedsToRecalculate = true;
                }
            }
        }

       


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double newVehicleData = 0.0;

            if (double.TryParse(StartTimeTextBox.Text, out newVehicleData))
            {
                if (newVehicleData != VehicleData.StartTime)
                {
                    VehicleData.StartVehicleData = newVehicleData;

                    NeedsToRecalculate = true;
                }
            }
        }






        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            VehicleData.Calculate();
        }

        private void InputParametersGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
