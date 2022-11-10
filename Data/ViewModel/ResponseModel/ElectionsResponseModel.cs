using VottingAPI.ViewModel;

namespace VottingAPI.Data.ViewModel.ResponseModel
{
    public class ElectionsResponseModel
    {
        public List<ElectionVM> ElectionVMs { get; set; } = new List<ElectionVM>();
    }
}