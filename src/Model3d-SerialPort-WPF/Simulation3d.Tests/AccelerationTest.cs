using System;
using Xunit;
using Simulation3d; 

namespace Simulation3d.Tests
{
    public class AccelerationTest
    {
        private Acceleration accel;

        private float Adjust(float value, float step)
        {
            if (value > 0) 
            {
                value -= step; 
            }
            else if (value < 0)
            {
                value += step;
            }
            return value; 
        }

        [Theory]
        [InlineData(400.45f)]
        [InlineData(300)]
        [InlineData(100.56f)]
        [InlineData(50)]
        [InlineData(30)]
        [InlineData(7.5f)]
        [InlineData(5)]
        [InlineData(0.67f)]
        [InlineData(0)]
        [InlineData(-0.67f)]
        [InlineData(-6.53f)]
        [InlineData(-8.3f)]
        [InlineData(-26)]
        [InlineData(-60)]
        [InlineData(-100.00991f)]
        [InlineData(-350)]
        [InlineData(-560.8573f)]
        public void X_SetValue_ReturnsSameValue(float value)
        {
            accel.X = value; 

            float actual = accel.X;

            Assert.Equal(value, actual);
        }

        [Theory]
        [InlineData(406.876f)]
        [InlineData(300.07f)]
        [InlineData(100)]
        [InlineData(50)]
        [InlineData(30.5f)]
        [InlineData(7.5f)]
        [InlineData(5)]
        [InlineData(0.0089f)]
        [InlineData(0)]
        [InlineData(-0.1049f)]
        [InlineData(-6)]
        [InlineData(-9.2f)]
        [InlineData(-26.501f)]
        [InlineData(-60.3f)]
        [InlineData(-100)]
        [InlineData(-350.5678f)]
        [InlineData(-560)]
        public void Y_SetValue_ReturnsSameValue(float value)
        {
            accel.Y = value; 

            float actual = accel.Y;

            Assert.Equal(value, actual);
        }

        [Theory]
        [InlineData(410.07f)]
        [InlineData(300)]
        [InlineData(100.00509f)]
        [InlineData(50)]
        [InlineData(30)]
        [InlineData(7.5f)]
        [InlineData(5)]
        [InlineData(0.05f)]
        [InlineData(0.0)]
        [InlineData(-0.05f)]
        [InlineData(-6)]
        [InlineData(-8.3f)]
        [InlineData(-26.1234f)]
        [InlineData(-60)]
        [InlineData(-100.45f)]
        [InlineData(-350)]
        [InlineData(-560.563f)]
        public void Z_SetValue_ReturnsSameValue(float value)
        {
            accel.Z = value; 

            float actual = accel.Z;

            Assert.Equal(value, actual);
        }

        [Theory]
        [InlineData(10.5f, 1.5f)]
        [InlineData(0.05f, 0.5f)]
        [InlineData(7.5f, 0)]
        [InlineData(0.5f, 0)]
        [InlineData(7.5f, -1.5f)]
        [InlineData(0.5f, -1.8f)]
        [InlineData(0, 2.5f)]
        [InlineData(0, 12.3f)]
        [InlineData(0, 0)]
        [InlineData(0, 0.05f)]
        [InlineData(0, -1.1f)]
        [InlineData(0, -8.1f)]
        [InlineData(-0.5f, 2.5f)]
        [InlineData(-0.24f, 0.015f)]
        [InlineData(-0.23f, 0)]
        [InlineData(-0.505f, 0)]
        [InlineData(-0.78f, -10.9f)]
        [InlineData(-0.54f, -0.005f)]
        public void AdjustX_SetXPassStep_ReturnsExpected(float x, float step)
        {
            accel.X = x; 

            accel.AdjustX(step); 
            float expected = Adjust(x, step); 
            float actual = accel.X; 

            Assert.Equal(expected, actual); 
        }

        [Theory]
        [InlineData(10.5f, 1.5f)]
        [InlineData(0.05f, 0.5f)]
        [InlineData(7.5f, 0)]
        [InlineData(0.5f, 0)]
        [InlineData(7.5f, -1.5f)]
        [InlineData(0.5f, -1.8f)]
        [InlineData(0, 2.5f)]
        [InlineData(0, 12.3f)]
        [InlineData(0, 0)]
        [InlineData(0, 0.05f)]
        [InlineData(0, -1.1f)]
        [InlineData(0, -8.1f)]
        [InlineData(-0.5f, 2.5f)]
        [InlineData(-0.24f, 0.015f)]
        [InlineData(-0.23f, 0)]
        [InlineData(-0.505f, 0)]
        [InlineData(-0.78f, -10.9f)]
        [InlineData(-0.54f, -0.005f)]
        public void AdjustY_SetYPassStep_ReturnsExpected(float y, float step)
        {
            accel.Y = y; 

            accel.AdjustY(step); 
            float expected = Adjust(y, step); 
            float actual = accel.Y; 

            Assert.Equal(expected, actual); 
        }

        [Theory]
        [InlineData(10.5f, 1.5f)]
        [InlineData(0.05f, 0.5f)]
        [InlineData(7.5f, 0)]
        [InlineData(0.5f, 0)]
        [InlineData(7.5f, -1.5f)]
        [InlineData(0.5f, -1.8f)]
        [InlineData(0, 2.5f)]
        [InlineData(0, 12.3f)]
        [InlineData(0, 0)]
        [InlineData(0, 0.05f)]
        [InlineData(0, -1.1f)]
        [InlineData(0, -8.1f)]
        [InlineData(-0.5f, 2.5f)]
        [InlineData(-0.24f, 0.015f)]
        [InlineData(-0.23f, 0)]
        [InlineData(-0.505f, 0)]
        [InlineData(-0.78f, -10.9f)]
        [InlineData(-0.54f, -0.005f)]
        public void AdjustZ_SetZPassStep_ReturnsExpected(float z, float step)
        {
            accel.Z = z; 

            accel.AdjustZ(step); 
            float expected = Adjust(z, step); 
            float actual = accel.Z; 

            Assert.Equal(expected, actual); 
        }
    }
}
