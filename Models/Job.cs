using System.ComponentModel.DataAnnotations;

namespace JobsApp.Models
{
    public class Job
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public string Specialization { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Application Deadline")]
        public DateTime ApplicationDate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "C", ApplyFormatInEditMode = false)]
        public decimal Salary { get; set; }
        [Required]
        public JobTypes JobType { get; set; }
        [Required]
        [Display(Name = "Name of company")]
        public string CompanyName { get; set; }
        [DataType(DataType.Url)]
        public string Website { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string CompanyAddress { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
    }
}
