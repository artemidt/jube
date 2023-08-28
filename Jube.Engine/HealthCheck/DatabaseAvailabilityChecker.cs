using Jube.Data.Context;
using Jube.DynamicEnvironment;
using Jube.Engine.Helpers;
using Nest;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jube.Engine.HealthCheck
{
    public class DatabaseAvailabilityChecker
    {
        private readonly DynamicEnvironment.DynamicEnvironment _dynamicEnvironment;

        public DatabaseAvailabilityChecker(DynamicEnvironment.DynamicEnvironment dynamicEnvironment)
        {
            _dynamicEnvironment = dynamicEnvironment;
        }

        public Task<bool> IsPostgresAvailableAsync(CancellationToken cancellationToken = default)
        {
            
            try
            {
                using (var dbContext = DataConnectionDbContext.GetDbContextDataConnection(_dynamicEnvironment.AppSettings("ConnectionString")))
                {
                    using var command = dbContext.Connection.CreateCommand();
                    command.CommandText = "SELECT 1;";
                    var result = command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
