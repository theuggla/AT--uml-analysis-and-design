using System;

namespace MemberRegistry.model
{
    public class Boat
    {
        private int _length;
        private BoatType _type;

        public int Length 
        {
            get
            {
                return this._length;
            }
            set
            {
                if (value > 9 && value < 100)
                {
                    this._length = value;
                }
                else
                {
                    throw new InvalidBoatLengthException();
                }
            }
        }

        public BoatType Type 
        {
            get
            {
                return  this._type;
            } 
            set
            {
                try 
                {
                    this._type = value;
                }
                catch (Exception)
                {
                    throw new InvalidBoatTypeException();
                }
            }
        }

        public int BoatID {get;set;}

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