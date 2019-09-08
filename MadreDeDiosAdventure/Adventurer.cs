using System;
using System.Collections.Generic;

namespace MadreDeDiosAdventure
{
    public class Adventurer
    {
        public string Name { get; }
        public int HorizontalAxis { get; private set; }
        public int VerticalAxis { get; private set; }
        public Orientation Orientation { get; private set; }
        public IEnumerable<Motion> MotionSequence { get; }
        public int FoundTreasuresCount { get; private set; }

        public Adventurer(
            string name, 
            int horizontalAxis, 
            int verticalAxis, 
            Orientation orientation, 
            IEnumerable<Motion> motionSequence
        )
        {
            Name = name;
            HorizontalAxis = horizontalAxis;
            VerticalAxis = verticalAxis;
            Orientation = orientation;
            MotionSequence = motionSequence;
        }

        public void Turn(Orientation orientation)
        {
            Orientation = orientation;
        }

        public void GoUp()
        {
            VerticalAxis++;
        }

        public void GoDown()
        {
            VerticalAxis--;
        }

        public void GoRight()
        {
            HorizontalAxis++;
        }

        public void GoLeft()
        {
            HorizontalAxis--;
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
            return $"A - { Name } - { HorizontalAxis } - { VerticalAxis } - { Orientation.ToString() } - { FoundTreasuresCount }";
        }
    }
}