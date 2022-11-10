using VottingAPI.Enum;

namespace VottingAPI.Data.ViewModel.RequestModel
{
    public class CreateStudentRequestModel
    {
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
        public IFormFile ImageUrl {get; set;}
    }
}