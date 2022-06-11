using QSANN.Services.Interfaces;
using QSANN.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Services
{
    public class RebarworksSlabCalculatorService : IRebarworksSlabCalculatorService
    {
        public List<RebarworksSlabTypeMultiplier> GetMultipliers()
        {
            return new List<RebarworksSlabTypeMultiplier>()
            {
                // One Way
                new RebarworksSlabTypeMultiplier() { Name = "10", SlabType = 1, SteelbarMultiplier = 3.764m, TiewireMultiplier = .632m },
                new RebarworksSlabTypeMultiplier() { Name = "12.5", SlabType = 1, SteelbarMultiplier = 3.062m, TiewireMultiplier = .422m },
                new RebarworksSlabTypeMultiplier() { Name = "15", SlabType = 1, SteelbarMultiplier = 2.584m, TiewireMultiplier = .303m },
                new RebarworksSlabTypeMultiplier() { Name = "17.5", SlabType = 1, SteelbarMultiplier = 2.232m, TiewireMultiplier = .224m },
                new RebarworksSlabTypeMultiplier() { Name = "20", SlabType = 1, SteelbarMultiplier = 1.980m, TiewireMultiplier = .175m },
                new RebarworksSlabTypeMultiplier() { Name = "22.5", SlabType = 1, SteelbarMultiplier = 1.786m, TiewireMultiplier = .147m },
                new RebarworksSlabTypeMultiplier() { Name = "25", SlabType = 1, SteelbarMultiplier = 1.627m, TiewireMultiplier = .118m },

                // Two Way
                new RebarworksSlabTypeMultiplier() { Name = "10", SlabType = 2, SteelbarMultiplier = 4.369m, TiewireMultiplier = .896m },
                new RebarworksSlabTypeMultiplier() { Name = "12.5", SlabType = 2, SteelbarMultiplier = 3.603m, TiewireMultiplier = .554m },
                new RebarworksSlabTypeMultiplier() { Name = "15", SlabType = 2, SteelbarMultiplier = 3.221m, TiewireMultiplier = .466m },
                new RebarworksSlabTypeMultiplier() { Name = "17.5", SlabType = 2, SteelbarMultiplier = 2.647m, TiewireMultiplier = .330m },
                new RebarworksSlabTypeMultiplier() { Name = "20", SlabType = 2, SteelbarMultiplier = 2.360m, TiewireMultiplier = .232m },
                new RebarworksSlabTypeMultiplier() { Name = "22.5", SlabType = 2, SteelbarMultiplier = 2.168m, TiewireMultiplier = .224m },
                new RebarworksSlabTypeMultiplier() { Name = "25", SlabType = 2, SteelbarMultiplier = 1.977m, TiewireMultiplier = .189m },
            };
        }

        public decimal CalculateSteelbar(decimal area, decimal multiplier) 
        {
            return area * multiplier;
        }

        public decimal CalculateTiewire(decimal area, decimal multiplier)
        {
            return area * multiplier;
        }
    }
}
