using System.Linq;
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
                        adventurer.Turn(orientation.Left());
                    }
                    else if (motion == Motion.TurnRight)
                    {
                        adventurer.Turn(orientation.Right());
                    }
                    else if (motion == Motion.MoveForward)
                    {
                        if (orientation.Equals(Orientation.North))
                        {
                            if (IsMountain(horizontalAxis, verticalAxis-1))
                                continue;

                            if (IsTreasure(horizontalAxis, verticalAxis - 1))
                            {
                                adventurer.CollectTreasure();
                            }

                            adventurer.GoDown();
                        }
                        else if (orientation.Equals(Orientation.South))
                        {
                            adventurer.GoUp();
                        }
                        else if (orientation.Equals(Orientation.Est))
                        {
                            adventurer.GoRight();
                        }
                        else if (orientation.Equals(Orientation.West))
                        {
                            adventurer.GoLeft();
                        }
                    }
                }
            }
        }

        private bool IsTreasure(int horizontalAxis, int verticalAxis)
        {
            return Map.Treasures.Any(treasure => treasure.HorizontalAxis == horizontalAxis && treasure.VerticalAxis == verticalAxis);
        }

        private bool IsMountain(int horizontalAxis, int verticalAxis)
        {
            return Map.Mountains.Any(mountain => mountain.HorizontalAxis == horizontalAxis && mountain.VerticalAxis == verticalAxis);
        }
    }
}
