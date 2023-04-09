using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class OperationCard: Card
    {
        private string[] Operations = { "+", "-", "*", "/"};
        public override int Value
        {
            get { return _value; }
            set { if (value < 4 && value > 0) { _value = value; } } //checks the value is valid
        }
        public override void PrintCard()
        {
            Console.WriteLine(Operations[Value]);
        }
    }
}
