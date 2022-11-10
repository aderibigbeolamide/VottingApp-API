using VottingAPI.ViewModel;

namespace VottingAPI.Data.ViewModel.ResponseModel
{
    public class ElectionResponseModel : BaseResponse
    {
        public ElectionVM Data {get; set;}
    }
}