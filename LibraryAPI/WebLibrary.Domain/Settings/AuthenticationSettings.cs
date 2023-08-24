namespace WebLibrary.Domain.Settings
{
    public class AuthenticationSettings
    {
        public string Secret { get; set; } = null!;

        public TimeSpan TokenLifetime { get; set; }
    }
}
