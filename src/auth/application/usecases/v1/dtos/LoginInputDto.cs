using finance.api.src.auth.domain.port.usecases.login.v1;

namespace finance.api.src.auth.application.usecases.v1.dtos
{
    public class LoginInputDto : IInputLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginInputDto() { }
    }
}
