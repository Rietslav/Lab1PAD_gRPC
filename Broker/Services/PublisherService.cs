using GrpcAgent;
using Grpc.Core;
using System.Threading.Tasks;

namespace Broker.Services
{
    public class PublisherService : Publisher.PublisherBase
    {
        public override Task<PublishReply> PublishMessage(PublishRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Received: {request.Topic} {request.Content}");

            return Task.FromResult(new PublishReply() 
            { 
                IsSuccess = true 
            });

        }
    }
}
