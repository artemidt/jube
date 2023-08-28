using Jube.Engine.HealthCheck;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace Jube.Data.HealthCheck
{
    internal class DatabaseHealthCheck : IHealthCheck
    {
        private readonly DatabaseAvailabilityChecker _databaseAvailabilityChecker;

        public DatabaseHealthCheck(DatabaseAvailabilityChecker databaseAvailabilityChecker)
        {
            _databaseAvailabilityChecker = databaseAvailabilityChecker;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = await _databaseAvailabilityChecker.IsPostgresAvailableAsync(cancellationToken);

            if (isHealthy)
            {
                return HealthCheckResult.Healthy("A healthy result.");
            }

            return new HealthCheckResult(context.Registration.FailureStatus, "An unhealthy result.");
        }
    }
}
