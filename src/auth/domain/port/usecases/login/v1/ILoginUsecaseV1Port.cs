using finance.api.src.auth.domain.entity;

namespace finance.api.src.auth.domain.port.usecases.login.v1
{
    public interface ILoginUsecaseV1Port
    {
        public Task<string> execute(AuthEntity input);
    }
}
