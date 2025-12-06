using Microsoft.AspNetCore.Http;

namespace Domic.UseCase.Commons.Contracts.Interfaces;

public interface IExternalStorageManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<string> UploadAsync(IFormFile file, CancellationToken cancellationToken);
}