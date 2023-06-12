namespace Asp.Net_Core_Homework.Models.Domain
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Branch { get; set; }
        public int NumberOfPatients { get; set; }



    }
}
