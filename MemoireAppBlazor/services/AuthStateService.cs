namespace MemoireAppBlazor.Services
{
    public class AuthStateService
    {
        public bool IsAuthenticated { get; private set; }
        public string Email { get; private set; } = "";
        public string Token { get; private set; } = "";

        public void SetAuthenticated(string token, string email)
        {
            IsAuthenticated = true;
            Token = token;
            Email = email;
        }

        public void Clear()
        {
            IsAuthenticated = false;
            Token = "";
            Email = "";
        }
    }
}
