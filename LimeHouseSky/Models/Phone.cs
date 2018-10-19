using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimeHouseSky.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public override string ToString() => Title;
    }
}
