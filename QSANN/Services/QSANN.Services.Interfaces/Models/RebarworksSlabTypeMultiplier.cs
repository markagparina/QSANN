using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Services.Interfaces.Models
{
    public class RebarworksSlabTypeMultiplier
    {
        public string Name { get; set; }
        public int SlabType { get; set; }
        public decimal SteelbarMultiplier { get; set; }
        public decimal TiewireMultiplier { get; set; }
    }
}
