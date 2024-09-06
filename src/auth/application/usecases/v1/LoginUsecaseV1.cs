using finance.api.src.auth.domain.entity;
using finance.api.src.auth.domain.port.usecases.login.v1;
using finance.api.src.shared.application.port.services;

namespace finance.api.src.auth.application.usecases.v1
{
    public class LoginUsecaseV1 : ILoginUsecaseV1Port
    {
        private IUserRepository _userRepository;
        private IPasswordHasher _passwordHasher;
        private IJwtService _jwtService;
        private LoginUsecaseV1(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }
        public async Task<string >  execute(AuthEntity input)
        {
            try {
                var shouldUser = await _userRepository.GetByEmailAsync(input.Email);

                if(shouldUser == null)
                {

                }

                var passwordIsValidade = _passwordHasher.VerifyPassword(input.Password, shouldUser.Password);

                if (passwordIsValidade == false) { 
                }


                return _jwtService.GenerateToken(shouldUser.UserName);
            }
            catch (Exception error){
                throw;
            }
        }
    }
}
