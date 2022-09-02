namespace API.Error
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessage(int statusCode)
        {
            return StatusCode switch
            {
                400 => "Bad Request",
                401 => "Not Access",
                404 => "Not Found",
                500 => "Server Error",
                _ => "Unexpected Error"
            };
        }
    }    
}