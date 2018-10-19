using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimeHouseSky.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public List<Phone> Phones { get; set; }

        public override string ToString() => Name;
    }
}
