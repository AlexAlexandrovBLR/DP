﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.Data.Entities;

namespace BusStation.Data.Context
{
    public class BusStationtInitializer : DropCreateDatabaseAlways<BusStationContext>
    {
        protected override void Seed(BusStationContext context)
        {
            #region Add Route

            BusStop busStopBrest = new BusStop
            {
                Name = "Брест",
                Latitude = 52.09897581,
                Longitude = 23.68256383
            };
            BusStop busStopGrodno = new BusStop
            {
                Name = "Гродно",
                Latitude = 53.67987998,
                Longitude = 23.82905076
            };
            BusStop busStopVitebsk = new BusStop
            {
                Name = "Витебск",
                Latitude = 55.18150427,
                Longitude = 30.20338671
            };
            BusStop busStopMogilev = new BusStop
            {
                Name = "Могилев",
                Latitude = 53.89130648,
                Longitude = 30.33362751
            };
            BusStop busStopGomel = new BusStop
            {
                Name = "Гомель",
                Latitude = 52.42028342,
                Longitude = 31.01069977
            };
            BusStop busStopMinsk = new BusStop
            {
                Name = "Минск",
                Latitude = 53.89890282,
                Longitude = 27.55836584
            };

            context.BusStops.AddRange(new List<BusStop>
            {
                busStopBrest,
                busStopGrodno,
                busStopVitebsk,
                busStopMogilev,
                busStopGomel,
                busStopMinsk
            });

            Route routeNumOne = new Route
            {
                RouteNumber = 1,
                NumberOfSeats = 32,
                Price = 20
            };
            Route routeNumTwo = new Route
            {
                RouteNumber = 2,
                NumberOfSeats = 20,
                Price = 10
            };
            Route routeNumThree = new Route
            {
                RouteNumber = 3,
                NumberOfSeats = 36,
                Price = 16
            };
            Route routeNumFour = new Route
            {
                RouteNumber = 4,
                NumberOfSeats = 30,
                Price = 12
            };
            Route routeNumFive = new Route
            {
                RouteNumber = 5,
                NumberOfSeats = 18,
                Price = 20
            };

            context.Routes.AddRange(new List<Route>
            {
                routeNumOne,
                routeNumTwo,
                routeNumThree,
                routeNumFour,
                routeNumFive
            });

            TypeStop typeStopDeparture = new TypeStop
            {
                Name = "Departure"
            };
            TypeStop typeStopArrival = new TypeStop
            {
                Name = "Arrival"
            };

            context.TypeStops.AddRange(new List<TypeStop>
            {
                typeStopDeparture,
                typeStopArrival
            });

            RouteStop routeBrestDeparture = new RouteStop
            {
                Route = routeNumOne,
                BusStop = busStopMinsk,
                TypeStop = typeStopDeparture
            };
            RouteStop routeBrestArrival = new RouteStop
            {
                Route = routeNumOne,
                BusStop = busStopBrest,
                TypeStop = typeStopArrival
            };

            RouteStop routeGrodnoDeparture = new RouteStop
            {
                Route = routeNumTwo,
                BusStop = busStopMinsk,
                TypeStop = typeStopDeparture
            };
            RouteStop routeGrodnoArrival = new RouteStop
            {
                Route = routeNumTwo,
                BusStop = busStopGrodno,
                TypeStop = typeStopArrival
            };

            RouteStop routeVitebskDeparture = new RouteStop
            {
                Route = routeNumThree,
                BusStop = busStopMinsk,
                TypeStop = typeStopDeparture
            };
            RouteStop routeVitebskArrival = new RouteStop
            {
                Route = routeNumThree,
                BusStop = busStopVitebsk,
                TypeStop = typeStopArrival
            };
            RouteStop routeMogilevDeparture = new RouteStop
            {
                Route = routeNumFour,
                BusStop = busStopMinsk,
                TypeStop = typeStopDeparture
            };
            RouteStop routeMogilevArrival = new RouteStop
            {
                Route = routeNumFour,
                BusStop = busStopMogilev,
                TypeStop = typeStopArrival
            };
            RouteStop routeGomelDeparture = new RouteStop
            {
                Route = routeNumFive,
                BusStop = busStopMinsk,
                TypeStop = typeStopDeparture
            };
            RouteStop routeGomelArrival = new RouteStop
            {
                Route = routeNumFive,
                BusStop = busStopGomel,
                TypeStop = typeStopArrival
            };

            context.RouteStops.AddRange(new List<RouteStop>
            {
                routeBrestDeparture,
                routeBrestArrival,
                routeGrodnoDeparture,
                routeGrodnoArrival,
                routeVitebskDeparture,
                routeVitebskArrival,
                routeMogilevDeparture,
                routeMogilevArrival,
                routeGomelDeparture,
                routeGomelArrival
            });


            #endregion


            TimeTable timeTableGrodno = new TimeTable
            {
                Arrival = DateTime.Now.AddHours(4),
                Departure = DateTime.Now.AddHours(7),
                Seats = routeNumTwo.NumberOfSeats
            };

            TimeTable timeTableGrodnoTwo = new TimeTable
            {
                Arrival = DateTime.Now.AddHours(7),
                Departure = DateTime.Now.AddHours(5),
                Seats = routeNumTwo.NumberOfSeats
            };
            TimeTable timeTableGrodnoThree = new TimeTable
            {
                Arrival = DateTime.Now.AddMonths(-1).AddHours(7),
                Departure = DateTime.Now.AddMonths(-1).AddHours(5),
                Seats = routeNumTwo.NumberOfSeats
            };
            TimeTable timeTableGrodnoFour = new TimeTable
            {
                Arrival = DateTime.Now.AddMonths(-3).AddHours(7),
                Departure = DateTime.Now.AddMonths(-3).AddHours(5),
                Seats = routeNumTwo.NumberOfSeats
            };

            routeNumTwo.TimeTables.Add(timeTableGrodno);
            routeNumTwo.TimeTables.Add(timeTableGrodnoTwo);
            routeNumTwo.TimeTables.Add(timeTableGrodnoThree);
            routeNumTwo.TimeTables.Add(timeTableGrodnoFour);

            var roleAdmin = new Role {Name = "Admin"};

            context.Roles.Add(roleAdmin);
            context.Roles.Add(new Role { Name = "User" });

            User admin = new User
            {
                Email = "admin@admin.com",
                Password = "AOuWU2uXEY7LEJGczeF5LR2d33ngJk4D3Hzg2IoFu8jBnIbseTs0zC+iLiC7s/Vkuw==",
                Role = roleAdmin
            };

            

            Order orderOneAdmin= new Order
            {
                DepartureDate = DateTime.Now.AddMonths(-7),
                Description = $"Минск - Брест, {DateTime.Now.AddMonths(-7):g}, в количестве 1 шт.",
                OperationDate = DateTime.Now.AddMonths(-8)
            };

            Order orderTwoAdmin = new Order
            {
                DepartureDate = DateTime.Now.AddMonths(-1),
                Description = $"Минск - Витебск, {DateTime.Now.AddMonths(-1):g}, в количестве 1 шт.",
                OperationDate = DateTime.Now.AddMonths(-2)
            };

            admin.Orders.Add(orderOneAdmin);
            admin.Orders.Add(orderTwoAdmin);

            context.Users.Add(admin);
            context.SaveChanges();
        }
    }
}
