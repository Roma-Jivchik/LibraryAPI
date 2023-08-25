namespace WebLibrary.Domain.Settings
{
    public class AuthSettings
    {
        public string Secret { get; set; } = null!;

        public TimeSpan TokenLifetime { get; set; }
    }
}
