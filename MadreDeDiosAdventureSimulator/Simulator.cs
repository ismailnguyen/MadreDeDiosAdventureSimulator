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
                    Orientation currentOrientation = adventurer.Orientation;

                    if (motion == Motion.TurnLeft)
                    {
                        adventurer.Turn(currentOrientation.Left());
                    }
                    else if (motion == Motion.TurnRight)
                    {
                        adventurer.Turn(currentOrientation.Right());
                    }
                    else if (motion == Motion.MoveForward)
                    {
                        Position nextPosition = adventurer.Position.Next(currentOrientation);

                        if (IsThereAMountain(nextPosition))
                            continue;

                        if (IsThereATreasure(nextPosition))
                        {
                            adventurer.CollectTreasure();
                            Map.RemoveTreasure(nextPosition);
                        }

                        adventurer.Move(nextPosition);
                    }
                }
            }
        }

        private bool IsThereATreasure(Position position)
        {
            return Map.Treasures.Any(treasure => treasure.Position.Equals(position));
        }

        private bool IsThereAMountain(Position position)
        {
            return Map.Mountains.Any(mountain => mountain.Position.Equals(position));
        }
    }
}
