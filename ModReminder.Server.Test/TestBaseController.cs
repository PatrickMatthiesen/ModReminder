using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace ModReminder.Server.Test;

public class TestBaseController<S>
{
    protected Mock<ILogger<S>> logger = new();

    protected static T? GetCreatedResultContent<T>(ActionResult<T> result)
    {
        return (T?) (result.Result as CreatedAtRouteResult)?.Value;
    }

    protected static T? GetOkResultContent<T>(ActionResult<T> result)
    {
        return (T?) (result.Result as OkObjectResult)?.Value;
    }
}