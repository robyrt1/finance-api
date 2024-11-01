using finance.api.src.category.application.usecases.v1.dtos;
using finance.api.src.category.domain.entity;
using finance.api.src.category.domain.port.usecases.createCategory.v1;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace finance.api.src.category.presentation.v1
{
    [ApiVersion("1.0")]
    [Route("api/category/v{version:apiVersion}")]
    [ApiController]
    public class CreateCategoryController : ControllerBase 
    {
        private ICreatecategoryUseCasePort _createcategoryUseCase;

        public CreateCategoryController(ICreatecategoryUseCasePort createcategoryUseCase)
        {
            _createcategoryUseCase = createcategoryUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> createCategory([FromBody] CreateCategoryDto category, [FromServices] IValidator<CreateCategoryDto> validator) 
        {
            var categoryValidate = validator.Validate(category);
            if (!categoryValidate.IsValid) 
            {
                return BadRequest(categoryValidate.Errors);
            }

            var categoryCreated = await _createcategoryUseCase.execute(category);

            return Created(string.Empty, categoryCreated);
        }
    }
}
