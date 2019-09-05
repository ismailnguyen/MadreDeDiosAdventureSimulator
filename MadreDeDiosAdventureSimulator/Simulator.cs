using MadreDeDiosAdventure;
using System;

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
                int initialHorizontalAxis = adventurer.HorizontalAxis;
                int initialVerticalAxis = adventurer.VerticalAxis;
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
                    }
                }
            }
        }
    }
}
