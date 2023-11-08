using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Filters
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        int IOrderedFilter.Order => int.MaxValue - 10;
        public int Order => throw new NotImplementedException();

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is InValidCapacityException inValidCapacityException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
            else if(context.Exception is InValidIdException inValidIdException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
            else if(context.Exception is ParkingNotFoundException parkingNotFoundException)
            {
                context.Result = new NotFoundResult();
                context.ExceptionHandled = true;
            }
            else if(context.Exception is PageOutOfIndexException pageOutOfIndexException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
