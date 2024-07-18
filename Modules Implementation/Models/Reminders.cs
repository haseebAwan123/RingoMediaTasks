using System.ComponentModel.DataAnnotations;

namespace Modules_Implementation.Models
{
    public class Reminders
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
    }
}
