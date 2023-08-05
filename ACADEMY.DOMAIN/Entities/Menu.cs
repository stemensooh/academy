using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string? HeadTitle1 { get; set; }
        public string? HeadTitle2 { get; set; }
        public string? Title { get; set; }
        public string? Path { get; set; }
        public string? Icon { get; set; }
        public string? Type { get; set; }
        public string? BadgeType { get; set; }
        public string? BadgeValue { get; set; }
        public bool? Active { get; set; }
        public bool? Bookmark { get; set; }
        public int? IdPadre { get; set; }
        public bool? Estado { get; set; }
    }
}
