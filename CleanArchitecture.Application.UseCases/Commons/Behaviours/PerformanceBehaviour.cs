using MediatR;
using Serilog;
using System.Diagnostics;
using System.Text.Json;

namespace CleanArchitecture.Application.UseCases.Commons.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;

        public PerformanceBehaviour()
        {
            _timer = new Stopwatch() ?? throw new ArgumentNullException(nameof(Stopwatch));

            Log.Logger = new LoggerConfiguration().WriteTo.File(@"..\CleanArchitecture.Logs\Log.txt").CreateLogger();
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            Log.Information(String.Format("Start Request {0}", requestName));

            Log.Information(String.Format("Send Request Parameter/Body: {0}", JsonSerializer.Serialize(request)));

            _timer.Start();
            var response = await next();
            _timer.Stop();

            Log.Information(String.Format("Return Response: {0}", JsonSerializer.Serialize(response)));

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;
            Log.Warning(String.Format("End Request: {0} in {1} milliseconds", requestName, elapsedMilliseconds));

            return response;
        }
    }
}