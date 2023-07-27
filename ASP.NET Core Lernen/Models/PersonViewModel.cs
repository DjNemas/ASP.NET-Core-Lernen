using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Lernen.Models
{
    public class PersonViewModel
    {
        public string Forname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }
    }
}
