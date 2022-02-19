using AppointmentBookingApi.Data;
using AppointmentBookingApi.Data.IRepository;
using AppointmentBookingApi.Data.Repository;
using AppointmentBookingApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Extensions

{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // c.IncludeXmlComments(string.Format(@"{0}\SchoolManagement.WebApi.API.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AppointmentBooking Api",
                    Contact = new OpenApiContact
                    {
                        Name = "M.Kamal",
                        Email = "Mohammed.k.cs21@gmail.com",

                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });
            });
        }

        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppointmentContext>(options => options.UseSqlServer( configuration.GetConnectionString("AppointmentDb")));
        }


        public static void AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IDateTimeService, DateTimeService>();

            services.AddScoped<IPeriodRepository, PeriodRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
       
    }
}
