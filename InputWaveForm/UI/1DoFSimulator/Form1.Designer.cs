namespace _1DoFSimulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.StatTimeLabel = new System.Windows.Forms.Label();
            this.StartTimeTextBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TimeStepLabel = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.CalculatorButton = new System.Windows.Forms.Button();
            this.InputParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.NaturalFrequencyLabel = new System.Windows.Forms.Label();
            this.ExportButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.InputParametersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(577, 117);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 414);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(565, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mhatre";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(18, 45);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(523, 287);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(565, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // StatTimeLabel
            // 
            this.StatTimeLabel.AutoSize = true;
            this.StatTimeLabel.Location = new System.Drawing.Point(23, 33);
            this.StatTimeLabel.Name = "StatTimeLabel";
            this.StatTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.StatTimeLabel.TabIndex = 2;
            this.StatTimeLabel.Text = "Start Time";
            this.StatTimeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // StartTimeTextBox
            // 
            this.StartTimeTextBox.Location = new System.Drawing.Point(118, 30);
            this.StartTimeTextBox.Name = "StartTimeTextBox";
            this.StartTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.StartTimeTextBox.TabIndex = 3;
            this.StartTimeTextBox.LostFocus += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.LostFocus += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TimeStepLabel
            // 
            this.TimeStepLabel.AutoSize = true;
            this.TimeStepLabel.Location = new System.Drawing.Point(23, 109);
            this.TimeStepLabel.Name = "TimeStepLabel";
            this.TimeStepLabel.Size = new System.Drawing.Size(55, 13);
            this.TimeStepLabel.TabIndex = 2;
            this.TimeStepLabel.Text = "Time Step";
            this.TimeStepLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(118, 106);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.LostFocus += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Location = new System.Drawing.Point(23, 73);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(52, 13);
            this.EndTimeLabel.TabIndex = 2;
            this.EndTimeLabel.Text = "End Time";
            this.EndTimeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // CalculatorButton
            // 
            this.CalculatorButton.Location = new System.Drawing.Point(70, 188);
            this.CalculatorButton.Name = "CalculatorButton";
            this.CalculatorButton.Size = new System.Drawing.Size(100, 23);
            this.CalculatorButton.TabIndex = 4;
            this.CalculatorButton.Text = "Calculate";
            this.CalculatorButton.UseVisualStyleBackColor = true;
            this.CalculatorButton.Click += new System.EventHandler(this.CalculatorButton_Click);
            // 
            // InputParametersGroupBox
            // 
            this.InputParametersGroupBox.Controls.Add(this.textBox5);
            this.InputParametersGroupBox.Controls.Add(this.StartTimeTextBox);
            this.InputParametersGroupBox.Controls.Add(this.ExportButton);
            this.InputParametersGroupBox.Controls.Add(this.CalculatorButton);
            this.InputParametersGroupBox.Controls.Add(this.textBox4);
            this.InputParametersGroupBox.Controls.Add(this.textBox2);
            this.InputParametersGroupBox.Controls.Add(this.label3);
            this.InputParametersGroupBox.Controls.Add(this.TimeStepLabel);
            this.InputParametersGroupBox.Controls.Add(this.label2);
            this.InputParametersGroupBox.Controls.Add(this.textBox1);
            this.InputParametersGroupBox.Controls.Add(this.EndTimeLabel);
            this.InputParametersGroupBox.Controls.Add(this.NaturalFrequencyLabel);
            this.InputParametersGroupBox.Controls.Add(this.textBox3);
            this.InputParametersGroupBox.Controls.Add(this.StatTimeLabel);
            this.InputParametersGroupBox.Location = new System.Drawing.Point(61, 81);
            this.InputParametersGroupBox.Name = "InputParametersGroupBox";
            this.InputParametersGroupBox.Size = new System.Drawing.Size(305, 551);
            this.InputParametersGroupBox.TabIndex = 5;
            this.InputParametersGroupBox.TabStop = false;
            this.InputParametersGroupBox.Text = "Input Parameters";
            this.InputParametersGroupBox.Enter += new System.EventHandler(this.InputParametersGroupBox_Enter);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(169, 298);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 3;
            this.textBox5.LostFocus += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(118, 338);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.LostFocus += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time Step";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "End Time";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 374);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox1.LostFocus += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // NaturalFrequencyLabel
            // 
            this.NaturalFrequencyLabel.AutoSize = true;
            this.NaturalFrequencyLabel.Location = new System.Drawing.Point(23, 301);
            this.NaturalFrequencyLabel.Name = "NaturalFrequencyLabel";
            this.NaturalFrequencyLabel.Size = new System.Drawing.Size(94, 13);
            this.NaturalFrequencyLabel.TabIndex = 2;
            this.NaturalFrequencyLabel.Text = "Natural Frequency";
            this.NaturalFrequencyLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(70, 522);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(100, 23);
            this.ExportButton.TabIndex = 4;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.CalculatorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 686);
            this.Controls.Add(this.InputParametersGroupBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.InputParametersGroupBox.ResumeLayout(false);
            this.InputParametersGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label StatTimeLabel;
        private System.Windows.Forms.TextBox StartTimeTextBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label TimeStepLabel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label EndTimeLabel;
        private System.Windows.Forms.Button CalculatorButton;
        private System.Windows.Forms.GroupBox InputParametersGroupBox;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label NaturalFrequencyLabel;
        private System.Windows.Forms.Button ExportButton;
    }
}

