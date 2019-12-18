using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{

    //public delegate void NameChangedDelegate(string existingName, string newName); //delegate can be defined in another class but in that case
    //it can only be accessed referring the class name when called outside the class.
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
}
