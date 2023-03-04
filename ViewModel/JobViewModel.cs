using JobsApp.Models;
using System.ComponentModel.DataAnnotations;

namespace JobsApp.ViewModel
{
    public class JobViewModel
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Application Deadline")]
        public DateTime ApplicationDate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "C", ApplyFormatInEditMode = true)]
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
