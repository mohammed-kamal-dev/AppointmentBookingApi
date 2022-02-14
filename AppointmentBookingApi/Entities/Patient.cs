using System;
using System.Collections.Generic;

namespace AppointmentBookingApi.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
