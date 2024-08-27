using finance.src.shared.infratruction.exceptions.http;
using finance.src.user.domain.port.usecases.CreateUser.v1;
using Microsoft.AspNetCore.Http.HttpResults;


namespace finance.src.user.application.usecases.v1
{
    public class CreateUserUsecase : ICreateUserPort
    {
        private IUserRepository _userRepository;

        public CreateUserUsecase(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }
        public async Task<UserEntity> execute(IInputCreateUser input)
        {
            try
            {
            var shouldUserByEmail = await _userRepository.GetByEmailAsync(input.Email);
            if (shouldUserByEmail != null)
            {
                throw new NotFoundException("Usuário já cadastrado");
            }

            return await _userRepository.CreateAsync(input);

            }
            catch (Exception ex) { 
                throw ex;
            }
        }
    }
}

