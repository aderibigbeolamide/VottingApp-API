using VottingAPI.Enum;

namespace VottingAPI.Data.ViewModel.RequestModel
{
    public class CreateElectoralOfficerRequestModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string NextOfKin { get; set; }
        public Role RoleId { get; set; }
    }
}