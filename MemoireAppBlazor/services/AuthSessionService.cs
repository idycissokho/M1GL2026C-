namespace MemoireAppBlazor.Services
{
    public class AuthSessionService
    {
        private const string TokenKey = "jwt_token";
        private const string EmailKey = "user_email";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated => !string.IsNullOrEmpty(GetToken());

        public string? GetToken() => _httpContextAccessor.HttpContext?.Session.GetString(TokenKey);

        public string? GetEmail() => _httpContextAccessor.HttpContext?.Session.GetString(EmailKey);

        public void SetSession(string token, string email)
        {
            _httpContextAccessor.HttpContext?.Session.SetString(TokenKey, token);
            _httpContextAccessor.HttpContext?.Session.SetString(EmailKey, email);
        }

        public void ClearSession()
        {
            _httpContextAccessor.HttpContext?.Session.Clear();
        }
    }
}
