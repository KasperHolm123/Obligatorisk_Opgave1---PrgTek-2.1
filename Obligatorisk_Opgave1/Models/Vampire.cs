using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave1.Models
{
    public class Vampire
    {
        public int BloodCurrency { get; set; }
        public int Priority { get; set; }
        public string Name { get; set; }

        public Vampire(int bCurrency, int priority, string name)
        {
            BloodCurrency = bCurrency;
            Priority = priority;
            Name = name;
        }
    }
}
