using Grpc.Net.Client;
using MeterReader.gRPC;
using static MeterReader.gRPC.MeterReadingService;

namespace Client;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ReadingGenerator _readingGenerator;

    public Worker(ILogger<Worker> logger, ReadingGenerator readingGenerator)
    {
        _logger = logger;
        _readingGenerator = readingGenerator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7069");
            var client = new MeterReadingServiceClient(channel);

            var x = new ReadingPacket()
            {
                Successful = ReadingStatus.Success
            };

            x.Readings.Add(await _readingGenerator.GenerateAsync(1));

            var status = client.AddReading(x);

            _logger.LogInformation(status.Message);
            _logger.LogInformation(status.Success.ToString());
            await Task.Delay(1000, stoppingToken);
        }
    }
}