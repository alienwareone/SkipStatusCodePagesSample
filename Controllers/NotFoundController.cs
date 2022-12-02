using Microsoft.AspNetCore.Mvc;

namespace SkipStatusCodePagesSample.Controllers;

[Route(template: "status-codes/{statusCode:int:range(400,404)}")]
public class NotFoundMvcController
{
    public IActionResult NotFound(int statusCode)
    {
        return new ContentResult
        {
            ContentType = "text/html",
            Content = $"<h1>{statusCode} NotFound - HTML response</h1>"
        };
    }
}