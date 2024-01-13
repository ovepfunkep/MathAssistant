using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssistant.Figures
{
    public class Circle : IFigure
    {
        public int Radius { get; set; }

        public double GetSquare() => Math.PI * Math.Pow(Radius, 2);
    }
}
