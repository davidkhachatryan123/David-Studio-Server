namespace David_Studio_Server.ViewModels
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

        public static ResponseModel GetResponse(
            bool IsSuccess,
            string OnSuccessMsg, int OnSuccessCode,
            string OnErrorMessage, int OnErrorCode)
        {
            if (IsSuccess)
                return new ResponseModel(OnSuccessMsg, OnSuccessCode);
            else
                return new ResponseModel(OnErrorMessage, OnErrorCode);
        }
    }
}
