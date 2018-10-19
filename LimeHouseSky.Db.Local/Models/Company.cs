using System.Collections.Generic;

namespace LimeHouseSky.Db.Local.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public List<Phone> Phones { get; set; }

        public override string ToString() => Name;
    }
}
