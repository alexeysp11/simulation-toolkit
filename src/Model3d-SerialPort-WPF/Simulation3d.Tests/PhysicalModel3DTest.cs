using System;
using Xunit;
using Simulation3d; 

namespace Simulation3d.Tests
{
    public class PhysicalModel3DTest
    {
        PhysicalModel3D PhysicalModel3D = new PhysicalModel3D(); 

        [Fact]
        public void CreateObject_UseDefaultConstructor_ObjectNotNull()
        {
            Assert.NotNull(PhysicalModel3D); 
        }

        [Fact]
        public void CreateObject_UseDefaultConstructor_ParametersEqual0()
        {
            float expected = 0.0f; 

            float actualTemp = PhysicalModel3D.GetTemperature(); 
            Angle angle = PhysicalModel3D.GetRotation(); 
            Acceleration accel = PhysicalModel3D.GetAcceleration(); 

            Assert.Equal(expected, actualTemp, 3); 
            Assert.Equal(expected, angle.X, 3); 
            Assert.Equal(expected, angle.Y, 3); 
            Assert.Equal(expected, angle.Z, 3); 
            Assert.Equal(expected, accel.X, 3); 
            Assert.Equal(expected, accel.Y, 3); 
            Assert.Equal(expected, accel.Z, 3); 
        }

        [Theory]
        [InlineData(-1000.508f)]
        [InlineData(-50.75f)]
        [InlineData(-10.054f)]
        [InlineData(-2.054f)]
        [InlineData(-0.903f)]
        [InlineData(0.0f)]
        [InlineData(5.405f)]
        [InlineData(15.592f)]
        [InlineData(55.52f)]
        [InlineData(155.52f)]
        [InlineData(765.430f)]
        public void SetTemperature_SetValue_ReturnsSameValue(float input)
        {
            PhysicalModel3D.SetTemperature(input); 
            float actualTemp = PhysicalModel3D.GetTemperature(); 

            Assert.Equal(input, actualTemp, 3); 
        }

        [Fact]
        public void SetRotation_DefaultParameters_ParametersEqual0()
        {
            float expected = 0; 

            PhysicalModel3D.SetRotation(); 
            Angle angle = PhysicalModel3D.GetRotation(); 

            Assert.Equal(expected, angle.X, 3); 
            Assert.Equal(expected, angle.Y, 3); 
            Assert.Equal(expected, angle.Z, 3); 
        }

        [Theory]
        [InlineData(50.0f, -1000.508f, -280.508f)]
        [InlineData(50.0f, -700.0f, -340.0f)]
        [InlineData(50.0f, -520.0f, -160.0f)]
        [InlineData(50.0f, -120.23f, -120.23f)]
        [InlineData(50.0f, -20.095f, -20.095f)]
        [InlineData(50.0f, -0.05f, -0.05f)]
        [InlineData(50.0f, 0, 0)]
        [InlineData(50.0f, 0.5f, 0.5f)]
        [InlineData(50.0f, 10.5f, 10.5f)]
        [InlineData(50.0f, 40.45f, 40.45f)]
        [InlineData(50.0f, 400.45f, 40.45f)]
        [InlineData(50.0f, 770.115f, 50.115f)]
        [InlineData(50.0f, 970.115f, 250.115f)]
        public void SetRotation_PositiveXAnyYZ_ReturnsValuesBetween0And359(float dx, float dy, float dz)
        {
            PhysicalModel3D.SetRotation(dx, dy, dz); 
            Angle angle = PhysicalModel3D.GetRotation(); 

            Assert.True(angle.X > -360 || angle.X < 360); 
            Assert.True(angle.Y > -360 || angle.Y < 360); 
            Assert.True(angle.Z > -360 || angle.Z < 360); 
        }

        [Theory]
        [InlineData(0.0f, -1000.508f, -280.508f)]
        [InlineData(0.0f, -700.0f, -340.0f)]
        [InlineData(0.0f, -520.0f, -160.0f)]
        [InlineData(0.0f, -120.23f, -120.23f)]
        [InlineData(0.0f, -20.095f, -20.095f)]
        [InlineData(0.0f, -0.05f, -0.05f)]
        [InlineData(0.0f, 0, 0)]
        [InlineData(0.0f, 0.5f, 0.5f)]
        [InlineData(0.0f, 10.5f, 10.5f)]
        [InlineData(0.0f, 40.45f, 40.45f)]
        [InlineData(0.0f, 400.45f, 40.45f)]
        [InlineData(0.0f, 770.115f, 50.115f)]
        [InlineData(0.0f, 970.115f, 250.115f)]
        public void SetRotation_ZeroXAnyYZ_ReturnsValuesBetween0And359(float dx, float dy, float dz)
        {
            PhysicalModel3D.SetRotation(dx, dy, dz); 
            Angle angle = PhysicalModel3D.GetRotation(); 

            Assert.True(angle.X > -360 || angle.X < 360); 
            Assert.True(angle.Y > -360 || angle.Y < 360); 
            Assert.True(angle.Z > -360 || angle.Z < 360); 
        }

