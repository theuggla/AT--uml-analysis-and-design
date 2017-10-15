namespace MemberRegistry.model
{
    public class Boat
    {
        public int Length {get; set;}
        public BoatType Type {get; set;}
        public int BoatID {get; set;}

        public Boat(BoatType type, int length, int boatID)
        {
            this.Length = length;
            this.Type = type;
            this.BoatID = boatID;
        }

        public void Update(BoatType type, int length)
        {
            this.Length = length;
            this.Type = type;
        }
    }
}