using System;

namespace AppointmentBookingApi.Dtos.Doctor
{
    public class SimpleDoctorInfo
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
