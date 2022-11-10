namespace VottingAPI.Data.ViewModel.RequestModel
{
    public class CreateContestRequestModel
    {
        public int VoteCount {get; set;}
        public string Description { get; set; }
        public int StudentId {get; set;}
        public int ElectionId {get; set;}
        public int PositionId {get; set;}
    }
}