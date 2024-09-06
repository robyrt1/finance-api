using finance.api.src.auth.domain.entity;
using finance.api.src.auth.domain.port.usecases.login.v1;
using finance.api.src.shared.application.port.services;
using finance.api.src.shared.infratruction.exceptions.http;

namespace finance.api.src.auth.application.usecases.v1
{
    public class LoginUsecaseV1 : ILoginUsecaseV1Port
    {
        private IUserRepository _userRepository;
        private IPasswordHasher _passwordHasher;
        private IJwtService _jwtService;
        public LoginUsecaseV1(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }
        public async Task<string >  execute(IInputLogin input)
        {
            try {
                var shouldUser = await _userRepository.GetByEmailAsync(input.Email);

                if(shouldUser == null)
                {
                    throw new UnauthorizedException("Email ou senha inválido");
                }

                var passwordIsValidade = _passwordHasher.VerifyPassword(input.Password, shouldUser.Password);

                if (passwordIsValidade == false) {
                    throw new UnauthorizedException("Email ou senha inválido");
                }


                return _jwtService.GenerateToken(shouldUser.UserName);
            }
            catch (Exception error){
                throw;
            }
        }
    }
}
