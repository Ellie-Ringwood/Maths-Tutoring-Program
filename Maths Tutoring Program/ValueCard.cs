using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class ValueCard: Card
    {
        public override int Value
        {
            get { return _value; }
            set { if (value < 13 && value > 0) { _value = value; } } //checks the value is valid
        }
        public override void PrintCard()
        {
            Console.WriteLine(Value.ToString());
        }
    }
}
