using System.ComponentModel.DataAnnotations;

namespace MvcWorkspace.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        [Required]
        public string Work { get; set; }

        public bool IsItOver { get; set; }
        public DateTime Time { get; set; }
        public Precedence Priority { get; set; }

        public enum Precedence
        {
            First, Second, Third
        }
    }
}
