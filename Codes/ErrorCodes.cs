namespace Edward.GlobalExceptionHandler.Codes
{
    public static class ErrorCodes
    {
        // 成功
        public const string Success = "0";

        // 客户端错误（4xx）
        public const string ValidationError = "ERR_VALIDATION";   // 参数校验失败
        public const string NotFound = "ERR_NOT_FOUND";           // 资源不存在
        public const string Unauthorized = "ERR_UNAUTHORIZED";    // 未登录
        public const string Forbidden = "ERR_FORBIDDEN";          // 无权限

        // 业务错误（冲突、状态不允许等）
        public const string BusinessError = "ERR_BUSINESS";       // 业务逻辑错误
        public const string Conflict = "ERR_CONFLICT";            // 资源冲突

        // 服务端错误（5xx）
        public const string InternalError = "ERR_INTERNAL";       // 未知异常
        public const string DatabaseError = "ERR_DB";             // 数据库异常
        public const string ExternalServiceError = "ERR_EXTERNAL";// 外部服务异常
    }    

}
