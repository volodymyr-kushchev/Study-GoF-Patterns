using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Patterns.Builder
{
    public class Manager
    {
        IBuilder builder;

        public Manager(IBuilder builder)
        {
            this.builder = builder;
        }

        public void ChangeBuilder(IBuilder builder)
        {
            this.builder = builder;
        }

        public Hotel BuildHotel()
        {
            if (builder is HotelBuilder)
            {
                builder.buildBasement(400);
                builder.buildRooms(50);
                (builder as HotelBuilder).buildPool(3);
                builder.buildWalls(300);
                return (builder as HotelBuilder).getProduct();
            }
            else
            {
                throw new Exception("Hotel: Current builder is not able to build this type of appartment");
            }


        }

        public House BuildHouse()
        {
            if (builder is HouseBuilder)
            {
                builder.buildBasement(80);
                builder.buildRooms(5);
                builder.buildWalls(10);
                return (builder as HouseBuilder).getProduct();
            }
            else
            {
                throw new Exception("House: Current builder is not able to build this type of appartment");
            }
        }
    }
}
