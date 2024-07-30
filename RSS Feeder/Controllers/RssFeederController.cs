using System.Net;
using Microsoft.AspNetCore.Mvc;
using RSS_Feeder.Helper;
using RSS_Feeder.Settings;

namespace RSS_Feeder.Controllers;

public class RssFeederController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.items = RssHelper.Read(SettingsOptions.RssUrl!);
        return View("./Views/Home/Index.cshtml");
    }
    
    [HttpGet]
    public PartialViewResult FetchRSS()
    {
        ViewBag.items = RssHelper.Read(SettingsOptions.RssUrl!);
        return PartialView("_RssItems", ViewBag.items);
    }
}