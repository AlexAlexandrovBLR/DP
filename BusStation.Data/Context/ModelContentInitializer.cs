using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.Data.Entities;

namespace BusStation.Data.Context
{
    public class ModelContentInitializer : DropCreateDatabaseIfModelChanges<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            var busstops1 = new BusStops
            {
                Name = "Минск",
                Description = "Центральная станция",
            };
            context.BusStopses.Add(busstops1);

            var busstops2 = new BusStops
            {
                Name = "Брест",
                Description = "Бреская область",
            };
            context.BusStopses.Add(busstops2);

            var busstops3 = new BusStops
            {
                Name = "Гродно",
                Description = "Гродненская область",
            };
            context.BusStopses.Add(busstops3);

            var busstops4 = new BusStops
            {
                Name = "Витебск",
                Description = "Витебская область",
            };
            context.BusStopses.Add(busstops4);

            var busstops5 = new BusStops
            {
                Name = "Магилев",
                Description = "Магилевская область",
            };
            context.BusStopses.Add(busstops5);

            var busstops6 = new BusStops
            {
                Name = "Гомель",
                Description = "Гомельская область",
            };
            context.BusStopses.Add(busstops6);

            var busstops7 = new BusStops
            {
                Name = "Барановичи",
                Description = "Транзитная станция",
            };
            context.BusStopses.Add(busstops7);

            var busstops8 = new BusStops
            {
                Name = "Лида",
                Description = "Транзитная станция",
            };
            context.BusStopses.Add(busstops8);

            var busstops9 = new BusStops
            {
                Name = "Молодечно",
                Description = "Транзитная станция",
            };
            context.BusStopses.Add(busstops9);

            var busstops10 = new BusStops
            {
                Name = "Борисов",
                Description = "Транзитная станция",
            };
            context.BusStopses.Add(busstops10);

            var busstops11 = new BusStops
            {
                Name = "Бобруйск",
                Description = "Транзитная станция",
            };
            context.BusStopses.Add(busstops11);

            var customers1 = new Customers()
            {
                Surname = "Александров",
                Name = "Алексей",
                Mail = "mail1@tut.by",
                Password = "1234",
                DateOfBirth = new DateTime(1990,06,22),
            };
            context.Customerses.Add(customers1);

            var customers2 = new Customers()
            {
                Surname = "Дроздовский",
                Name = "Анатолий",
                Mail = "mail2@tut.by",
                Password = "1234",
                DateOfBirth = new DateTime(1985, 12, 04),
            };
            context.Customerses.Add(customers2);

            var flights1 = new Flights()
            {
                DepartureTime = new DateTime(2019,03,12,13,30,00),
                ArrivalTime = new DateTime(2019, 03, 12, 15, 00, 00),
                FlightNumber = 1,
                FlightName = "Минск-Гродно",
                NumberOfSeats = 50,
                TicketPrice = 15,
            };
            context.Flightses.Add(flights1);

            var flights2 = new Flights()
            {
                DepartureTime = new DateTime(2019, 03, 12, 11, 30, 00),
                ArrivalTime = new DateTime(2019, 03, 12, 15, 00, 00),
                FlightNumber = 2,
                FlightName = "Минск-Брест",
                NumberOfSeats = 50,
                TicketPrice = 20,
            };
            context.Flightses.Add(flights2);

            var flights3 = new Flights()
            {
                DepartureTime = new DateTime(2019, 03, 11, 10, 00, 00),
                ArrivalTime = new DateTime(2019, 03, 11, 13, 20, 00),
                FlightNumber = 3,
                FlightName = "Минск-Магилев",
                NumberOfSeats = 50,
                TicketPrice = 15,
            };
            context.Flightses.Add(flights3);

            var orders1 = new Orders()
            {
                Status = "Оплачено",
            };
            context.Orderses.Add(orders1);

            var orders2 = new Orders()
            {
                Status = "Зарезервировано",
            };
            context.Orderses.Add(orders2);

            var orders3 = new Orders()
            {
                Status = "Отменено",
            };
            context.Orderses.Add(orders3);

            var ticket1 = new Tickets()
            {
                DocumentNumber = "MP210345",
                PlaceNumber = 13,
            };
            context.Ticketses.Add(ticket1);

            var ticket2 = new Tickets()
            {
                DocumentNumber = "MP210355",
                PlaceNumber = 34,
            };
            context.Ticketses.Add(ticket2);


        }
    }
}
