using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace MvcWorkspace.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Expense Name")]
        public string ExpenseName { get; set; }

        [Required]
        [Range(1,int.MaxValue)] //propu int olarak tanımladığımız için girilecek değer int boyutunu aşmasın diye validation
        public int Amount { get; set; }
    }
}
