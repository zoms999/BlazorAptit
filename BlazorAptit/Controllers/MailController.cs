using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAptit.Models;
using BlazorAptit.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace BlazorAptit.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class MailController : ControllerBase
{
    private readonly IMailService mailService;

    public MailController(IMailService mailService)
    {
        this.mailService = mailService;
    }
    [HttpPost("send")]
    public async Task<IActionResult> SendMail([FromBody]MailRequest request)
    {
        try
        {
            await mailService.SendEmailAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            throw;
        }
            
    }
    [HttpPost("welcome")]
    public async Task<IActionResult> SendWelcomeMail([FromBody] WelcomeRequest request)
    {
        try
        {
            await mailService.SendWelcomeEmailAsync(request);
            return new JsonResult("OK");
        }
        catch (Exception ex)
        {

                return new JsonResult(ex.Message.ToString());
            }

    }

        [HttpPost("welcome2")]
        public async Task<IActionResult> SendWelcomeMail2()
        {
            try
            {
                return new JsonResult("OK");
            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message.ToString());
            }

        }
    }
}