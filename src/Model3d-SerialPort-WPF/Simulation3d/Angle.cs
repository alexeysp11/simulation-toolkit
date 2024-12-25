namespace Simulation3d
{
    public struct Angle
    {
        private float x;
        public float X
        {
            get { return x; }
            set
            {
                x = value; 
                AdjustAngle(ref x); 
            }
        }

        private float y;
        public float Y
        {
            get { return y; }
            set
            {
                y = value; 
                AdjustAngle(ref y); 
            }
        }
        
        private float z;
        public float Z
        {
            get { return z; }
            set 
            {
                z = value; 
                AdjustAngle(ref z); 
            }
        }

        private void AdjustAngle(ref float angle)
        {
            while (angle <= -360 || angle >= 360)
            {
                if (angle >= 360)
                {
                    angle -= 360; 
                }
                else if (angle <= -360)
                {
                    angle += 360; 
                }
            }
        }
    }
}