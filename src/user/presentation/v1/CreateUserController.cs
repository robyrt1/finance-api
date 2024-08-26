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
        public async Task<ActionResult<IEnumerable<UserEntity>>> CreateUser(IInputCreateUser user)
        {
            Console.WriteLine("Controller method reached");
            var newUser =  await _createUserPort.execute(user);
            return Ok(newUser);
        }


    }
}
