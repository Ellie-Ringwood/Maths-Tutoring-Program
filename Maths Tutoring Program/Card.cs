﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    abstract class Card
    {
        protected int _value;

        public abstract int Value { get; set;}
        public abstract void PrintCard();
    }
}
