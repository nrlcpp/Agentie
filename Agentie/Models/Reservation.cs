﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Agentie.Models
{
    public enum Type
    {
        circuit,
        stay,
        accommodation,
        transport,
        others
    }
    public enum Currency
    {
        EUR,
        RON,
        USD
    }
    public class Reservation
    {
            public long Id { get; set; }

         //   public string Description { get; set; }

            public long Sum { get; set; }

            public string Location { get; set; }

            public DateTime Date { get; set; }

            public Currency Currency { get; set; }

            public Type Type { get; set; }

            public DateTime DepartureTime { get; set; }

            public DateTime ArrivalTime { get; set; }

            public Boolean Documents { get; set; }

            public List<Remarks> Remarks { get; set; }
    }
    }

