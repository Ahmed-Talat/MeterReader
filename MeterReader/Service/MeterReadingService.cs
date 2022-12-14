using Grpc.Core;
using MeterReader.Entities;
using MeterReader.gRPC;
using MeterReader.Repos;
using static MeterReader.gRPC.MeterReadingService;

namespace MeterReader.Service;

public class MeterReadingService : MeterReadingServiceBase
{
    private readonly IReadingRepository _repository;
    private readonly ILogger<MeterReadingService> _logger;

    public MeterReadingService(IReadingRepository repository, ILogger<MeterReadingService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public override async Task<StatusMessage> AddReading(ReadingPacket request, ServerCallContext context)
    {
        if (request.Successful == ReadingStatus.Success)
        {
            foreach (var reading in request.Readings)
            {
                var readingValue = new MeterReading()
                {
                    CustomerId = reading.CustomerId,
                    Value = reading.ReadingValue,
                    ReadingDate = reading.ReadingTime.ToDateTime()
                };

                _repository.AddEntity(readingValue);
            }

            if (await _repository.SaveAllAsync())
            {
                return new StatusMessage()
                {
                    Message = "Successfully added to the database.",
                    Success = ReadingStatus.Success
                };
            }
        }

        return new StatusMessage()
        {
            Message = "Failed to store readings in Database",
            Success = ReadingStatus.Success
        };
    }
}