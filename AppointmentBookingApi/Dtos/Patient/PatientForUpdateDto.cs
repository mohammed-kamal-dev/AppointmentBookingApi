using System;

namespace AppointmentBookingApi.Dtos.Patient
{
    public class PatientForUpdateDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
