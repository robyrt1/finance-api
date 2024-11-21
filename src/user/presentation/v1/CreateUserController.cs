using finance.api.src.user.application.usecases.v1.dtos;
using finance.src.user.domain.port.usecases.CreateUser.v1;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace finance.src.user.presentation.v1
{
    [ApiVersion("1.0")]
    [Route("api/user/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CreateUserController: ControllerBase
    {
        private ICreateUserPort _createUserPort;
        public CreateUserController(ICreateUserPort createUserPort)
        {
            _createUserPort = createUserPort;
        }

        [HttpPost]
        public async Task<ActionResult<UserEntity>> CreateUser([FromBody] CreateUserDto user, [FromServices] IValidator<CreateUserDto> validator)
        {

            var userValidator = await validator.ValidateAsync(user);

            if (userValidator.IsValid is false) {
                return BadRequest(userValidator.Errors);
            }
            var result =  await _createUserPort.execute(user);
            return Created(string.Empty, result);
        }


    }
}
