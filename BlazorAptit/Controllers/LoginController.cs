using BlazorAptit.Data;
using BlazorAptit.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        //private readonly ICategoryRepository _categoryRepository;
        //private readonly ILogger _logger;

        //public CategoriesController(ICategoryRepository categoryRepository, ILoggerFactory loggerFactory)
        //{
        //    this._categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        //    this._logger = loggerFactory.CreateLogger(nameof(CategoriesController));
        //}

        private readonly SchoolContext _context;

        public LoginController(SchoolContext context)
        {
            _context = context;
        }
 
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //[Route("Login")]
        //public ActionResult Login(AptitUser model)  
        //{  
        //   var aptitanswer =  _context.AptitAnswers.FirstOrDefault(m => m.AptitUsers.User_Email   == model.User_Email &&  m.AptitUsers.User_Password == model.User_Password );

        //    if (aptitanswer != null)  
        //    {  
        //        ViewBag.Status = "CORRECT UserNAme and Password";  
        //    }  
        //    else  
        //    {  
        //        ViewBag.Status = "INCORRECT UserName or Password";  
        //    }  
        //    return View(model);  
        //}  

       

        [HttpPost("LoginUser")] 
        public async Task<IActionResult> LoginUser([FromBody] AptitUser model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var aptitanswer =  _context.AptitAnswers.FirstOrDefault(m => m.AptitUsers.User_Email   == model.User_Email &&  m.AptitUsers.User_Password == model.User_Password );

                if (aptitanswer == null)
                {
                    return BadRequest();
                }
                var uri = Url.Link("/Aptit/Pages2", new { ID = aptitanswer.Stage });
                return Created(uri, aptitanswer); // 201 Created
            }
            catch (Exception e)
            {
                //_logger.LogError(e.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var aptituser = _context.AptitUsers.FirstOrDefault(m => m.ID == 1130);
                return Ok(aptituser);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
