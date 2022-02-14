using AppointmentBookingApi.Dtos.Appointment;
using System;
using System.Collections.Generic;

namespace AppointmentBookingApi.Dtos.Patient
{
    public class PatientForGetDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
