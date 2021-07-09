using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.BooksDisplay.Models
{
    public class AuthorDetails
    {
        public AuthorDetails()
        {
            OtherBooks = new List<string>();
        }
        public string AuthorName { get; set; }
        public string AuthorEmailId { get; set; }
        public string About { get; set; }
        public List<string> OtherBooks { get; set; }
    }
}