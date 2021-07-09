using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Feature.BooksDisplay.Interfaces;
using Sitecore.Feature.BooksDisplay.Models;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.BooksDisplay.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        /// <summary>
        /// To Get All the Featured Books Items
        /// </summary>
        /// <param name="dataSourceItem"></param>
        /// <returns></returns>
        public CarouselViewModel GetDisplayBooks(Item dataSourceItem)
        {
            CarouselViewModel BooksItems = new CarouselViewModel();
            try
            {
                if (dataSourceItem == null)
                {
                    Log.Error("Item not found", dataSourceItem);
                    throw new ArgumentNullException(nameof(dataSourceItem));
                }
                List<Item> Books = dataSourceItem.GetChildren().Where(x => x.TemplateID ==Foundation.Tenant.Constants.BookDetailsTemplate).ToList();
                foreach(var book in Books)
                {
                    BookDisplay books = new BookDisplay();
                    books.BookTitle = book.Fields[Constants.BookTitle]?.Value;
                    books.BookSummary = new HtmlString(FieldRenderer.Render(book, Constants.BookSummary));
                    books.Category = book.Fields[Constants.BookCategory]?.Value;
                    books.Price = book.Fields[Constants.Price]?.Value;
                    ImageField bookImage = book.Fields[Constants.Image];
                    if (bookImage != null && bookImage.MediaItem != null)
                    {
                        MediaItem image = new MediaItem(bookImage.MediaItem);
                        books.BookImgSrc = Sitecore.StringUtil.EnsurePrefix('/', MediaManager.GetMediaUrl(image));
                    }
                    LinkField email = book.Fields[Constants.EmailId];
                    if (email != null && email.LinkType == Constants.GeneralLinkType.mailto.ToString())
                        books.Author.AuthorEmailId = email.Url;

                    books.Url = Sitecore.Links.LinkManager.GetItemUrl(book);
                    BooksItems.Books.Add(books);
                }
            }
            catch(Exception ex)
            {
                Log.Error("Error occured while getting data", ex.Message);
            }
            return BooksItems;
        }

        /// <summary>
        /// To Get Details about the Specific Book Author
        /// </summary>
        /// <param name="contextItem"></param>
        /// <returns></returns>
        public AuthorDetails GetAuthorDetails(Item contextItem)
        {
            if (contextItem == null)
            {
                Log.Error("Item not found", contextItem);
                throw new ArgumentNullException(nameof(contextItem));
            }
            // return author item
            AuthorDetails authorDetails = new AuthorDetails();
            authorDetails.AuthorName = contextItem?.Fields[Constants.WriterName]?.Value;
            authorDetails.About = contextItem?.Fields[Constants.AboutWriter]?.Value;
            MultilistField OtherBooks = contextItem?.Fields[Constants.OtherBooks];
            Item[] items = OtherBooks?.GetItems();
            foreach (var item in items)
            {
                string bookname = item.Fields[Constants.BookTitle]?.Value;
                authorDetails.OtherBooks.Add(bookname);
            }

            return authorDetails;
        }
    }
}