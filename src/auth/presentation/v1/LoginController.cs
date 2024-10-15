using finance.api.src.auth.application.usecases.v1.dtos;
using finance.api.src.auth.domain.port.usecases.login.v1;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace finance.api.src.auth.presentation.v1
{
    [ApiVersion("1.0")]
    [Route("api/auth/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> LoginUseCase(
            [FromServices] ILoginUsecaseV1Port loginUsecaseV1Port,
            [FromServices] IValidator<LoginInputDto> validator,
            [FromBody] LoginInputDto body
        )
        {
            var input = await validator.ValidateAsync(body);

            if (!input.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await loginUsecaseV1Port.execute(body);

            return Ok(token);
        }
    }
}
