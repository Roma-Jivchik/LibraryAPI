namespace WebLibrary.Domain.Settings
{
    public class AuthorizationSettings
    {
        public string Secret { get; set; } = null!;

        public TimeSpan TokenLifetime { get; set; }
    }
}
