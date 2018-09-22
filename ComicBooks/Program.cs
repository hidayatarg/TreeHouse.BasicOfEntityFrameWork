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

                //var comicBooks = context.ComicBooks.ToList();
                

                //Linq query 
                var comicBooksQuery = from cb in context.ComicBooks select cb;
                var comicBooks = comicBooksQuery.ToList();
                Console.WriteLine("the number of comicbooks{0}", comicBooks.Count);


                //Filtering Query
                var comicBookI = context.ComicBooks
                    .Include(cb=>cb.Series)
                    .Where(cb =>cb.Series.Title.Contains("The amazing spider")).ToList();
                Console.WriteLine(comicBookI.Count);
                // display the names
                foreach (var comicbooki in comicBookI)
                {
                    Console.WriteLine(comicbooki.DisplayText);
                }




                //var comicBooks = context.ComicBooks
                //    .Include(cb=>cb.Series)
                //    .Include(cb=>cb.Artists.Select(a=>a.Artist))
                //    .Include(cb=>cb.Artists.Select(a=>a.Role))
                //    .ToList();
                //foreach (var comicBook in comicBooks)
                //{
                //    var artistRoleNames = comicBook.Artists
                //        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artistDisplayText = string.Join(", ", artistRoleNames);
                //   // Console.WriteLine(comicBook.Series.Title);
                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artistDisplayText);
                //}

                Console.ReadLine();
            }
        }
    }
}
