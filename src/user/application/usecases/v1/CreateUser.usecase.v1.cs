using finance.src.shared.infratruction.exceptions.http;
using finance.src.user.domain.port.usecases.CreateUser.v1;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace finance.src.user.application.usecases.v1
{
    public class CreateUserUsecase : ICreateUserPort
    {
        private IUserRepository _userRepository;
        private IPasswordHasher _passwordHasher;

        public CreateUserUsecase(IUserRepository userRepository, IPasswordHasher passwordHasher) { 
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }


        public async Task<UserEntity> execute(IInputCreateUser input)
        {
            try
            {
            var shouldUserByEmail = await _userRepository.GetByEmailAsync(input.Email);

            if (shouldUserByEmail != null)
            {
            
                throw new ConflictException("Usuário já cadastrado");
            }

            input.Password = _passwordHasher.HashPassword(input.Password);

            return await _userRepository.CreateAsync(input);

            }
            catch (Exception ex) { 
                throw;
            }
        }
    }
}

