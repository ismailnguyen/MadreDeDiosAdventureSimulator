using MadreDeDiosAdventure;

namespace MadreDeDiosAdventureSimulator
{
    public class Simulator
    {
        public Map Map { get; private set; }

        public Simulator(Map map)
        {
            Map = map;
        }

        public void Simulate()
        {
            foreach (var adventurer in Map.Adventurers)
            {
                int horizontalAxis = adventurer.HorizontalAxis;
                int verticalAxis = adventurer.VerticalAxis;
                Orientation orientation = adventurer.Orientation;

                foreach (var motion in adventurer.MotionSequence)
                {
                    if (motion == Motion.TurnLeft)
                    {
                        // Update orientation
                        orientation = orientation.Left;
                    }
                    else if (motion == Motion.TurnRight)
                    {
                        // Update orientation
                        orientation = orientation.Right;
                    }
                    else if (motion == Motion.MoveForward)
                    {
                        // Update axis
                        if (orientation.Equals(Orientation.North))
                        {
                            verticalAxis--;
                        }
                        else if (orientation.Equals(Orientation.South))
                        {
                            verticalAxis++;
                        }
                        else if (orientation.Equals(Orientation.Est))
                        {
                            horizontalAxis++;
                        }
                        else if (orientation.Equals(Orientation.West))
                        {
                            horizontalAxis--;
                        }
                    }
                }

                adventurer.HorizontalAxis = horizontalAxis;
                adventurer.VerticalAxis = verticalAxis;
                adventurer.Orientation = orientation;
            }
        }
    }
}
