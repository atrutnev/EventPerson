using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPerson
{
    public class AgeChanged : EventArgs
    {
        public int newAge { get; set; }

        public AgeChanged(int newAge)
        {
            this.newAge = newAge;
        }
    }
}
