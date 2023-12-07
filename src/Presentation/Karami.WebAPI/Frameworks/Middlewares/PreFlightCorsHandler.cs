namespace Karami.WebAPI.Frameworks.Middlewares;

public class PreFlightCorsHandler
{
    private readonly RequestDelegate _Next;
    private readonly IConfiguration  _Configuration;
        
    public PreFlightCorsHandler(RequestDelegate Next, IConfiguration Configuration)
    {
        _Next          = Next;
        _Configuration = Configuration;
    }

    public async Task Invoke(HttpContext Context)
    {
        if (Context.Request.Method == "OPTIONS")
        {
            Context.Response.Headers.Add("Access-Control-Allow-Origin"      , new[] { "" });
            Context.Response.Headers.Add("Access-Control-Allow-Headers"     , new[] { "Origin, X-Requested-With, Content-Type, Accept" });
            Context.Response.Headers.Add("Access-Control-Allow-Methods"     , new[] { "GET, POST, PUT, PATCH, DELETE, OPTIONS" });
            Context.Response.Headers.Add("Access-Control-Allow-Credentials" , new[] { "true" });

            Context.Response.StatusCode = 200;
        }

        await _Next(Context);
    }
}