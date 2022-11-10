using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;
using VottingAPI.Interface.Repository;
using VottingAPI.Interface.Services;
using VottingAPI.Model;
using VottingAPI.ViewModel;

namespace VottingAPI.Implementation.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository; 
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentService(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<StudentResponseModel> ApproveStudentAsync(int id)
        {
            var student = await _studentRepository.GetAsync(x => x.id == id);
            if (student == null)
            {
                return new StudentResponseModel
                {
                    Success = false,
                    Message = "Student not found"
                };
            }
            student.isApproved = true;
            await _studentRepository.UpdateAsync(student);
            return new StudentResponseModel
            {
                Success = true,
                Message = "Student approved successfully"
            };
        }

        public async Task<BaseResponse> CreateStudentAsync(CreateStudentRequestModel model)
        {
            var student = await _studentRepository.GetAsync(x => x.MatricNo == model.MatricNo);
            if (student != null)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Student already exist"
                };
            }
            var imageName = "";
            if(model.ImageUrl != null)
            {
                var imgPath = _webHostEnvironment.WebRootPath;
                var imagePath  = Path.Combine(imgPath,"images");
                Directory.CreateDirectory(imagePath);
                var imageType = model.ImageUrl.ContentType.Split('/')[1];
                imageName = $"{Guid.NewGuid()}.{imageType}";
                var fullPath = Path.Combine(imagePath,imageName);
                using(var fileStream = new FileStream(fullPath,FileMode.Create))
                {
                    model.ImageUrl.CopyTo(fileStream);
                }
            }
            var newStudent = new Student
            {
                FullName = model.FullName,
                MatricNo = model.MatricNo,
                Email = model.Email,
                Password = model.Password,
                isApproved = false,
                Address = model.Address,
                Level = model.Level,
                Course = model.Course,
                NextOfKin = model.NextOfKin,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                Grade = model.Grade,
                ImageUrl = imageName
            };
            await _studentRepository.AddAsync(newStudent);
            return new BaseResponse
            {
                Success = true,
                Message = "Student created successfully"
            };
        }

        public async Task<BaseResponse> DeleteStudnetAsync(int id)
        {
            var student = await _studentRepository.GetAsync(x => x.IsDeleted == false && x.id == id);
            if (student == null)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Student not found"
                };
            }
            await _studentRepository.DeleteAsync(student);
            return new BaseResponse
            {
                Success = true,
                Message = "Student deleted successfully"
            };
        }

        public async Task<StudentsResponseModel> GetAllStudentAsync()
        {
            var student = await _studentRepository.GetAllAsync();
            if (student.Count() == 0)
            {
                return new StudentsResponseModel
                {
                    Message = "Student Not Found",
                    Success = false
                };
            }
            return new StudentsResponseModel
            {
                Data = student.Select(x => new StudentVM
                {
                    Id = x.id,
                    FullName = x.FullName,
                    Email = x.Email,
                    Password = x.Password,
                    Address = x.Address,
                    Course = x.Course,
                    PhoneNumber = x.PhoneNumber,
                    Level = x.Level,
                    Gender = x.Gender,
                    Grade = x.Grade,
                    NextOfKin = x.NextOfKin,
                    MatricNo = x.MatricNo
                }).ToList(),
            };
        }

        public async Task<StudentResponseModel> LoginByMatricNoAndPasswordAsync(string MatricNo, string password)
        {
            var student = await _studentRepository.GetAsync(x => x.MatricNo == MatricNo && x.Password == password);
            if (student != null)
            {
                return new StudentResponseModel
                {
                    Success = true,
                    Message = "Login successful",
                    Data = new StudentVM
                    {
                        Id = student.id,
                        FullName = student.FullName,
                        Email = student.Email,
                        Password = student.Password,
                        Address = student.Address,
                        Course = student.Course,
                        MatricNo = student.MatricNo,
                        NextOfKin = student.NextOfKin,
                        Level = student.Level,
                        PhoneNumber = student.PhoneNumber,
                        Gender = student.Gender,
                        Grade = student.Grade
                    }
                };
            }
            return new StudentResponseModel
            {
                Success = false,
                Message = "Login failed"
            };
        }

        public async Task<BaseResponse> UpdateStudentAsync(UpdateStudentRequestModel model, int id)
        {
            var student = await _studentRepository.GetAsync(x => x.id == model.Id);
            if (student == null)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Student not found"
                };
            }
            student.FullName = model.FullName ?? student.FullName;
            student.Email = model.Email ?? student.Email;
            student.Password = model.Password ?? student.Password;
            student.Level = model.Level;
            student.Course = model.Course ?? student.Course;
            student.NextOfKin = model.NextOfKin ?? student.NextOfKin;
            student.PhoneNumber = model.PhoneNumber ?? student.PhoneNumber;
            student.Address = model.Address ?? student.Address;
            student.Gender = model.Gender;
            await _studentRepository.UpdateAsync(student);
            return new BaseResponse
            {
                Success = true,
                Message = "Student updated successfully"
            };
        } 
    }
}