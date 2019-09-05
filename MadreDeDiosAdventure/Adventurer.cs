using System;
using System.Collections.Generic;

namespace MadreDeDiosAdventure
{
    public class Adventurer
    {
        private readonly string _name;
        private readonly int _horizontalAxis;
        private readonly int _verticalAxis;
        private readonly Orientation _orientation;
        private readonly IEnumerable<Motion> _motionSequence;

        public Adventurer(
            string name, 
            int horizontalAxis, 
            int verticalAxis, 
            Orientation orientation, 
            IEnumerable<Motion> motionSequence
        )
        {
            _name = name;
            _horizontalAxis = horizontalAxis;
            _verticalAxis = verticalAxis;
            _orientation = orientation;
            _motionSequence = motionSequence;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Adventurer))
                return false;

            var adventurer = obj as Adventurer;

            return _name.Equals(adventurer._name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name);
        }
    }
}