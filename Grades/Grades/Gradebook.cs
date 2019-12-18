﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
     public class Gradebook
    {

        public Gradebook()
        {
            grades = new List<float>();
            _name = "Empty"; //needs this initialisor in the constructor in order to invoke delegate in Name property.
        }
         
        public List<float> grades ;

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        //public GradeStatistics ComputeStatistics()
        //{
        //    return new GradeStatistics();
        //}

        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
                //destination.WriteLine("mein");
            }
        }

        public void WriteGrades()
        {
            for (int i = 0; i < grades.Count; i++)
            {
                Console.WriteLine(grades[i]);
                //destination.WriteLine("mein");
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("argument can not be null or empty oolum");
                    //throw new ArgumentNullException();
                }  
               
                    if (_name != value)
                    {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;
                        //NameChanged(_name, value); old event/delegate type 
                        NameChanged(this, args); //new event type with eventargs
                }
                _name = value;
                
            }
        }
        private string _name;

        public virtual GradeStatistics ComputeStatistics()
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

        //public  NameChangedDelegate NameChanged;
        public event NameChangedDelegate NameChanged;
        
    }
}
