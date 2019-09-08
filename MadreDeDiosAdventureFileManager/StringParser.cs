using MadreDeDiosAdventure;
using System.Collections.Generic;
using System.IO;

namespace MadreDeDiosAdventureFileManager
{
    public class StringParser : IContentParser
    {
        public Map Parse(string content)
        {
            int width = 0, height = 0;
            var mountains = new List<Mountain>();
            var treasures = new List<Treasure>();
            var adventurers = new List<Adventurer>();

            using (StringReader reader = new StringReader(content))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] elements = line.Split(" - ");

                    if (elements[0] == "C")
                    {
                        int.TryParse(elements[1], out width);
                        int.TryParse(elements[2], out height);
                    }

                    else if (elements[0] == "M")
                    {
                        int.TryParse(elements[1], out int horizontalAxis);
                        int.TryParse(elements[2], out int verticalAxis);

                        mountains.Add(
                            new Mountain(
                                new Position(horizontalAxis, verticalAxis)
                            )
                        );
                    }

                    else if (elements[0] == "T")
                    {
                        int.TryParse(elements[1], out int horizontalAxis);
                        int.TryParse(elements[2], out int verticalAxis);
                        int.TryParse(elements[3], out int count);

                        treasures.Add(
                            new Treasure(
                                new Position(horizontalAxis, verticalAxis),
                                count
                            )
                        );
                    }

                    else if (elements[0] == "A")
                    {
                        string name = elements[1];
                        int.TryParse(elements[2], out int horizontalAxis);
                        int.TryParse(elements[3], out int verticalAxis);

                        Orientation orientation = ParseOrientation(elements[4]);
                        List<Motion> motionSequence = ParseMotionSequence(elements[5]);

                        adventurers.Add(
                            new Adventurer(
                                name, 
                                new Position(horizontalAxis, verticalAxis), 
                                orientation, 
                                motionSequence
                            )
                        );
                    }
                }
            }

            return new Map
            (
                width,
                height,
                mountains,
                treasures,
                adventurers
            );
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
