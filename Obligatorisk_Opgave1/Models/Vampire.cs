using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave1.Models
{
    public class Vampire : IPrioritizable
    {
        public bool IsVip { get; set; }
        public int Priority { get; set; }
        public string Name { get; set; }

        public Vampire(string name)
        {
            Name = name;
        }

        public Vampire(int priority, string name, bool vip = false)
        {
            Priority = priority;
            Name = name;
            IsVip = vip;
        }
    }
}
