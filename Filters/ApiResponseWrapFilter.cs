using Edward.GlobalExceptionHandler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Edward.GlobalExceptionHandler.Filters;

/// <summary>
/// 自动包装控制器返回值为统一格式 ApiResponse
/// </summary>
public class ApiResponseWrapFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        // 如果已经是 ApiResponse，不再包装
        if (context.Result is ObjectResult objectResult)
        {
            if (objectResult.Value is ApiResponse)
            {
                await next();
                return;
            }

            // 包装普通返回值
            var wrapped = ApiResponse.Ok(objectResult.Value);
            context.Result = new ObjectResult(wrapped)
            {
                StatusCode = objectResult.StatusCode
            };
        }
        else if (context.Result is EmptyResult)
        {
            // 空返回也包装
            context.Result = new ObjectResult(ApiResponse.Ok());
        }

        await next();
    }
}
