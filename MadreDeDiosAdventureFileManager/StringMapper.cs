using MadreDeDiosAdventure;
using System;
using System.Collections.Generic;

namespace MadreDeDiosAdventureFileManager
{
    public class StringMapper
    {
        private readonly string _content;

        public StringMapper(string content)
        {
            _content = content;
        }

        public Map Map()
        {
            string[] elements = _content.Split(" - ");

            int width = 0, height = 0;
            if (elements[0] == "C")
            {
                int.TryParse(elements[1], out width);
                int.TryParse(elements[2], out height);
            }

            var mountains = new List<Mountain>();
            if (elements[0] == "M")
            {
                int.TryParse(elements[1], out int horizontalAxis);
                int.TryParse(elements[2], out int verticalAxis);

                mountains.Add(new Mountain(horizontalAxis, verticalAxis));
            }

            var treasures = new List<Treasure>();
            if (elements[0] == "T")
            {
                int.TryParse(elements[1], out int horizontalAxis);
                int.TryParse(elements[2], out int verticalAxis);
                int.TryParse(elements[3], out int count);

                treasures.Add(new Treasure(horizontalAxis, verticalAxis, count));
            }

            var adventurers = new List<Adventurer>();
            if (elements[0] == "A")
            {
                string name = elements[1];
                int.TryParse(elements[2], out int horizontalAxis);
                int.TryParse(elements[3], out int verticalAxis);

                Orientation orientation = ParseOrientation(elements[4]);
                List<Motion> motionSequence = ParseMotionSequence(elements[5]);

                adventurers.Add(new Adventurer(name, horizontalAxis, verticalAxis, orientation, motionSequence));
            }

            return new Map
            {
                Width = width,
                Height = height,
                Mountains = mountains,
                Treasures = treasures,
                Adventurers = adventurers
            };
        }

        private Orientation ParseOrientation(string orientationString)
        {
            switch (orientationString)
            {
                case "S":
                    return Orientation.South;

                case "E":
                    return Orientation.Est;

                case "O":
                    return Orientation.West;

                case "N":
                default:
                    return Orientation.North;
            }
        }

        private List<Motion> ParseMotionSequence(string motionSequenceString)
        {
            List<Motion> motionSequence = new List<Motion>();

            foreach (char motion in motionSequenceString)
            {
                switch (motion)
                {
                    case 'A':
                        motionSequence.Add(Motion.MoveForward);
                        break;

                    case 'D':
                        motionSequence.Add(Motion.TurnRight);
                        break;

                    case 'G':
                        motionSequence.Add(Motion.TurnLeft);
                        break;
                }
            }

            return motionSequence;
        }
    }
}
