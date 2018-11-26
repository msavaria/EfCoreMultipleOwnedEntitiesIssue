
namespace MigrationBugRepro.Models
{
    public class Account
    {
        public string AccountId { get; set; }

        public Address MainAddress { get; set; }
        public Address SecondaryAddress { get; set; }
    }
}
