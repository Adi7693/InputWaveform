﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Input;
using Utilities;

namespace Output
{
    class Program
    {
        static void Main(string[] args)
        {
            double t0 = 0.0;
            double tn = 0.0;
            double dt = 0.0;
            double f = 0.0;
            double f0 = 0.0;
            double m = 0.0;

            try
            {
                Console.WriteLine("Enter Start Time.");
                t0 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("End Time.");
                tn = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter Time Step.");
                dt = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter Excitation Frequency in Hz.");
                f = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter Excitation Force in Newtons.");
                f0 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter Vehicle Mass.");
                m = Convert.ToDouble(Console.ReadLine());


                while(m <= 0.0)
                {
                    Console.WriteLine("Vehicle mass cannot be zero or a negative value. Reenter Vehicle Mass.");
                    m = Convert.ToDouble(Console.ReadLine());
                }
            }
            catch { }

            Time time = new Time(t0, tn, dt);
            time.Calculate();

            Frequency frequency = new Frequency(f, time);
            frequency.CosineCalculate();
            Console.WriteLine(frequency);

            InputForce force = new InputForce(f0, frequency, time);
            force.ForceCalculate();

            //Console.WriteLine(Force);

            //SaveToCSV CSV = new SaveToCSV(time, force);
            //CSV.Convert();
            //CSV.Print();
            ////CSV.SaveAsCSV();


            Console.ReadLine();
        }
    }
}
