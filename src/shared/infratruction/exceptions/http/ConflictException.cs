namespace finance.src.shared.infratruction.exceptions.http
{
    public class ConflictException: Exception
    {
        public int StatusCode { get; }

        public ConflictException(string message) : base(message)
        {
        }

        public ConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ConflictException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
