using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave1.Models
{
    public class Vampire : IPrioritizable
    {
        public int BloodCurrency { get; set; }
        public int Priority { get; set; }
        public string Name { get; set; }

        public Vampire(int bCurrency, string name)
        {
            BloodCurrency = bCurrency;
            Name = name;
        }

        public Vampire(int priority, int bCurrency, string name)
        {
            Priority = priority;
            BloodCurrency = bCurrency;
            Name = name;
        }
    }
}
