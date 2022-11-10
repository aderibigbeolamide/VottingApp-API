namespace VottingAPI.ViewModel
{
    public class VoterVM
    {
        public int StudentId { get; set; }
        public int CastVote {get; set;}
        public int ElectionId { get; set; }
        public List<StudentVM> StudentVMs {get; set;} = new List<StudentVM>();
    }
}