using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyData
{
    class Program
    {
        static void Main(string[] args)
        {

            double t0 = 0.0;
            double tn = 0.0;
            double dt = 0.0;
            double f = 0.0;


            try
            {
                Console.WriteLine("Enter Start Time");
                t0 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("End Time");
                tn = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter Time Step");
                dt = Convert.ToDouble(Console.ReadLine());


            }
            catch
            {
                //if (dt > 0.05)
                //    Console.WriteLine("Error: Enter Time Step Less Than 0.05.");
            }

            TimeData.Time time = new TimeData.Time(t0, tn, dt);

            time.Calculate();

            try
            {
                Console.WriteLine("Enter Excitation Frequency");
                f = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                //if (dt > 0.05)
                //    Console.WriteLine("Error: Enter Time Step Less Than 0.05.");
            }


            Frequency frequency = new Frequency(f,time);

            frequency.CosineCalculate();
            Console.WriteLine(frequency);


            Console.ReadLine();







        }
    }
}
