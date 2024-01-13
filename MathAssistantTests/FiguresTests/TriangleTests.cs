using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathAssistant.Figures;

namespace MathAssistantTests.FiguresTests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void Create_ValidSides_ReturnsValidTriangle()
        {
            // Assert
            int sideA = 3;
            double sideB = 3.45;
            int sideC = 5;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(triangle.SideA, Is.EqualTo(sideA));
                Assert.That(triangle.SideB, Is.EqualTo(sideB));
                Assert.That(triangle.SideC, Is.EqualTo(sideC));
            });
        }

        [Test]
        public void Create_NegativeSidesLengths_ThrowsArgumentException()
        {
            // Assert
            int sideA = -3;
            double sideB = -3.45;
            int sideC = -5;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Test]
        public void Create_InvalidSides_ThrowsArgumentException()
        {
            // Assert
            int sideA = 1;
            double sideB = 2;
            int sideC = 3;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Test]
        public void AssignProperty_ValidSide_AssignsCorrectly()
        {
            // Assert
            int sideA = 3;
            double sideB = 4;
            int sideC = 5;
            double newSideA = 6;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => triangle.SideA = newSideA);
                Assert.That(triangle.SideA, Is.EqualTo(newSideA));
            });
        }

        [Test]
        public void AssignProperty_NegativeSide_ThrowsArgumentException()
        {
            // Assert
            int sideA = 3;
            double sideB = 4;
            int sideC = 5;
            double newSideA = -3;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() => triangle.SideA = newSideA);
                Assert.That(triangle.SideA, Is.EqualTo(sideA));
            });
        }

        [Test]
        public void AssignProperty_SideViolatesInequalityRule_ThrowsArgumentException()
        {
            // Assert
            int sideA = 3;
            double sideB = 4;
            int sideC = 5;
            double newSideA = 9;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() => triangle.SideA = newSideA);
                Assert.That(triangle.SideA, Is.EqualTo(sideA));
            });
        }

        [Test]
        public void GetArea_CalculatesCorrectly()
        {
            // Assert
            int sideA = 3;
            int sideB = 4;
            int sideC = 5;
            int perimeter = sideA + sideB + sideC;
            int perimetersHalf = perimeter / 2;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.That(triangle.GetArea(), Is.EqualTo(Math.Sqrt(perimetersHalf
                                                              * (perimetersHalf - sideA)
                                                              * (perimetersHalf - sideB)
                                                              * (perimetersHalf - sideC))));
        }

        [Test]
        public void IsTriangleRectangular_ValidSides_ReturnsTrue()
        {
            // Assert
            int sideA = 3;
            int sideB = 4;
            int sideC = 5;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.That(triangle.IsTriangleRectangular(), Is.EqualTo(true));
        }

        [Test]
        public void IsTriangleRectangular_InvalidSides_ReturnsFalse()
        {
            // Assert
            int sideA = 4;
            int sideB = 4;
            int sideC = 4;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.That(triangle.IsTriangleRectangular(), Is.EqualTo(false));
        }
    }
}
