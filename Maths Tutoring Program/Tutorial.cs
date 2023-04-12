using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class Tutorial
    {
        public Equation equation = new Equation();
        public void PrintInstructions()
        {
            Console.WriteLine("\nIn the menu, Enter a value (from 1 to 4) for the option you would like. answer.");
            Console.WriteLine("Option 2 and 3, give cards that create an equation");
            Console.WriteLine("It will prompt you to enter the answer (use BODMAS). Then it will output the correct answer");
            Console.WriteLine("This is an example of 2 value equation it would give:");
            equation.CreateEquation(2);
            Console.WriteLine("This is an example of 3 value equation it would give:");
            equation.CreateEquation(3);
        }
    }
}
