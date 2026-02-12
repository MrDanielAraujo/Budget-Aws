using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.ModelsQuery;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComboSeparadorController : CrudController<ComboSeparador , ComboSeparadorQuery>
{

}