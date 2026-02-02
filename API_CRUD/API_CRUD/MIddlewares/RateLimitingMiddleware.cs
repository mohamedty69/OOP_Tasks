namespace API_CRUD.MIddlewares
{
    public class RateLimitingMiddleware
    {
        private RequestDelegate _next;
        private ILogger<RateLimitingMiddleware> _logger;
        private static int count = 0;
        private static DateTime limitdate = DateTime.Now;

        public RateLimitingMiddleware(RequestDelegate next, ILogger<RateLimitingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            if (DateTime.Now.Subtract(limitdate).Seconds > 10)
            {
                count = 1;
                await _next(context);
            }
            else
            {
                if (count < 5)
                {
                    count++;
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = 429; // Too Many Requests
                    await context.Response.WriteAsync("Rate limit exceeded. Try again later.");
                    _logger.LogWarning("Rate limit exceeded for IP: {IP}", context.Connection.RemoteIpAddress);
                }
            }
        }
    }
}
