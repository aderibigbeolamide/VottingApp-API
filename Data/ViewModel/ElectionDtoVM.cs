namespace VottingAPI.ViewModel
{

    public class ElectionVM
    {
        public string ElectionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<PositionVM> Positions { get; set; } = new List<PositionVM>();
    }
}