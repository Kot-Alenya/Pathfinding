using System;

namespace Navigation
{
    public struct Node : IEquatable<Node>
    {
        public Sector Sector;
        public Point Position;

        public Node(Sector sector, Point position)
        {
            Sector = sector;
            Position = position;
        }

        public bool Equals(Node node) => node.Sector == Sector && node.Position.Equals(Position);
    }
}