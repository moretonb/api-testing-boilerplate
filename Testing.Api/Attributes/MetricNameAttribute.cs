using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Testing.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MetricNameAttribute : ActionFilterAttribute
    {
        private readonly string _name;

        public MetricNameAttribute(string name)
        {
            _name = name;
        }

        public override void OnActionExecuting(ActionExecutingContext c)
        {
            c.HttpContext.Request.HttpContext.Items["MetricName"] = _name;
        }
    }
}