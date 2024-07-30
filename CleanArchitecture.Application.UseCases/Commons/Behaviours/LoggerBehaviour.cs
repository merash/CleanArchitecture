using MediatR;
using Serilog;
using System.Diagnostics;
using System.Text.Json;

namespace CleanArchitecture.Application.UseCases.Commons.Behaviours
{
    public class LoggerBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        readonly Stopwatch stopwatch;

        public LoggerBehaviour()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"..\CleanArchitecture.Logs\Log.txt").CreateLogger() ?? throw new ArgumentNullException(nameof(LoggerConfiguration));
            this.stopwatch = new Stopwatch() ?? throw new ArgumentNullException(nameof(Stopwatch));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            Log.Information(String.Format("Start Request {0}", requestName));

            Log.Information(String.Format("Send Request Parameter/Body: {0}", JsonSerializer.Serialize(request)));

            this.stopwatch.Start();
            var response = await next();
            this.stopwatch.Stop();

            Log.Information(String.Format("Return Response: {0}", JsonSerializer.Serialize(response)));

            var elapsedMilliseconds = this.stopwatch.ElapsedMilliseconds;
            Log.Warning(String.Format("End Request: {0} in {1} milliseconds", requestName, elapsedMilliseconds));

            return response;
        }
    }
}