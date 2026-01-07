using Edward.GlobalExceptionHandler.Codes;

namespace Edward.GlobalExceptionHandler.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Code { get; set; } = ErrorCodes.Success;
        public string Message { get; set; } = "OK";
        public object? Data { get; set; }

        public static ApiResponse Ok(object? data = null, string? message = null)
            => new()
            {
                Success = true,
                Code = ErrorCodes.Success,
                Message = message ?? "OK",
                Data = data
            };

        public static ApiResponse Fail(string code, string message, object? data = null)
            => new()
            {
                Success = false,
                Code = code,
                Message = message,
                Data = data
            };
    }
}
