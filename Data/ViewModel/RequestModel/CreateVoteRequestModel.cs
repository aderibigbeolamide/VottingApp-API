namespace VottingAPI.Data.ViewModel.RequestModel
{
    public class CreateVoteRequestModel
    {
        public int ContestantId {get; set;}
        public int ElectionId { get; set; }
        public int VoterId { get; set; }
        public string ContestantName {get; set;}
        public string ElectionName {get; set;}
    }
}