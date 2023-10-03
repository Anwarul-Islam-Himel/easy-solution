using EasySolutionHospital.Shared.Enum;

namespace EasySolutionHospital.Shared.ResponseModel
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public UserRoleType UserRole { get; set; }
    }
}
