namespace TaskManager.Api.Config
{
    internal class ErrorDetails
    {
        public ErrorDetails()
        {
            
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
