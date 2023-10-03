namespace EasySolutionHospital.API.Infrastructures
{
    public static class AppSettings
    {
        public static Settings Settings { get; set; } = new();
    }

    public class Settings
    {
        public string AdminPassword { get; set; }
        public string AdministratorPassword { get; set; }
    }
}
