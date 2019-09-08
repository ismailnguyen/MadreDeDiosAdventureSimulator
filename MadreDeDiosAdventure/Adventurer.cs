using System;
using System.Collections.Generic;

namespace MadreDeDiosAdventure
{
    public class Adventurer
    {
        public string Name { get; }
        public Position Position { get; private set;}
        public Orientation Orientation { get; private set; }
        public IEnumerable<Motion> MotionSequence { get; }
        public int FoundTreasuresCount { get; private set; }

        public Adventurer(
            string name,
            Position position, 
            Orientation orientation, 
            IEnumerable<Motion> motionSequence
        )
        {
            Name = name;
            Position = position;
            Orientation = orientation;
            MotionSequence = motionSequence;
        }

        public void Turn(Orientation orientation)
        {
            Orientation = orientation;
        }

        public void Move(Position position)
        {
            Position = position;
        }

        public void CollectTreasure()
        {
            FoundTreasuresCount++;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Adventurer))
                return false;

            var adventurer = obj as Adventurer;

            return Name.Equals(adventurer.Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override string ToString()
        {
            return $"A - { Name } - { Position } - { Orientation } - { FoundTreasuresCount }";
        }
    }
}