using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Vdr.Entities
{
    public class ArticlesEntity
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
