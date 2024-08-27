using finance.api.src.user.application.usecases.v1.dtos;
using finance.src.user.domain.port.usecases.CreateUser.v1;
using Microsoft.AspNetCore.Mvc;

namespace finance.src.user.presentation.v1
{
    [Route("api/user/v1/[controller]")]
    [ApiController]
    public class CreateUserController: ControllerBase
    {
        private ICreateUserPort _createUserPort;
        public CreateUserController(ICreateUserPort createUserPort)
        {
            _createUserPort = createUserPort;
        }

        [HttpPost]
        public async Task<ActionResult<UserEntity>> CreateUser([FromBody] CreateUserDto user)
        {
            Console.WriteLine("Controller method reached");
            //_ = new CreateUserDto
            //{
            //    UserName = user.UserName,
            //    Email = user.Email,
            //    Password = user.Password
            //};

            var result =  await _createUserPort.execute(user);
            return Created(string.Empty, result);
        }


    }
}
