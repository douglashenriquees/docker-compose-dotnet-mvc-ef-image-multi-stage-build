using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Repositories;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository _repository;
    private string message;

    public HomeController(ILogger<HomeController> logger, IRepository repository, IConfiguration configuration)
    {
        _logger = logger;
        _repository = repository;
        message = $"Docker - ({configuration["HOSTNAME"]})";
    }

    public IActionResult Index()
    {
        ViewBag.Message = message;
        return View(_repository.Produtos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}