using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Patterns.Builder
{
    public class HotelBuilder : IBuilder
    {
        private Hotel hotel;

        public HotelBuilder()
        {
            hotel = new Hotel();
        }

        public void buildBasement(int area)
        {
            hotel.area = area;
        }

        public void buildWalls(int walls)
        {
            hotel.walls = walls;
        }

        public void buildPool(int pools)
        {
            hotel.pools = pools;
        }

        public void buildRooms(int rooms)
        {
            hotel.rooms = rooms;
        }

        public Hotel getProduct()
        {
            if (hotel.area == 0)
            {
                throw new Exception("Hotel has not started building yet");
            }

            return hotel;
        }
    }
}
