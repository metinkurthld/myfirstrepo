using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker
    {
        public abstract void AddGrade(float grade); // make abstract leave implementation detail to a derived class. whether to store in a list, file, or xml
        
        //copying all public members of Gradebook into abstract class
        public abstract GradeStatistics ComputeStatistics(); //virtual methods always need implementation
        public abstract void WriteGrades(TextWriter destination);

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


        //public  NameChangedDelegate NameChanged;
        public event NameChangedDelegate NameChanged;

        protected string _name; //made protected so that derived classes can access when required
    }
}
