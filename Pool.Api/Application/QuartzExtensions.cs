using Quartz;

namespace Pool.Api.Application;

internal static class QuartzExtensions
{
	public static void AddJobAndTrigger<T>(
		this IServiceCollectionQuartzConfigurator quartz,
		IConfiguration config)
		where T : IJob
	{
		// Use the name of the IJob as the appsettings.json key
		var jobName = typeof(T).Name;

		// Try and load the schedule from configuration
		var cronSchedule = config[jobName];

		// Some minor validation
		if (string.IsNullOrEmpty(cronSchedule))
		{
			throw new Exception($"No Quartz.NET Cron schedule found for job in configuration at {jobName}");
		}

		var jobKey = new JobKey(jobName);
		quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

		quartz.AddTrigger(opts => opts
			.ForJob(jobKey)
			.WithIdentity(jobName + "-trigger")
			.WithCronSchedule(cronSchedule));
	}
}