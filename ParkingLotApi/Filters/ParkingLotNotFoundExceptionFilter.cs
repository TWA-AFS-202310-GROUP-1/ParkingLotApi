using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Filters
{
    public class ParkingLotNotFoundExceptionFilter : IActionFilter, IOrderedFilter
    {
        int IOrderedFilter.Order => int.MaxValue - 10;

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ParkingLotNotFoundException parkingLotNotFoundException)
            {
                context.Result = new NotFoundResult();
                context.ExceptionHandled = true;
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
