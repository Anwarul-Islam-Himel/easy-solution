namespace EasySolutionHospital.Helper
{
    public class CurrentUserState
    {
        public string FullName { get; private set; }
        public string UserId { get; set; }
        public int? UserAmount { get; set; }
        public string UserRole { get; set; }    
        public void SetState(string fullName, string userId, string userAmount, string userRole)
        {
            FullName = fullName;
            UserId = userId;
            UserAmount = Int32.Parse(userAmount);
            UserRole = userRole;
        }

        public void Recharge(int? amount)
        {
            UserAmount = amount;
        }
    }
}
