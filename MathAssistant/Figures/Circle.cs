using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssistant.Figures
{
    public class Circle : IFigure
    {
        public double _radius;
        public double Radius 
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Circle radius must be positive.");

                _radius = value;
            }
        }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Circle radius must be positive.");

            Radius = radius;
        }

        public double GetArea() => Math.PI * Math.Pow(Radius, 2); // πR²
    }
}
