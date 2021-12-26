using NorthWind.Sales.IoC;
using NorthWInd.Sales.WebApi.Endpoints;
using System.Reflection;
using WebExceptionHandlerAPI;
using WebExceptionHandlerAPI.Interfaces;
using WebExceptionHandlerAPIMiddleWare;

namespace NorthWInd.Sales.WebApi
{
    public static class WebApplicationHelper
    {
        public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddNorthwindSalesServices(builder.Configuration, "NorthWinDB");
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            return builder.Build();
        }

        public static WebApplication ConfigureWebApplication(this WebApplication app)
        {
            app.UseExceptionHandler(builder => 
                builder.UseWebExceptionHandlerPresenter(
                    app.Environment, 
                    app.Services.GetService<IWebExceptionPresenter>()));


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();

            app.UseApplicationEndpints();

            return app;
        }
    }
}
