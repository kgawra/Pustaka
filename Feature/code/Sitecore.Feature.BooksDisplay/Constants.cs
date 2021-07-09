using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.BooksDisplay
{
    public class Constants
    {

        //Book Fields Names
        public const string BookTitle = "Title";
        public const string BookDescription = "Description";
        public const string BookSummary = "Summary";
        public const string BookCategory = "Category";
        public const string Price = "Price";
        public const string WriterName = "Name";
        public const string AboutWriter = "About";
        public const string EmailId = "Email Id";
        public const string Image = "image";
        public const string OtherBooks = "Other Books";

        public enum GeneralLinkType
        {
            mailto,
            external,
            media

        }

    }
}