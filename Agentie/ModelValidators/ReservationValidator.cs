using Agentie.Models;
using FluentValidation;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Agentie.ModelValidators
{
    public class ReservationValidator : AbstractValidator<Reservation>
	{
		public ReservationValidator()
		{
			RuleFor(x => x.Sum).InclusiveBetween(100, 15000);
			RuleFor(x => x.Date)
				.NotEmpty().WithMessage("please compleate the date")
				.LessThanOrEqualTo(x => DateTime.Now);
			RuleFor(x=> x.DepartureTime).LessThan(x => x.ArrivalTime).WithMessage("the journey must have at least 1 night");
		}
	}
}
