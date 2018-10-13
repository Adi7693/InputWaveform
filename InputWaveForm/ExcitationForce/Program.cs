﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeData;
using FrequencyData;


namespace ExcitationForce
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

            }
            catch
            {


            }

            Time time = new Time(t0, tn, dt);
            time.Calculate();

            Frequency frequency = new Frequency(f, time);
            frequency.CosineCalculate();

            ExcitationForce Force = new ExcitationForce(f0, frequency, time);
            Force.ForceCalculate();

            Console.WriteLine(Force);

            Console.ReadLine();


        }
    }
}