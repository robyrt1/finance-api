namespace finance.api.src.shared.application.port.services
{
    public interface IJwtService
    {
        public string GenerateToken(string usernaame);

    }
}
