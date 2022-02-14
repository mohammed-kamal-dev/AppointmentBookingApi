using System;

namespace AppointmentBookingApi.Entities
{
    public class AuditableEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
