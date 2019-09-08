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
                foreach (var motion in adventurer.MotionSequence)
                {
                    Orientation orientation = adventurer.Orientation;

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
                            if (IsThereAMountain(adventurer.HorizontalAxis, adventurer.VerticalAxis - 1))
                                continue;

                            if (IsThereATreasure(adventurer.HorizontalAxis, adventurer.VerticalAxis - 1))
                            {
                                adventurer.CollectTreasure();
                                Map.RemoveTreasure(adventurer.HorizontalAxis, adventurer.VerticalAxis - 1);
                            }

                            adventurer.GoDown();
                        }
                        else if (orientation.Equals(Orientation.South))
                        {
                            if (IsThereAMountain(adventurer.HorizontalAxis, adventurer.VerticalAxis + 1))
                                continue;

                            if (IsThereATreasure(adventurer.HorizontalAxis, adventurer.VerticalAxis + 1))
                            {
                                adventurer.CollectTreasure();
                                Map.RemoveTreasure(adventurer.HorizontalAxis, adventurer.VerticalAxis + 1);
                            }

                            adventurer.GoUp();
                        }
                        else if (orientation.Equals(Orientation.Est))
                        {
                            if (IsThereAMountain(adventurer.HorizontalAxis + 1, adventurer.VerticalAxis))
                                continue;

                            if (IsThereATreasure(adventurer.HorizontalAxis + 1, adventurer.VerticalAxis))
                            {
                                adventurer.CollectTreasure();
                                Map.RemoveTreasure(adventurer.HorizontalAxis + 1, adventurer.VerticalAxis);
                            }

                            adventurer.GoRight();
                        }
                        else if (orientation.Equals(Orientation.West))
                        {
                            if (IsThereAMountain(adventurer.HorizontalAxis - 1, adventurer.VerticalAxis))
                                continue;

                            if (IsThereATreasure(adventurer.HorizontalAxis - 1, adventurer.VerticalAxis))
                            {
                                adventurer.CollectTreasure();
                                Map.RemoveTreasure(adventurer.HorizontalAxis - 1, adventurer.VerticalAxis);
                            }

                            adventurer.GoLeft();
                        }
                    }
                }
            }
        }

        private bool IsThereATreasure(int horizontalAxis, int verticalAxis)
        {
            return Map.Treasures.Any(treasure => treasure.HorizontalAxis == horizontalAxis && treasure.VerticalAxis == verticalAxis);
        }

        private bool IsThereAMountain(int horizontalAxis, int verticalAxis)
        {
            return Map.Mountains.Any(mountain => mountain.HorizontalAxis == horizontalAxis && mountain.VerticalAxis == verticalAxis);
        }
    }
}
