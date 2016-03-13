using System.Collections.Generic;

namespace FHL.Data.Models.NHL
{
    public sealed class People
    {
        public string copyright { get; set; }
        public IList<Person> people { get; set; }
    }
}