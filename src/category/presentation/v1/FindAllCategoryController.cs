using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.port.usecases.getAllCategory;
using Microsoft.AspNetCore.Mvc;

namespace finance.api.src.category.presentation.v1
{
    [ApiVersion("1.0")]
    [Route("api/category/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FindAllCategoryController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Category>>> findAll([FromServices] IGetAllCategoryUseCasePort findAllUsecase)
        {
            var categories = await findAllUsecase.execute();
            return Ok(categories);
        }
    }
}
