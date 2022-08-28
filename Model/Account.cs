namespace TestbART.Model
{
    public class Account
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public Incident Incident { get; set; }

        public List<Contact> Contacts { get; set; }
    }

}
