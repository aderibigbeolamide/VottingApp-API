namespace VottingAPI.Data.ViewModel.RequestModel
{
    public class CreateElectionRequestModel
    {
        public string ElectionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDisplay { get; set; }
    }
}