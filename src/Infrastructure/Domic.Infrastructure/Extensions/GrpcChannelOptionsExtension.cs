using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Configuration;

namespace Domic.Infrastructure.Extensions;

public static class GrpcChannelOptionsExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public static GrpcChannelOptions GetAll(this GrpcChannelOptions options)
    {
        options.ServiceConfig = new ServiceConfig {
            MethodConfigs = {
                new MethodConfig {
                    RetryPolicy = new RetryPolicy {
                        MaxAttempts          = 5, //count retry
                        InitialBackoff       = TimeSpan.FromSeconds(1), //start waiting time
                        MaxBackoff           = TimeSpan.FromSeconds(5), //max waiting time
                        BackoffMultiplier    = 2, //waiting time between each attempt
                        RetryableStatusCodes = { StatusCode.Unavailable }
                    }
                }
            }
        };
        
        options.HttpHandler = new HttpClientHandler {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        return options;
    }
}