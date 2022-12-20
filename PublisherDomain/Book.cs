using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherDomain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime PublishDate { get; set; }
        public decimal BasePrice { get; set; }
        public Author Author { get; set; } = default!;
        public int AuthorId { get; set; }
    }
}
