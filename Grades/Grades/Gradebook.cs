using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
     public class Gradebook : GradeTracker
    {

        public Gradebook()
        {
            grades = new List<float>();
            _name = "Empty"; //needs this initialisor in the constructor in order to invoke delegate in Name property.
        }
         
        public List<float> grades ;

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

                

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;
            return stats;
        }
    

public void WriteGrades()
        {
            for (int i = 0; i < grades.Count; i++)
            {
                Console.WriteLine(grades[i]);
                //destination.WriteLine("mein");
            }
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
                //destination.WriteLine("mein");
            }
        }

    }
}
