using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Data.Repository;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            #region Application Layer

            service.AddScoped<ICourseService, CourseService>();

            #endregion

            #region Data Layer

            service.AddScoped<ICourseRepository, CourseRepository>();

            #endregion
        }
    }
}
