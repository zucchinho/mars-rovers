namespace Nasa.MarsMission.Rovers.Airborne
{
    public class DroneStatus
    {
        public double[] Position { get; set; }
        
        public double Bearing { get; set; }
        
        public double Height { get; set; }

        public override string ToString()
        {
            return $"{string.Join(' ', Position)} {Height} {Bearing}";
        }
    }
}