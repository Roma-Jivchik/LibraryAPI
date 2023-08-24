namespace WebLibrary.BLL.Exceptions
{
    public class ValidationExceptionResult : Exception
    {
        public string ExceptionMessage { get; set; }

        public ValidationExceptionResult(string message) : base(message)
        {
            ExceptionMessage = message;
        }
    }
}
