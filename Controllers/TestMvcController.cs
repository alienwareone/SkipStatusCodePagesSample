using Microsoft.AspNetCore.Mvc;

namespace SkipStatusCodePagesSample.Controllers;

[Route(template: "")]
[Route(template: "test-mvc-controller")]
public class TestMvcController
{
    public IActionResult Test(bool notFound)
    {
        if (notFound)
        {
            return new StatusCodeResult(404);
        }

        return new ContentResult
        {
            ContentType = "text/html",
            Content = """
                <h1>HTML response from TestMvcController</h1>
                <ul>
                <li><a href="/test-api-controller">test-api-controller - JSON response</a></li>
                <li><a href="/test-api-controller?notFound=true">test-api-controller - 404 status code response</a></li>
                <li><a href="/test-mvc-controller?notFound=true">test-mvc-controller - 404 status code response</a></li>
                </ul>
                """
        };
    }
}