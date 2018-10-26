using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Input;

namespace Utilities
{
    static public class Utilities
    {
        static public void SaveAsCSV(InputData InputData, string FilePath)
        {
            StringBuilder CSV = new StringBuilder();

            List<double> Intervals = InputData.TimeIntervals;
            List<double> ForceOscillation = InputData.ForceOscillations;
            List<double> Displacement = InputData.ResponseToHarmonicInput;

            CSV.AppendLine("Time (s),InputForce (N), Displacement (mm) ");

            for (int i = 0; i < Intervals.Count; i++)
            {
                CSV.AppendLine(Intervals[i].ToString() + " , " + ForceOscillation[i].ToString() + " , " + Displacement[i].ToString());
            }

            if (File.Exists(FilePath))
            {
                FilePath = FilePath.Replace(".csv", DateTime.Now.ToString() + ".csv");
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
