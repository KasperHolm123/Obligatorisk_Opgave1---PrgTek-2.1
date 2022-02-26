using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave1.Models
{
    public class Vampire : IPrioritizable
    {
        private string callEndedTime;
        public string Name { get; set; }
        public int Priority { get; set; }
        public bool IsVip { get; set; }

        
        public Vampire(string name, bool vip = false)
        {
            Name = name;
            IsVip = vip;
        }

        public Vampire(int priority, string name, bool vip = false)
        {
            Priority = priority;
            Name = name;
            IsVip = vip;
        }

        public string CallEndedTime
        {
            get { return callEndedTime; }
            set { callEndedTime = value; }
        }
    }
}
