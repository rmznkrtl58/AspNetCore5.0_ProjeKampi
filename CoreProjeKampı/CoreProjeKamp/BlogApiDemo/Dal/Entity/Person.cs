using System.ComponentModel.DataAnnotations;

namespace BlogApiDemo.Dal.Entity
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [StringLength(40)]
        public string NameSurname { get; set; }
    }
}
