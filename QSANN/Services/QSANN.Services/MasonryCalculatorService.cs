using QSANN.Services.Interfaces;
using QSANN.Services.Interfaces.Models;
using System;
using System.Collections.Generic;

namespace QSANN.Services
{

    public class MasonryCalculatorService : IMasonryCalculatorService
    {
        public decimal CalculateCHB(decimal area)
        {
            decimal multiplier = 12.5m;

            return area * multiplier;
        }

        public decimal CalculateClassMixtureForMortarMultiplier(string classMixture)
        {
            switch (classMixture.ToUpper())
            {
                case "A":
                    return 18m;
                case "B":
                    return 12m;
                case "C":
                    return 9m;
                case "D":
                    return 7.5m;
                default:
                    throw new ArgumentException("Unsupported Class Mixture", nameof(classMixture));
            }
        }

        public decimal CalculateWallArea(decimal height, decimal length)
        {
            return height * length;
        }

        public ThicknessSandModel CalculateThicknessAndSandMultipliers(decimal thickness, string classMixture)
        {
            var model = new ThicknessSandModel();

            switch (classMixture.ToUpper())
            {
                case "A" when thickness == 8:
                    model.ThicknessInMillimeter = .144m;
                    model.Sand = .008m;
                    break;
                case "A" when thickness == 12:
                    model.ThicknessInMillimeter = .216m;
                    model.Sand = .012m;
                    break;
                case "A" when thickness == 16:
                    model.ThicknessInMillimeter = .288m;
                    model.Sand = .016m;
                    break;
                case "A" when thickness == 20:
                    model.ThicknessInMillimeter = .360m;
                    model.Sand = .02m;
                    break;
                case "A" when thickness == 25:
                    model.ThicknessInMillimeter = .450m;
                    model.Sand = .25m;
                    break;



                case "B" when thickness == 8:
                    model.ThicknessInMillimeter = .096m;
                    model.Sand = .008m;
                    break;
                case "B" when thickness == 12:
                    model.ThicknessInMillimeter = .144m;
                    model.Sand = .012m;
                    break;
                case "B" when thickness == 16:
                    model.ThicknessInMillimeter = .192m;
                    model.Sand = .016m;
                    break;
                case "B" when thickness == 20:
                    model.ThicknessInMillimeter = .240m;
                    model.Sand = .02m;
                    break;
                case "B" when thickness == 25:
                    model.ThicknessInMillimeter = .3m;
                    model.Sand = .025m;
                    break;


                case "C" when thickness == 8:
                    model.ThicknessInMillimeter = .072m;
                    model.Sand = .008m;
                    break;
                case "C" when thickness == 12:
                    model.ThicknessInMillimeter = .108m;
                    model.Sand = .012m;
                    break;
                case "C" when thickness == 16:
                    model.ThicknessInMillimeter = .144m;
                    model.Sand = .016m;
                    break;
                case "C" when thickness == 20:
                    model.ThicknessInMillimeter = .18m;
                    model.Sand = .02m;
                    break;
                case "C" when thickness == 25:
                    model.ThicknessInMillimeter = .225m;
                    model.Sand = .025m;
                    break;


                case "D" when thickness == 8:
                    model.ThicknessInMillimeter = .06m;
                    model.Sand = .008m;
                    break;
                case "D" when thickness == 12:
                    model.ThicknessInMillimeter = .09m;
                    model.Sand = .012m;
                    break;
                case "D" when thickness == 16:
                    model.ThicknessInMillimeter = .12m;
                    model.Sand = .016m;
                    break;
                case "D" when thickness == 20:
                    model.ThicknessInMillimeter = .15m;
                    model.Sand = .02m;
                    break;
                case "D" when thickness == 25:
                    model.ThicknessInMillimeter = .188m;
                    model.Sand = .025m;
                    break;


                default: throw new ArgumentException("Unsupported Input");


            }

            return model;
        }
    }
}
