using finance.api.src.category.application.usecases.v1.dtos;
using finance.api.src.category.domain.port.usecases.createSubCategory.v1;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace finance.api.src.category.presentation.v1
{
    [ApiVersion("1.0")]
    [Route("api/sub-category/v{version:apiVersion}")]
    [ApiController]
    public class CreateSubCategoryController : ControllerBase
    {
        private ICreateSubCategoryUseCaseV1 _createSubCategoryUseCase;
        public CreateSubCategoryController(ICreateSubCategoryUseCaseV1 createSubCategoryUseCase) 
        {
            _createSubCategoryUseCase = createSubCategoryUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory([FromBody] CreateSubCategoryDto subCategory, [FromServices] IValidator<CreateSubCategoryDto> validator) 
        {
            var categoryValidate = validator.Validate(subCategory);
            if (!categoryValidate.IsValid)
            {
                return BadRequest(categoryValidate.Errors);
            }

            var subCategoryCreated = await _createSubCategoryUseCase.execute(subCategory);

            return Created(string.Empty, subCategoryCreated);
        }
    }
}
