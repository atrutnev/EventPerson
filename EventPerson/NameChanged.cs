using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPerson
{
    public class NameChanged : EventArgs
    {
        //private string value;

        public NameChanged(string newName)
        {
            this.NewName = newName;
        }

        public string NewName { get; internal set; }
    }
}
