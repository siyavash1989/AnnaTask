using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MenuDto
    {
        public string ItemTitle { get; set; }
        public List<MenuDto> SubItem { get; set; }
    }
}