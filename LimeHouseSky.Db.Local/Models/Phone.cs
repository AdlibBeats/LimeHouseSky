namespace LimeHouseSky.Db.Local.Models
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
