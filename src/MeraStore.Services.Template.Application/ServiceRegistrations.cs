﻿using MediatR;
using MeraStore.Services.Template.Application.Behaviours;
using MeraStore.Services.Template.Application.Features.Health;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeraStore.Services.Template.Application;

public static class ServiceRegistrations
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
  {

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetHealthQuery).Assembly));
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    return services;
  }
}