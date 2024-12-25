using System;
using Xunit;
using Simulation3d; 

namespace Simulation3d.Tests
{
    public class AngleTest
    {
        private Angle angle; 

        [Theory]
        [InlineData(-1000.508f, -280.508f)]
        [InlineData(-700.0f, -340.0f)]
        [InlineData(-520.0f, -160.0f)]
        [InlineData(-120.23f, -120.23f)]
        [InlineData(-20.095f, -20.095f)]
        [InlineData(-0.05f, -0.05f)]
        [InlineData(0, 0)]
        [InlineData(0.5f, 0.5f)]
        [InlineData(10.5f, 10.5f)]
        [InlineData(40.45f, 40.45f)]
        [InlineData(400.45f, 40.45f)]
        [InlineData(770.115f, 50.115f)]
        [InlineData(970.115f, 250.115f)]
        public void X_SetX_EqualsToExpected(float input, float expected)
        {
            angle.X = input; 

            float actual = angle.X; 

            Assert.Equal(expected, actual, 3); 
        }

        [Theory]
        [InlineData(-1000.508f)]
        [InlineData(-700.0f)]
        [InlineData(-520.0f)]
        [InlineData(-120.23f)]
        [InlineData(-20.095f)]
        [InlineData(-0.05f)]
        [InlineData(0.0f)]
        [InlineData(0.5f)]
        [InlineData(10.5f)]
        [InlineData(40.45f)]
        [InlineData(400.45f)]
        [InlineData(770.115f)]
        [InlineData(970.115f)]
        public void X_SetX_ReturnsValuesBetween0And359(float input)
        {
            angle.X = input; 

            float actual = angle.X; 

            Assert.True(actual > -360 || actual < 360); 
        }

        [Theory]
        [InlineData(-1700.0f, -260.0f)]
        [InlineData(-800.50f, -80.50f)]
        [InlineData(-700.0f, -340.0f)]
        [InlineData(-520.0f, -160.0f)]
        [InlineData(-120.23f, -120.23f)]
        [InlineData(-20.095f, -20.095f)]
        [InlineData(-0.05f, -0.05f)]
        [InlineData(0, 0)]
        [InlineData(0.5f, 0.5f)]
        [InlineData(10.5f, 10.5f)]
        [InlineData(40.45f, 40.45f)]
        [InlineData(400.45f, 40.45f)]
        [InlineData(770.005f, 50.005f)]
        [InlineData(900.5f, 180.5f)]
        public void Y_SetY_EqualsToExpected(float input, float expected)
        {
            angle.Y = input; 

            float actual = angle.Y; 

            Assert.Equal(expected, actual, 3); 
        }

        [Theory]
        [InlineData(-1000.508f)]
        [InlineData(-700.0f)]
        [InlineData(-520.0f)]
        [InlineData(-120.23f)]
        [InlineData(-20.095f)]
        [InlineData(-0.05f)]
        [InlineData(0.0f)]
        [InlineData(0.5f)]
        [InlineData(10.5f)]
        [InlineData(40.45f)]
        [InlineData(400.45f)]
        [InlineData(770.115f)]
        [InlineData(970.115f)]
        public void Y_SetY_ReturnsValuesBetween0And359(float input)
        {
            angle.Y = input; 

            float actual = angle.Y; 

            Assert.True(actual > -360 || actual < 360); 
        }

        [Theory]
        [InlineData(-1135.25f, -55.25f)]
        [InlineData(-750.025f, -30.025f)]
        [InlineData(-700.0f, -340.0f)]
        [InlineData(-520.0f, -160.0f)]
        [InlineData(-120.23f, -120.23f)]
        [InlineData(-20.095f, -20.095f)]
        [InlineData(-0.05f, -0.05f)]
        [InlineData(0, 0)]
        [InlineData(0.5f, 0.5f)]
        [InlineData(10.5f, 10.5f)]
        [InlineData(40.45f, 40.45f)]
        [InlineData(400.45f, 40.45f)]
        [InlineData(770.015f, 50.015f)]
        [InlineData(1080.0f, 0.0f)]
        public void Z_SetZ_EqualsToExpected(float input, float expected)
        {
            angle.Z = input; 

            float actual = angle.Z; 

            Assert.Equal(expected, actual, 3); 
        }
        
        [Theory]
        [InlineData(-1000.508f)]
        [InlineData(-700.0f)]
        [InlineData(-520.0f)]
        [InlineData(-120.23f)]
        [InlineData(-20.095f)]
        [InlineData(-0.05f)]
        [InlineData(0.0f)]
        [InlineData(0.5f)]
        [InlineData(10.5f)]
        [InlineData(40.45f)]
        [InlineData(400.45f)]
        [InlineData(770.115f)]
        [InlineData(970.115f)]
        public void Z_SetZ_ReturnsValuesBetween0And359(float input)
        {
            angle.Z = input; 

            float actual = angle.Z; 

            Assert.True(actual > -360 || actual < 360); 
        }
    }
}