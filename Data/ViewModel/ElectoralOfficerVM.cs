using VottingAPI.Enum;

namespace VottingAPI.ViewModel
{

    public class ElectoralOfficerVM
    {
        public int Id {get; set;}
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string NextOfKin { get; set; }
        public Role RoleId { get; set; }
    }
}