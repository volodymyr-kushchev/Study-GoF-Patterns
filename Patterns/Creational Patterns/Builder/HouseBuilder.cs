using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Patterns.Builder
{
    public class HouseBuilder : IBuilder
    {
        private House house;

        public HouseBuilder()
        {
            house = new House();
        }

        public void buildBasement(int area)
        {
            house.area = area;
        }

        public void buildWalls(int walls)
        {
            house.walls = walls;
        }

        public void buildRooms(int rooms)
        {
            house.rooms = rooms;
        }

        public House getProduct()
        {
            if (house.area == 0)
            {
                throw new Exception("Hotel has not started building yet");
            }

            return house;
        }
    }
}
