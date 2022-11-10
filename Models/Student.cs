using VottingAPI.Enum;

namespace VottingAPI.Model
{
    public class Student : Person
    {
        public string MatricNo { get; set; }
        public Level Level { get; set; }
        public bool isApproved {get; set;}
        public int Grade { get; set; }
        public string Course { get; set; }
        public string ImageUrl {get; set;}
    }

}