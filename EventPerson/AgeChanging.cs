using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPerson
{
    public class AgeChanging : EventArgs
    {
        //private int age;
        //private int value;

        public AgeChanging(int NewAge, int OldAge)
        {
            this.OldAge = OldAge;
            this.NewAge = NewAge;
        }

        public int NewAge { get; internal set; }
        public int OldAge { get; internal set; }
    }
}
