using System;
using System.Collections.Generic;

namespace AppointmentBookingApi.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public List<Schedule> Schedules { get; set; }

        public List<Appointment> Appointments { get; set; }

    }
}
