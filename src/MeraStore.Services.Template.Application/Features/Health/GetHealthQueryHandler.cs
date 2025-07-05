using MediatR;

using MeraStore.Services.Template.Common;

namespace MeraStore.Services.Template.Application.Features.Health;

public class GetHealthQueryHandler : IRequestHandler<GetHealthQuery, HealthResponse>
{
  public Task<HealthResponse> Handle(GetHealthQuery request, CancellationToken cancellationToken)
  {
    var response = new HealthResponse
    {
      Status = "Healthy",
      Service = KeyStore.ServiceName,
      Timestamp = DateTime.UtcNow
    };

    return Task.FromResult(response);
  }
}