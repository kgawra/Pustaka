using Sitecore.Feature.BooksDisplay.Interfaces;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Feature.BooksDisplay.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository _booksRepository;
        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        /// <summary>
        /// GET: Books to display
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = _booksRepository.GetDisplayBooks(RenderingContext.Current.Rendering.Item);
            return View("BooksCarousel",model);
        }

        /// <summary>
        /// Get: About Author of the certain book
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutAuthor()
        {
            var model = _booksRepository.GetAuthorDetails(Context.Item);
            return View("AboutAuthor", model);
        }
    }
}