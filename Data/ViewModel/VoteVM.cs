namespace VottingAPI.ViewModel
{

    public class VoteVM
    {
        public int ContestantId {get; set;}
        public int ElectionId { get; set; }
        public int VoterId { get; set; }
        public string ContestantName {get; set;}
        public string ElectionName {get; set;}
    }
}