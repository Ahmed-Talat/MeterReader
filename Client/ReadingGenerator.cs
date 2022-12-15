using Google.Protobuf.WellKnownTypes;
using MeterReader.gRPC;

namespace Client;

public class ReadingGenerator
{
    public Task<ReadingMessage> GenerateAsync(int customerId)
    {
        var reading = new ReadingMessage
        {
            CustomerId = customerId,
            ReadingTime = Timestamp.FromDateTime(DateTime.UtcNow),
            ReadingValue = new Random().Next(0, 100)
        };

        return Task.FromResult(reading);
    }
}
