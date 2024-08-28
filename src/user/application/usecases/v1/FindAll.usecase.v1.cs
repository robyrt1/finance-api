using finance.api.src.shared.infratruction.exceptions.http;
using finance.src.shared.infratruction.exceptions.http;
using finance.src.user.domain.port.usecases.findAll.v1;

namespace finance.src.user.application.usecases.v1
{
    public class FindAllUseCase : IFindAll
    {
        private IUserRepository _userRepository;
        private readonly ILogger<FindAllUseCase> _logger;

        public FindAllUseCase(ILogger<FindAllUseCase> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<UserEntity>> execute()
        {
            var users = await _userRepository.GetAllAsync();

            if (users == null || !users.Any())
            {
                _logger.LogWarning("No users found.");
                throw new NotFoundException("No users found.");
            }

            return (List<UserEntity>)users;
        }
    }
}
