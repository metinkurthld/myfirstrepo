using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = 100;
        }

        public string LetterGrade
        {
            get
            {
                if (AverageGrade >= 90)
                {
                    return "A";
                }
                else if (AverageGrade >= 80)
                {
                    return "B";
                }
                else if (AverageGrade >= 70)
                {
                    return "C";
                }
                else if (AverageGrade >= 60)
                {
                    return "D";
                }
                else
                {
                    return "F";
                }
            }
        }

        public string Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below Average";
                        break;
                    default:
                        result = "Failing";
                        break;
                 }
                return result;

            }

        }

        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}
