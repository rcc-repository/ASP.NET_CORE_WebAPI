﻿using System;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "364b5ae8b67a4f0f9bd2336cd96a2722";
                o.LogId = new Guid("fe2c0018-0b26-43d7-9c4e-d9920762411a");
            });

            //services.AddLogging(builder =>
            //{
            //    builder.AddElmahIo(o =>
            //    {
            //        o.ApiKey = "388dd3a277cb44c4aa128b5c899a3106";
            //        o.LogId = new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096");
            //    });
            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            //});

            //services.AddHealthChecks()
            //    .AddElmahIoPublisher("364b5ae8b67a4f0f9bd2336cd96a2722", new Guid("fe2c0018-0b26-43d7-9c4e-d9920762411a"),"API Fornecedores")
            //    .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
            //    .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            //services.AddHealthChecksUI();
             
            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            //app.UseHealthChecks("/api/hc", new HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});
            //app.UseHealthChecksUI(options => { options.UIPath = "/api/hc-ui"; });

            return app;
        }
    }
}