using Microsoft.AspNetCore.Builder;


namespace AppointmentBookingApi.Extensions
{

    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppointmentBookingApi");
            });
        }

    }
}
