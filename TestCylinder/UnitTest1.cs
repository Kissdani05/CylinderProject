using CylinderProject.Models;
namespace TestCylinder
{
    public class UnitTest1
    {
        [Fact]
        public void Constructor_SetsRadiusAndHeightCorrectly()
        {
            // Arrange
            double radius = 5.0;
            double height = 10.0;

            // Act
            var cylinder = new Cylinder(radius, height);

            // Assert
            Assert.Equal(radius, cylinder.GetType().GetField("_radius", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(cylinder));
            Assert.Equal(height, cylinder.GetType().GetField("_height", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(cylinder));
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(-5, 10)]
        [InlineData(5, 0)]
        [InlineData(5, -10)]
        public void Constructor_ThrowsExceptionForInvalidInputs(double radius, double height)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Cylinder(radius, height));
        }

        [Fact]
        public void GetVolume_ReturnsCorrectValue()
        {
            // Arrange
            double radius = 3.0;
            double height = 5.0;
            var cylinder = new Cylinder(radius, height);
            double expectedVolume = Math.Round(Math.PI * Math.Pow(radius, 2) * height, 2);

            // Act
            double actualVolume = Math.Round(cylinder.GetVolume(), 2);

            // Assert
            Assert.Equal(expectedVolume, actualVolume);
        }

        [Fact]
        public void GetSurfaceArea_ReturnsCorrectValue()
        {
            // Arrange
            double radius = 3.0;
            double height = 5.0;
            var cylinder = new Cylinder(radius, height);
            double expectedSurfaceArea = Math.Round(2 * Math.PI * Math.Pow(radius, 2) + 2 * Math.PI * radius * height, 2);

            // Act
            double actualSurfaceArea = Math.Round(cylinder.GetSurfaceArea(), 2);

            // Assert
            Assert.Equal(expectedSurfaceArea, actualSurfaceArea);
        }

        [Fact]
        public void Resize_UpdatesRadiusAndHeight()
        {
            // Arrange
            var cylinder = new Cylinder(3.0, 5.0);
            double newRadius = 4.0;
            double newHeight = 6.0;

            // Act
            cylinder.Resize(newRadius, newHeight);

            // Assert
            Assert.Equal(newRadius, cylinder.GetType().GetField("_radius", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(cylinder));
            Assert.Equal(newHeight, cylinder.GetType().GetField("_height", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(cylinder));
        }

        [Theory]
        [InlineData(0, 6)]
        [InlineData(-4, 5)]
        public void Resize_ThrowsExceptionForInvalidValues(double newRadius, double newHeight)
        {
            // Arrange
            var cylinder = new Cylinder(3.0, 5.0);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => cylinder.Resize(newRadius, newHeight));
        }

        [Fact]
        public void CylinderObject_IsNotNull()
        {
            // Act
            var cylinder = new Cylinder(3.0, 5.0);

            // Assert
            Assert.NotNull(cylinder);
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(50.0)]
        [InlineData(100.0)]
        public void Radius_IsWithinValidRange(double radius)
        {
            // Arrange
            var cylinder = new Cylinder(radius, 10.0);

            // Act & Assert
            Assert.InRange(radius, 1.0, 100.0);
        }
    }
}