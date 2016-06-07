using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPerson
{
    public class NameChanging : EventArgs
    {
        //private string name;
        //private string value;

        public NameChanging(string newName, string oldName)
        {
            this.OldName = oldName;
            this.NewName = newName;
        }

        public string OldName { get; internal set; }
        public string NewName { get; internal set; }

    }
}
