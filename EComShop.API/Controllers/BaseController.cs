using AutoMapper;
using EComShop.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
    }
}
