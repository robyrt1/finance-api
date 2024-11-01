using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.port.repository;
using finance.api.src.category.domain.port.usecases.getAllCategory;
using finance.api.src.shared.infratruction.exceptions.http;

namespace finance.api.src.category.application.usecases.v1
{
    public class FindAllCategoryUseCaseV1 : IGetAllCategoryUseCasePort
    {
        private ICategoryRepositoryPort _repositoryPort;
        private readonly ILogger<FindAllCategoryUseCaseV1> _logger;

        public FindAllCategoryUseCaseV1(ILogger<FindAllCategoryUseCaseV1> logger, ICategoryRepositoryPort repositoryPort) 
        {
            _repositoryPort = repositoryPort;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
        }


        public async Task<List<Category>> execute()
        {
            var categories = await _repositoryPort.GetAllAsync();

            if (categories == null || !categories.Any())
            {
                _logger.LogWarning("Not found Categories.");
                throw new NotFoundException("Not found Categories.");
            }

            return (List<Category>)categories;
        }
    }
}
