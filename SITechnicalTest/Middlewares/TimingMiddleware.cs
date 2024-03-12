using Microsoft.AspNetCore.Server.HttpSys;

namespace SITechnicalTest.Middlewares
{
    public class TimingMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public TimingMiddleware(ILogger<TimingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;   
            _next = next;   
        }


        public async Task Invoke(HttpContext context) 
        {
            var start = DateTime.UtcNow;
            await _next.Invoke(context);
            _logger.LogInformation($"Request {context.Request.Path} : {(DateTime.UtcNow - start).TotalMilliseconds} ms");
        }
    }

    public static class TimingExtensions
    {
        public static IApplicationBuilder UseTiming(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TimingMiddleware>();
        }

        public static void AddTiming(this IServiceCollection services)
        {
            //services.AddTransient<ITiming, SomeTiming>
        }
    }
}
