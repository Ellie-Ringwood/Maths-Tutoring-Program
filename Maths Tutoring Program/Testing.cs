using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class Testing
    {
        private static Equation equation = new Equation();
        private static Statistics stats = new Statistics();
        private Menu menu = new Menu(stats,equation);
        private int answer;
        public Testing()
        {
            Random randInt = new Random();
            stats.currentUsername = "RandomNumber" + randInt.Next() ;
            equation.CreateEquation(2);
            answer = equation.equationAnswer.Value; // correct answer
            equation.CheckAnswer(answer,stats);
            equation.PrintAnswer();
            equation.CreateEquation(3);
            answer = 100; // incorrect answer
            equation.CheckAnswer(answer, stats);
            equation.PrintAnswer();
            stats.addStatistic();
            menu.UserInput();
        }
    }
}
