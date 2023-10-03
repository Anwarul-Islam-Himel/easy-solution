namespace EasySolutionHospital.Helper
{
    public class CurrentUserState
    {
        public string FullName { get; private set; }
        public string UserId { get; set; }
        public void SetState(string fullName, string userId)
        {
            FullName = fullName;
            UserId = userId;
        }
    }
}
