namespace WebApplicationTest.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string  Name { get; set; }

        public string Email { get; set; }   
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }    
        public DateTime CreatedTime { get; set; }   
        public DateTime ModifiedTime { get; set;}
    }
}
