namespace WebLibrary.BLL.Exceptions
{
    internal class ValidationException : Exception
    {
        public string ExceptionMessage { get; set; }

        public ValidationException(string message) : base(message)
        {
            ExceptionMessage = message;
        }
    }
}
