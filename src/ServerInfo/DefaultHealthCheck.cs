﻿using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ServerInfo
{
    public class DefaultHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = true;

            if (isHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("Healthy"));
            }

            return Task.FromResult(
                new HealthCheckResult(
                    context.Registration.FailureStatus, "Not Healthy"));
        }
    }
}
