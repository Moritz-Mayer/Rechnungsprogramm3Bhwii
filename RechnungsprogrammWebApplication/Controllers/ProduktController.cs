using Microsoft.AspNetCore.Mvc;
using RechnungsprogrammWebApplication.Models;
using RechnungsprogrammWebApplication.Repositories;

namespace RechnungsprogrammWebApplication.Controllers;

public class ProduktController : Controller
{
    // GET
    public IActionResult Index()
    {
        Produktrepository repo = new Produktrepository();
        List<Produkt> myProdukts = repo.GetAllProdukte();
        
        return View(myProdukts);
    }

    public IActionResult New()
    {
        return View();
    }
}