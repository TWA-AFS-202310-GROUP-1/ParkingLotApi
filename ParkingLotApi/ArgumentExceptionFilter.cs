using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ArgumentExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => throw new NotImplementedException();

    public void OnActionExecuted(ActionExecutedContext context)
    {
       if(context.Exception is ArgumentException)
        {
            context.Result = new BadRequestResult();
            context.ExceptionHandled = true;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        
    }
}