namespace WebApp.Models.General
{
    public class MySettings
    {
        public const string SectionName = "MySettings";

        public string EndPointServices { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
