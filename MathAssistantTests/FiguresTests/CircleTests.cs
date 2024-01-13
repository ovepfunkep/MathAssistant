using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssistantTests.FiguresTests
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void Create_ValidRadius_ReturnsValidCircle()
        {
            // Assert
            int radius = 1;

            // Act
            var circle = new Circle(radius);

            // Assert
            Assert.That(circle.Radius, Is.EqualTo(radius));
        }

        [Test]
        public void Create_InvalidRadius_ThrowsArgumentException()
        {
            // Assert
            int radius = -1;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }

        [Test]
        public void AssignProperty_ValidRadius_AssignsCorrectly()
        {
            // Assert
            int radius = 1;
            double newRadius = 1.1;

            // Act
            var circle = new Circle(radius);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => circle.Radius = newRadius);
                Assert.That(circle.Radius, Is.EqualTo(newRadius));
            });
        }

        [Test]
        public void AssignProperty_InvalidRadius_ThrowsArgumentException()
        {
            // Assert
            int radius = 1;
            double newRadius = -1;

            // Act
            var circle = new Circle(radius);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() => circle.Radius = newRadius);
                Assert.That(circle.Radius, Is.EqualTo(radius));
            });
        }

        [Test]
        public void GetArea_CalculatesCorrectly()
        {
            // Assert
            int radius = 1;

            // Act
            var circle = new Circle(radius);

            // Assert
            Assert.That(circle.GetArea(), Is.EqualTo(Math.PI * Math.Pow(radius, 2)));
        }

        [Test]
        public void GetArea_CircleAsFigure_CalculatesCorrectly()
        {
            // Assert
            int radius = 1;

            // Act
            IFigure circle = new Circle(radius);

            // Assert
            Assert.That(circle.GetArea(), Is.EqualTo(Math.PI * Math.Pow(radius, 2)));
        }
    }
}
