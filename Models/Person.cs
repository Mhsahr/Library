using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Person
    {
        public int Id { get; set; } 
        public string Firstname { get; set; }    
        public string Lastname { get; set; }
        public string Username { get; set; }   
        public string Password { get; set; }
    }
}
