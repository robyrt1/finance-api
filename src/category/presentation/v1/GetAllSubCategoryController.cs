using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.objectValues;
using finance.api.src.category.domain.port.usecases.getAllCategory;
using finance.api.src.category.domain.port.usecases.getAllSubCategory.v1;
using Microsoft.AspNetCore.Mvc;

namespace finance.api.src.category.presentation.v1
{
    [ApiVersion("1.0")]
    [Route("api/sub-category/v{version:apiVersion}")]
    [ApiController]
    public class GetAllSubCategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SubCategory>>> findAll([FromServices] IGetAllSubCategoryUseCaseV1 getAllSubCategoryUseCaseV1)
        {
            var categories = await getAllSubCategoryUseCaseV1.execute();
            return Ok(categories);
        }
    }
}
