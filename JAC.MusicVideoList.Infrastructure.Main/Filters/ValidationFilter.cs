using System;
using System.Threading.Tasks;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Transversal.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JAC.MusicVideoList.Infrastructure.Main.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public ValidationFilter()
        {
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {

                context.Result = new BadRequestObjectResult(context.ModelState);
                // context.Result = new BadRequestObjectResult(Response<User>.CreateUnsuccessful("Bad Request", null));
                return;
            }

            await next();
        }
    }
}
