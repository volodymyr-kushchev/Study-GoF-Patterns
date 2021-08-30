using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Patterns.Builder
{
    public interface IBuilder
    {
        public void buildBasement(int area);
        public void buildRooms(int rooms);
        public void buildWalls(int walls);
    }
}
