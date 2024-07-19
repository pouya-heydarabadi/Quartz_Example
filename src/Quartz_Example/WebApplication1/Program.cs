using Quartz;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Quartz

builder.Services.AddQuartz(options =>
{

    var jobKey = JobKey.Create(nameof(LoggingMethod));
    options
        .AddJob<LoggingMethod>(jobKey)
        .AddTrigger(trigger =>
            trigger.ForJob(jobKey)
                .WithSimpleSchedule(schedule =>
                    schedule.WithIntervalInSeconds(5).RepeatForever()));

    options.UseMicrosoftDependencyInjectionJobFactory();
});

builder.Services.AddQuartzHostedService();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

