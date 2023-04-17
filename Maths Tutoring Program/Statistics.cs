using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class Statistics
    {
        private List<string> users = new List<string>();
        private List<string> corrects = new List<string>();
        private List<string> incorrects = new List<string>();
        private List<string> percentageCorrect = new List<string>();
        public Statistics()
        {
            if (File.Exists("statistics.txt"))
            {
                string[] file = File.ReadAllLines("statistics.txt");
                for (int i = 0; i< file.Length;i++)
                {
                    string[] tempLine = file[i].Split(",");
                    users.Add(tempLine[0]); 
                    corrects.Add(tempLine[1]);
                    incorrects.Add(tempLine[2]);
                    percentageCorrect.Add(tempLine[3]);
                }
            }
            else
            {
                Console.WriteLine("Statistics file not found. New file created");
                File.Create("statistics.txt");
            }
        }

        public void PrintStats()
        {
            for(int i = 0; i < users.Count; i++){
                Console.WriteLine("\nUserName: " + users[i]);
                Console.WriteLine("Number of correct answers: " + corrects[i]);
                Console.WriteLine("Number of incorrect answers: " + incorrects[i]);
                Console.WriteLine("Percentage of correct answers: " + percentageCorrect[i]+"%");
            }
        }

        public void addStatistic(string userName, int correct, int incorrect, float percentage)
        {
            while (true) 
            {
                if (File.Exists("statistics.txt"))
                {
                    int value = 0;
                    for(int i = 0; i < users.Count; i++)
                    {
                        if (percentage < Convert.ToInt32(percentageCorrect[i]))
                        {
                            value = i+1;
                        }
                    }
                    users.Insert(value, userName);
                    corrects.Insert(value, correct.ToString());
                    incorrects.Insert(value, incorrect.ToString());
                    percentageCorrect.Insert(value, percentage.ToString());
                    File.Delete("statistics.txt");
                    using (StreamWriter sw = File.AppendText("statistics.txt"))
                    {
                        for (int e = 0; e < users.Count; e++)
                        {
                            sw.WriteLine(users[e] + "," + corrects[e] + "," + incorrects[e] + "," + percentageCorrect[e]);
                        }
                    }
                    PrintStats();
                    break;
                }
                else
                {
                    Console.WriteLine("Statistics file not found. New file created");
                    File.Create("statistics.txt");
                }
            }
        }
    }
}
