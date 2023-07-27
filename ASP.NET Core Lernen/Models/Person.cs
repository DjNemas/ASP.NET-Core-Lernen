using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Lernen.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Forname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

    }
}
