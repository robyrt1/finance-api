namespace finance.api.src.auth.domain.port.usecases.login.v1
{
    public interface IInputLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
