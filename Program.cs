using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMvc()
    .ConfigureApiBehaviorOptions(x =>
    {
        x.SuppressModelStateInvalidFilter = true;
        x.SuppressMapClientErrors = true;
    });

var app = builder.Build();

app.UseRouting();

// Call after UseRouting to respect the current endpoint ISkipStatusCodePagesMetadata:
app.UseStatusCodePagesWithReExecute("/status-codes/{0}");

// Works as expected:
app.MapControllers().SkipStatusCodePagesForApiControllers();

// This will also skip the StatusCodePagesMiddleware for MVC Controllers
// which is not desired (just skip for ApiControllerAttribute).
// app.MapControllers().WithMetadata(new SkipStatusCodePagesAttribute());

app.Run();