namespace finance.api.src.shared.infratruction.exceptions.http
{
    public class NotFoundException: Exception
    {
        public int StatusCode { get; }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotFoundException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}

