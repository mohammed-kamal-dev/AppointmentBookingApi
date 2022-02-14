using AppointmentBookingApi.Dtos.Appointment;
using System;
using System.Collections.Generic;

namespace AppointmentBookingApi.Dtos.Doctor
{
    public class DoctorForGetDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<AppointmentForGetDto> Appointments { get; set; }
    }
}
