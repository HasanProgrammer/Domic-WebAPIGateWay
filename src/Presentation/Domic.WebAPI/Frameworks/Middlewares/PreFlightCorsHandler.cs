namespace Domic.WebAPI.Frameworks.Middlewares;

public class PreFlightCorsHandler
{
    private readonly RequestDelegate _next;
        
    public PreFlightCorsHandler(RequestDelegate Next) => _next = Next;

    public async Task Invoke(HttpContext Context)
    {
        if (Context.Request.Method == "OPTIONS")
        {
            Context.Response.Headers.Add("Access-Control-Allow-Origin"      , new [] { "*" });
            Context.Response.Headers.Add("Access-Control-Allow-Headers"     , new[] { "Origin, X-Requested-With, Content-Type, Accept" });
            Context.Response.Headers.Add("Access-Control-Allow-Methods"     , new[] { "GET, POST, PUT, PATCH, DELETE, OPTIONS" });
            Context.Response.Headers.Add("Access-Control-Allow-Credentials" , new[] { "true" });

            Context.Response.StatusCode = 200;
        }

        await _next(Context);
    }
}