        [Theory]
        [InlineData(-120.0f, -1000.508f, -280.508f)]
        [InlineData(-120.0f, -700.0f, -340.0f)]
        [InlineData(-120.0f, -520.0f, -160.0f)]
        [InlineData(-120.0f, -120.23f, -120.23f)]
        [InlineData(-120.0f, -20.095f, -20.095f)]
        [InlineData(-120.0f, -0.05f, -0.05f)]
        [InlineData(-120.0f, 0, 0)]
        [InlineData(-120.0f, 0.5f, 0.5f)]
        [InlineData(-120.0f, 10.5f, 10.5f)]
        [InlineData(-120.0f, 40.45f, 40.45f)]
        [InlineData(-120.0f, 400.45f, 40.45f)]
        [InlineData(-120.0f, 770.115f, 50.115f)]
        [InlineData(-120.0f, 970.115f, 250.115f)]
        public void SetRotation_NegativeXAnyYZ_ReturnsValuesBetween0And359(float dx, float dy, float dz)
        {
            PhysicalModel3D.SetRotation(dx, dy, dz); 
            Angle angle = PhysicalModel3D.GetRotation(); 

            Assert.True(angle.X > -360 || angle.X < 360); 
            Assert.True(angle.Y > -360 || angle.Y < 360); 
            Assert.True(angle.Z > -360 || angle.Z < 360); 
        }

        [Fact]
        public void SetAcceleration_DefaultParameters_ParametersEqual0()
        {
            float expected = 0; 

            PhysicalModel3D.SetAcceleration(); 
            Acceleration accel = PhysicalModel3D.GetAcceleration(); 

            Assert.Equal(expected, accel.X, 3); 
            Assert.Equal(expected, accel.Y, 3); 
            Assert.Equal(expected, accel.Z, 3); 
        }

        [Theory]
        [InlineData(10.0f, -1000.508f, -280.508f)]
        [InlineData(10.0f, -700.0f, -340.0f)]
        [InlineData(10.0f, -520.0f, -160.0f)]
        [InlineData(10.0f, -120.23f, -120.23f)]
        [InlineData(10.0f, -20.095f, -20.095f)]
        [InlineData(10.0f, -0.05f, -0.05f)]
        [InlineData(10.0f, 0, 0)]
        [InlineData(10.0f, 0.5f, 0.5f)]
        [InlineData(10.0f, 10.5f, 10.5f)]
        [InlineData(10.0f, 40.45f, 40.45f)]
        [InlineData(10.0f, 400.45f, 40.45f)]
        [InlineData(10.0f, 770.115f, 50.115f)]
        [InlineData(10.0f, 970.115f, 250.115f)]
        public void SetAcceleration_PositiveXAnyYZ_ReturnsSameValues(float dx, float dy, float dz)
        {
            PhysicalModel3D.SetAcceleration(dx, dy, dz); 

            Acceleration accel = PhysicalModel3D.GetAcceleration();

            Assert.Equal(dx, accel.X, 3);
            Assert.Equal(dy, accel.Y, 3);
            Assert.Equal(dz, accel.Z, 3);
        }

        [Theory]
        [InlineData(0.0f, -1000.508f, -280.508f)]
        [InlineData(0.0f, -700.0f, -340.0f)]
        [InlineData(0.0f, -520.0f, -160.0f)]
        [InlineData(0.0f, -120.23f, -120.23f)]
        [InlineData(0.0f, -20.095f, -20.095f)]
        [InlineData(0.0f, -0.05f, -0.05f)]
        [InlineData(0.0f, 0, 0)]
        [InlineData(0.0f, 0.5f, 0.5f)]
        [InlineData(0.0f, 10.5f, 10.5f)]
        [InlineData(0.0f, 40.45f, 40.45f)]
        [InlineData(0.0f, 400.45f, 40.45f)]
        [InlineData(0.0f, 770.115f, 50.115f)]
        [InlineData(0.0f, 970.115f, 250.115f)]
        public void SetAcceleration_ZeroXAnyYZ_ReturnsSameValues(float dx, float dy, float dz)
        {
            PhysicalModel3D.SetAcceleration(dx, dy, dz); 

            Acceleration accel = PhysicalModel3D.GetAcceleration();

            Assert.Equal(dx, accel.X, 3);
            Assert.Equal(dy, accel.Y, 3);
            Assert.Equal(dz, accel.Z, 3);
        }

        [Theory]
        [InlineData(-5.0f, -1000.508f, -280.508f)]
        [InlineData(-5.0f, -700.0f, -340.0f)]
        [InlineData(-5.0f, -520.0f, -160.0f)]
        [InlineData(-5.0f, -120.23f, -120.23f)]
        [InlineData(-5.0f, -20.095f, -20.095f)]
        [InlineData(-5.0f, -0.05f, -0.05f)]
        [InlineData(-5.0f, 0, 0)]
        [InlineData(-5.0f, 0.5f, 0.5f)]
        [InlineData(-5.0f, 10.5f, 10.5f)]
        [InlineData(-5.0f, 40.45f, 40.45f)]
        [InlineData(-5.0f, 400.45f, 40.45f)]
        [InlineData(-5.0f, 770.115f, 50.115f)]
        [InlineData(-5.0f, 970.115f, 250.115f)]
        public void SetAcceleration_NegativeXAnyYZ_ReturnsSameValues(float dx, float dy, float dz)
        {
            PhysicalModel3D.SetAcceleration(dx, dy, dz); 

            Acceleration accel = PhysicalModel3D.GetAcceleration();

            Assert.Equal(dx, accel.X, 3);
            Assert.Equal(dy, accel.Y, 3);
            Assert.Equal(dz, accel.Z, 3);
        }
    }
}