
namespace finance.api.src.user.application.usecases.v1.dtos
{
    public class CreateUserDto: IInputCreateUser
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public CreateUserDto() { }
    }
}
