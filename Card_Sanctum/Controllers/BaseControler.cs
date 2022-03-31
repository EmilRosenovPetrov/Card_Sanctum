namespace Card_Sanctum.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BaseControler : Controller
    {       
    }
}
