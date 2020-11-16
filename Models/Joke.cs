using System;

namespace DotnetWebAPI.Models
{
    public class Joke
    {
        public int JokeId { get; set; }
        public string Setup { get; set; }
        public string Delivery { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}