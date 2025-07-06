using MeraStore.Services.Template.Application;
using MeraStore.Services.Template.Common;
using MeraStore.Services.Template.Common.Filters;
using MeraStore.Services.Template.Domain.Entities;

using System.Reflection;

namespace MeraStore.Services.TemplateArchitectureTests;

public class BaseTests
{
  protected static readonly Assembly DomainAssembly = typeof(SampleEntity).Assembly;
  protected static readonly Assembly CommonAssembly = typeof(KeyStore).Assembly;
  protected static readonly Assembly ApplicationAssembly = typeof(ServiceRegistrations).Assembly;
  protected static readonly Assembly InfrastructureAssembly = typeof(MeraStore.Services.Template.Infrastructure.ServiceRegistrations).Assembly;
  protected static readonly Assembly PersistenceAssembly = typeof(MeraStore.Services.Template.Persistence.ServiceRegistrations).Assembly;
  protected static readonly Assembly ApiAssembly = typeof(MaskingFilterFactory).Assembly;


  protected static readonly string? DomainAssemblyName = "MeraStore.Services.Template.Domain";
  protected static readonly string? CommonAssemblyName = CommonAssembly.GetName().Name;
  protected static readonly string? ApplicationAssemblyName = "MeraStore.Services.Template.Application";
  protected static readonly string? InfrastructureAssemblyName = InfrastructureAssembly.GetName().Name;
  protected static readonly string? PersistenceAssemblyName = PersistenceAssembly.GetName().Name;
  protected static readonly string? ApiAssemblyName = ApiAssembly.GetName().Name;
}