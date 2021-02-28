using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using btcm.Models;
using btcm.Common.Caching;

namespace btcm.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHandlesCommand<GetTransactionsCommand, IEnumerable<Transaction>> _createCommand;
        private readonly ICacheProvider _cacheProvider;


        public HomeController(IHandlesCommand<GetTransactionsCommand, IEnumerable<Transaction>> createCommand, ICacheProvider cacheProvider)
        {
            _createCommand = createCommand;
            _cacheProvider= cacheProvider;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Search(SearchInput input)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowEmptyTransactions = false;
                return View("~/Views/Home/Index.cshtml");
            }
            else {
                ViewBag.ShowEmptyTransactions = true;

                var key = string.Format("{0}", input.BlockNumber);

                IEnumerable<Transaction> transactions =  _cacheProvider.Get(key, () => _createCommand.Handle(input?.ConvertHexFromBlockNumber()));

                if (transactions?.Count() > 0) 
                {
                    var model = string.IsNullOrEmpty(input?.Address) ? transactions : transactions.Where(x => x.From == input.Address || x.To == input.Address).Select(y => y);

                    return View("~/Views/Home/Index.cshtml", model.Count() > 0 ? model : null);
                }
                return View("~/Views/Home/Index.cshtml");
            }
        }
    }
}
