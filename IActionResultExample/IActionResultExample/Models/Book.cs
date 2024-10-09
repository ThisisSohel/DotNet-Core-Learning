using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Models
{
    public class Book
    {
        //[FromQuery] I can also enfore the attribute for FromQuery
        public int? BookId { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book Id: {BookId} and Author is: {Author}";
        }
    }
}
