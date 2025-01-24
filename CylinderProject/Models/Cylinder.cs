using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CylinderProject.Models
{
    public class Cylinder
    {

        private double _radius, _height;

        public Cylinder(double radius, double height)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("A sugárnak pozitív számnak kell lennie!");
            }

            if (height <= 0)
            {
                throw new ArgumentException("A magasságnak pozitív számnak kell lennie!");
            }

            _radius = radius;
            _height = height;
        }

        public double GetVolume()
        {
            return Math.PI * Math.Pow(_radius, 2) * _height;
        }

        public double GetSurfaceArea()
        {
            return 2 * Math.PI * Math.Pow(_radius, 2) + 2 * Math.PI * _radius * _height;
        }

        public void Resize(double newRadius, double newHeight)
        {
            if (newRadius <= 0 || newHeight <= 0)
            {
                throw new ArgumentException("A sugárnak és magasságnak pozitív számnak kell lennie!");
            }

            _radius = newRadius;
            _height = newHeight;
        }
    }
}
