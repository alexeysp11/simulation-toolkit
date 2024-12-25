namespace Simulation3d
{
    public class PhysicalModel3D 
    {
        private Angle angle; 
        private Acceleration accel; 

        private float Temperature = 0.0f; 

        public float GetTemperature()
        {
            return Temperature; 
        }

        public void SetTemperature(float temp)
        {
            this.Temperature = temp; 
        }

        public Angle GetRotation()
        {
            return angle; 
        }

        public void SetRotation(float dx = 0, float dy = 0, float dz = 0)
        {
            angle.X += dx; 
            angle.Y += dy; 
            angle.Z += dz; 
        }

        public Acceleration GetAcceleration()
        {
            return accel; 
        }

        public void SetAcceleration(float dx = 0, float dy = 0, float dz = 0)
        {
            accel.X = dx; 
            accel.Y = dy; 
            accel.Z = dz;

            float dxAngle = (float)System.Math.Atan2(accel.Y,
                System.Math.Sqrt(System.Math.Pow(accel.X, 2) + System.Math.Pow(accel.Z, 2))); 
            float dyAngle = (float)System.Math.Atan2(accel.X,
                System.Math.Sqrt(System.Math.Pow(accel.Y, 2) + System.Math.Pow(accel.Z, 2))); 
            float dzAngle = (float)System.Math.Atan2(System.Math.Sqrt(System.Math.Pow(accel.X, 2) + System.Math.Pow(accel.Y, 2)),
                accel.Z);

            this.SetRotation(dxAngle, dyAngle, dzAngle);
        }
    }
}