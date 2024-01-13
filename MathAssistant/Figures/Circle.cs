using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssistant.Figures
{
    public class Circle(int radius) : IFigure
    {
        public int Radius { get; set; } = radius;

        public double GetArea() => Math.PI * Math.Pow(Radius, 2); // πR²
    }
}
