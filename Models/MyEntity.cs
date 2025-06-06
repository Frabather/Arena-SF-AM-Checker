using System.ComponentModel.DataAnnotations;

namespace Arena_SF_AM_Checker.Models
{
    public class MyEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
