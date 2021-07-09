using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.BooksDisplay.Models
{
    public class CarouselViewModel
    {
        public CarouselViewModel()
        {
            Books = new List<BookDisplay>();
        }
        public List<BookDisplay> Books { get; set; }
    }

    public class BookDisplay
    {
        public BookDisplay()
        {
            Author = new AuthorDetails();
        }
        public string BookTitle { get; set; }
        public IHtmlString BookSummary { get; set; }
        public string BookImgSrc { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Url { get; set; }
        public AuthorDetails Author { get; set; }
    }

}