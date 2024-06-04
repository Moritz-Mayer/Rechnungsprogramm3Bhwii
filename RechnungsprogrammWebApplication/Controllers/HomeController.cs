using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RechnungsprogrammWebApplication.Models;
using RechnungsprogrammWebApplication.Repositories;

namespace RechnungsprogrammWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Produktrepository repo = new Produktrepository();
        List<Produkt> myProdukts = repo.GetAllProdukte();
        
        return View(myProdukts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}