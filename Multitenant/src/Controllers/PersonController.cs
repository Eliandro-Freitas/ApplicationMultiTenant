using EFCore.Multitenant.Domain;
using EFCore.Multitenant.Infra;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Multitenant.Controllers;
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [HttpGet("v1/{tenantId}/peoples")]
    public IEnumerable<Person?> Get([FromServices]ApplicationContext context)
    {
        var people = context.Peoples?.ToArray();
        return people;
    }
}