namespace David_Studio_Server.Models
{
    public class ResponseModel
    {
        public ResponseModel(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public string Message { get; set; } = null!;
        public int StatusCode { get; set; }
    }
}
