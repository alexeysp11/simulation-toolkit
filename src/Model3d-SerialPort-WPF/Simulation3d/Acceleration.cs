namespace Simulation3d
{
    public struct Acceleration
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public void AdjustX(float step)
        {
            if (X > 0) 
            {
                X -= step; 
            }
            else if (X < 0)
            {
                X += step;
            }
        }

        public void AdjustY(float step)
        {
            if (Y > 0) 
            {
                Y -= step; 
            }
            else if (Y < 0)
            {
                Y += step;
            }
        }

        public void AdjustZ(float step)
        {
            if (Z > 0) 
            {
                Z -= step; 
            }
            else if (Z < 0)
            {
                Z += step;
            }
        }
    }
}