using Agentie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agentie.Dto
{
    public class ReservationDtoGet
    {
        public long Id { get; set; }

        public long Sum { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public Models.Currency Currency { get; set; }

        public Models.Type Type { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public Boolean Documents { get; set; }

        public int RemarksNumber { get; set; }

        public static ReservationDtoGet GetDtoFromReservation(Reservation reservation)
        {
            return new ReservationDtoGet
            {
                Id = reservation.Id,
                Sum = reservation.Sum,
                Location = reservation.Location,
                Date = reservation.Date,
                Currency = reservation.Currency,
                Type = reservation.Type,
                DepartureTime = reservation.Date,
                ArrivalTime = reservation.Date,
                Documents = reservation.Documents,
                RemarksNumber = reservation.Remarks.Count
            };
        }
    }
}
