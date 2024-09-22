using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace SnakeGame
{
    public class Snake
    {
        LinkedList<Point> body;

        public LinkedList<Point> Body { get { return body; } }
        public Point Head { get { return body.First(); } }
        public Point Neck { get { return body.ElementAtOrDefault(1);} }
        public Snake()
        {
            body = new LinkedList<Point>();
            body.AddFirst(new Point(7, 7));
        }

        public void Move(Point nextPos)
        {
            body.RemoveLast();
            body.AddFirst(nextPos);
        }

        public void AddTail() 
        {
            body.AddFirst(Head); ;
        }
    }
}
