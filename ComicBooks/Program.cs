using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBooks.Data;
using ComicBooks.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context= new Context())
            {
                context.Database.Log= (message) => Debug.WriteLine(message);

                var comicBookId = 1;
                var comicBook = context.ComicBooks.Find(comicBookId);
                //var comicBooks = context.ComicBooks
                //    //.Include(cb => cb.Series)
                //    //.Include(cb => cb.Artists.Select(a => a.Artist))
                //    //.Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList();
                //foreach (var comicBook in comicBooks)
                //{
                //    var artistRoleNames = comicBook.Artists
                //        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artistDisplayText = string.Join(", ", artistRoleNames);
                //    // Console.WriteLine(comicBook.Series.Title);
                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artistDisplayText);
                //}

                Console.ReadLine();
            }
        }
    }
}
