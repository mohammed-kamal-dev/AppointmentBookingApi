namespace AppointmentBookingApi.ResponseWrapper
{
    public class Response<T>
    {
        public int Count { get; set; }

        public T Data { get; set; }
    }
}
