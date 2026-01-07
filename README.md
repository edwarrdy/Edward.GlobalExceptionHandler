使用方式

program.cs 中使用

app.UseGlobalExceptionHandler();

如果统一接口消息体返回格式

builder.Services.AddControllers(op =>
{
   op.Filters.Add<ApiResponseWrapFilter>();
}); 
