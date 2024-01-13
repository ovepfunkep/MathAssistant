using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssistant.Figures
{
    public class Triangle : IFigure
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;

        public double SideA 
        {
            get => _sideA;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Triangle side length must be positive.");

                if (IsSidesInequalityRuleViolated(value, SideB, SideC))
                    throw new ArgumentException("Triangle inequality rule violated.");

                _sideA = value;
            }
        }
        public double SideB
        {
            get => _sideB;
            set
            {
                if (value <= 0) 
                    throw new ArgumentException("Triangle side length must be positive.");

                if (IsSidesInequalityRuleViolated(SideA, value, SideC))
                    throw new ArgumentException("Triangle inequality rule violated.");

                _sideB = value;
            }
        }
        public double SideC
        {
            get => _sideC;
            set
            {
                if (value <= 0) 
                    throw new ArgumentException("Triangle side length must be positive.");

                if (IsSidesInequalityRuleViolated(SideA, SideB, value))
                    throw new ArgumentException("Triangle inequality rule violated.");

                _sideC = value;
            }
        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0
             || sideB <= 0
             || sideC <= 0)
                throw new ArgumentException("Triangle sides lengths must be positive.");

            if (IsSidesInequalityRuleViolated(sideA, sideB, sideC)) 
                throw new ArgumentException("Triangle inequality rule violated.");

            _sideA = sideA; // Using private fields instead of 
            _sideB = sideB; // Parameters so that "IsTriangleValid" method's
            _sideC = sideC; // Not used excessive number of times
        }

        public static bool IsSidesInequalityRuleViolated(double sideA, double sideB, double sideC) => sideA + sideB > sideC
                                                                                                   && sideB + sideC > sideA
                                                                                                   && sideC + sideA > sideB;

        public double GetArea() => GetAreaByThreeSides(); // Made this way so that in future could find area by multiple ways (e.g. by height and side)

        private double GetAreaByThreeSides() 
        {
            var perimeter = SideA + SideB + SideC;
            var perimetersHalf = perimeter / 2;

            return Math.Sqrt(perimetersHalf
                          * (perimetersHalf - SideA)
                          * (perimetersHalf - SideB)
                          * (perimetersHalf - SideC)); // S = √(p * (p - A) * (p - B) + (p - C))

        }

        public bool IsTriangleRectangular() => SideC == Math.Sqrt(Math.Pow(SideA, 2) + Math.Pow(SideB, 2)); // C = √(A² + B²)
    }
}
