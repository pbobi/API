using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }
    }
}
