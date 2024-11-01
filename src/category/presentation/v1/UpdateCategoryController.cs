using finance.api.src.category.application.usecases.v1.dtos;
using finance.api.src.category.domain.port.usecases.updateCategory.v1;
using finance.api.src.category.domain.port.usecases.updateCategory.v1.type;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace finance.api.src.category.presentation.v1
{
    [ApiVersion("1.0")]
    [Route("api/category/v{version:apiVersion}")]
    [ApiController]
    public class UpdateCategoryController : ControllerBase
    {
        private IUpdateCategoryUseCasePort _updateCategoryUseCase;

        public UpdateCategoryController(IUpdateCategoryUseCasePort updateCategoryUseCase) 
        {
            _updateCategoryUseCase = updateCategoryUseCase;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryDto category, [FromServices] IValidator<UpdateCategoryDto> validator) 
        {
            var validationResult = await validator.ValidateAsync(category);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _updateCategoryUseCase.execute(category);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Category not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the category.");
            }
        }
    }
}
