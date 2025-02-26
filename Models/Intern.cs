using System.ComponentModel.DataAnnotations;

namespace ISC_BT2.Models
{
    public class Intern
    {
        [Key]
        public int Id { get; set; }
        public string InternName { get; set; }
        public string InternAddress { get; set; }
        public byte[]? ImageData { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string InternMail { get; set; }
        public string University { get; set; }
        public string CitizenIdentification { get; set; }
        public string Major { get; set; }
        public bool? Internable { get; set; }
        public string Cvfile { get; set; }
        public int? InternSpecialized { get; set; }
        public string TelephoneNum { get; set; }
        public bool? FullTime { get; set; }
        public bool? InternEnabled { get; set; }
        public string Note { get; set; }
        public string JobFields { get; set; }
    }
}
