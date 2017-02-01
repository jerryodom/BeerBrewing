using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerBrewingReact.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }

    public static class CommentSeed
    {
        public static List<CommentModel> GetComments()
        {
            Random rando = new Random();
            return new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Daniel Lo Nigro",
                    Text = "Hello ReactJS.NET World!" + rando.Next(1, 1000).ToString()
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Pete Hunt",
                    Text = "This is one comment" + rando.Next(1, 1000).ToString()
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Jordan Walke",
                    Text = "This is *another* comment"+ rando.Next(1, 1000).ToString()
                },
            };
        }
    }

}
