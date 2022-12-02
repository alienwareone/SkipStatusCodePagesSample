using Microsoft.AspNetCore.Mvc;

namespace SkipStatusCodePagesSample.Controllers;

[ApiController]
[Route("test-api-controller")]
public class TestApiController
{
    public IActionResult Test(bool notFound = false)
    {
        if (notFound)
        {
            return new StatusCodeResult(404);
        }

        return new JsonResult("JSON response from TestApiController");
    }
}