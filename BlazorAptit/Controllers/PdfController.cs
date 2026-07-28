using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using BlazorDemos.Data.FileFormats.PDF;
using BlazorAptit.Models;
using System.Collections.Generic;

namespace BlazorAptit.Controllers
{
    [ApiController]
    [Route("api/pdf")]
    public class PdfController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public PdfController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // 성향 PDF (DB X)
        [HttpPost("tendency")]
        // 필요하면 용량 제한 늘리기(예: 50MB)
        [RequestSizeLimit(50 * 1024 * 1024)]
        public IActionResult DownloadTendency([FromBody] PdfRequest req)
        {
            if (req == null || req.UserReplyViews == null || req.UserReplyViews.Count == 0)
                return BadRequest("UserReplyViews is empty");

            var service = new RearrangePagesService(_env, req.UserReplyViews);
            using var ms = service.CreatePdfDocument();
            ms.Position = 0;

            var fileName = $"(성향){SafeFileName(req.GroupName)}_{SafeFileName(req.UserName)}.pdf";
            return File(ms.ToArray(), "application/pdf", fileName);
        }

        // 교과목 PDF (DB X)
        [HttpPost("subject")]
        [RequestSizeLimit(50 * 1024 * 1024)]
        public IActionResult DownloadSubject([FromBody] PdfRequest req)
        {
            if (req == null || req.UserReplyViews == null || req.UserReplyViews.Count == 0)
                return BadRequest("UserReplyViews is empty");

            var service = new RearrangePagesService(_env, req.UserReplyViews);
            using var ms = service.CreatePdfDocument_Subject();
            ms.Position = 0;

            var fileName = $"(교과목){SafeFileName(req.GroupName)}_{SafeFileName(req.UserName)}.pdf";
            return File(ms.ToArray(), "application/pdf", fileName);
        }

        private static string SafeFileName(string input)
        {
            input = (input ?? "").Trim();
            input = Regex.Replace(input, @"[\\/:*?""<>|]", "_");
            return input.Length == 0 ? "file" : input;
        }
    }
    public class PdfRequest
    {
        public string GroupName { get; set; } = "group";
        public string UserName { get; set; } = "user";
        public List<UserReplyView> UserReplyViews { get; set; } = new();
    }

}
