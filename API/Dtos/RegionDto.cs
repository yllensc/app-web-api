using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class RegionDto
    {
       public int RegionId {get; set;}
       public string RegionNombre {get; set;} 
       public int IDepFk { get; set; }
    }
}