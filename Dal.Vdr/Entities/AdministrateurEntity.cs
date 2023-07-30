using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Vdr.Entities
{
    public class AdministrateurEntity 
    {
        public int? Id { get; init; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
