using System.ComponentModel.DataAnnotations;
using VottingAPI.Enum;

namespace VottingAPI.ViewModel
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string NextOfKin { get; set; }
        public string MatricNo { get; set; }
        public Level Level { get; set; }
        public int Grade { get; set; }
        public string Course { get; set; }
        public string ImageUrl {get; set;}
    }
}