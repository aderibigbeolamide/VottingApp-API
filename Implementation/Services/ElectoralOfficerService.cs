using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;
using VottingAPI.Interface.Repository;
using VottingAPI.Interface.Services;
using VottingAPI.Model;
using VottingAPI.ViewModel;

namespace VottingAPI.Implementation.Services
{
    public class ElectoralOfficerService : IElectoralOfficerService
    {
        private readonly IElectoralOfficerRepository _electoralOfficerRepository;

        public ElectoralOfficerService(IElectoralOfficerRepository electoralOfficerRepository)
        {
            _electoralOfficerRepository = electoralOfficerRepository;
        }

        public async Task<BaseResponse> CreateElectoralOfficerAsync(CreateElectoralOfficerRequestModel model)
        {
            var electoralOfficer = await _electoralOfficerRepository.GetAsync(x => x.Email == model.Email);
            if (electoralOfficer != null)
            {
                return new BaseResponse
                {
                    Message = "Electoral officer already exist",
                    Success = false
                };
            }
            var newElectoralOfficer = new ElectoralOfficer
            {
                FullName = model.FullName,
                Email = model.Email,
                Password = model.Password,
                RoleId = model.RoleId,
                Address = model.Address,
                NextOfKin = model.NextOfKin,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber
            };
            await _electoralOfficerRepository.AddAsync(newElectoralOfficer);
            return new BaseResponse
            {
                Message = "Electoral officer created successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> DeleteElectoralOfficerAsync(int id)
        {
            var electoralOfficer = await _electoralOfficerRepository.GetAsync(x => x.IsDeleted == false &&  x.id == id);
            if (electoralOfficer == null)
            {
                return new BaseResponse
                {
                    Message = "Electoral officer not found",
                    Success = false
                };
            }
            await _electoralOfficerRepository.DeleteAsync(electoralOfficer);
            return new BaseResponse
            {
                Message = "Electoral officer deleted successfully",
                Success = true
            };
        }

        public async Task<ElectoralOfficersResponseModel> GetAllElectoralOfficersAsync()
        {
            var electoralOfficers = await _electoralOfficerRepository.GetAllAsync();
            if (electoralOfficers.Count() == 0)
            {
                return new ElectoralOfficersResponseModel
                {
                    Message = "No electoral officer found",
                    Success = false
                };
            }
            return new ElectoralOfficersResponseModel
            {
                Data = electoralOfficers.Select(x => new ElectoralOfficerVM
                {
                    Id = x.id,
                    FullName = x.FullName,
                    Email = x.Email,
                    Password = x.Password,
                    RoleId = x.RoleId,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    NextOfKin = x.NextOfKin,
                    Gender = x.Gender
                }).ToList(),
                Message = "Electoral officers retrieved successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> GetElectoralOfficerByRole(int id, Role role)
        {
            var electoralOfficer = await _electoralOfficerRepository.GetAsync(x => x.id == id);
            if (electoralOfficer == null)
            {
                return new BaseResponse
                {
                    Message = "Electoral officer not found",
                    Success = false
                };
            }
            if (electoralOfficer.RoleId != role)
            {
                return new BaseResponse
                {
                    Message = "Electoral officer is not a " + role,
                    Success = false
                };
            }
            return new BaseResponse
            {
                Message = "Electoral officer retrieved successfully",
                Success = true
            };
        }

        public async Task<ElectoralOfficerResponseModel> LoginByEmailAndPasswordAsync(string email, string password)
        {
           var electoralOfficer = await _electoralOfficerRepository.GetAsync(x => x.Email == email && x.Password == password);
           if(electoralOfficer != null)
           {
            return new ElectoralOfficerResponseModel
            {
                Message = "Electoral officer logged in successfully",
                Success = true,
                Data = new ElectoralOfficerVM
                {
                    Id = electoralOfficer.id,
                    Email = electoralOfficer.Email,
                    FullName = electoralOfficer.FullName,
                    Password = electoralOfficer.Password,
                    PhoneNumber = electoralOfficer.PhoneNumber,
                    Address = electoralOfficer.Address,
                    Gender = electoralOfficer.Gender,
                    NextOfKin = electoralOfficer.NextOfKin,
                    RoleId = electoralOfficer.RoleId
                }
            };
           }
           return new ElectoralOfficerResponseModel
           {
            Message = "Electoral officer not found",
            Success = false,
           };
        }

        public async Task<BaseResponse> UpdateElectoralOfficerAsync(UpdateElectoralOfficerRequestModel model, int id)
        {
            var electoralOfficer = await _electoralOfficerRepository.GetAsync(x => x.id == id);
            if (electoralOfficer == null)
            {
                return new BaseResponse
                {
                    Message = "Electoral Officer Not Found",
                    Success = false,
                };
            }
            electoralOfficer.FullName = model.FullName ?? electoralOfficer.FullName;
            electoralOfficer.Email = model.Email ?? electoralOfficer.Email;
            electoralOfficer.Password = model.Password ?? electoralOfficer.Password;
            electoralOfficer.PhoneNumber = model.PhoneNumber ?? electoralOfficer.PhoneNumber;
            electoralOfficer.Address = model.Address ?? electoralOfficer.Address;
            electoralOfficer.NextOfKin = model.NextOfKin ?? electoralOfficer.NextOfKin;
            await _electoralOfficerRepository.UpdateAsync(electoralOfficer);
            return new BaseResponse
            {
                Message = "Electoral Officer Succesfully Updated",
                Success = true
            };
        }
    }
}