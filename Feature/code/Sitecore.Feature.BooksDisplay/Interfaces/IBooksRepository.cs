using Sitecore.Data.Items;
using Sitecore.Feature.BooksDisplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Feature.BooksDisplay.Interfaces
{
    public interface IBooksRepository
    {
        CarouselViewModel GetDisplayBooks(Item dataSourceItems);
        AuthorDetails GetAuthorDetails(Item contextItem);
    }
}
