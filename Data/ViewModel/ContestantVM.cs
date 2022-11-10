

namespace VottingAPI.ViewModel
{

    public class ContestantVM
    {
        public int StudentId { get; set; }
        public int ElectionId { get; set; }
        public int PositionId { get; set; }
        public int VoteCount { get; set; }
        public string Description { get; set; }
        public List<StudentVM> StudentVMs {get; set;} = new List<StudentVM>();
    }
   
}
