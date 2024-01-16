using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAssignment_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LabClass lc = new LabClass();
                lc.GuessTheLetter();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
            }

        }
    }
}
