using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Spendsmart.Models;
using SpendSmart.Models;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SpendSmartDbContext _context;

        public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();

            var totalExpenses = allExpenses.Sum(x => x.Value);

            ViewBag.Expenses = totalExpenses;
            return View(allExpenses);
        }

        public IActionResult CreateEditExpense(int? id)
        {
            if (id!=null)
            {
                //editing->load an expense by id
                 var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);
                return View(expenseInDb);
            }

            return View();
        }
        public IActionResult deleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
            return  RedirectToAction("Expenses");
        }
        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if(model.Id==0)
            {
                //create
                _context.Expenses.Add(model);
            }
            else
            {
                //editing
                _context.Expenses.Update(model);
            }
           
         
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
