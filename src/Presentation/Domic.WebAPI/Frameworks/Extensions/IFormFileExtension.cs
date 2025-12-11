namespace Domic.Common.ClassExtensions;

public static class IFormFileExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    /// <param name="webHostEnvironment"></param>
    /// <param name="renameFile"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<(string path, string name, string extension)> UploadToLocalStorageAsync(this IFormFile file, 
        IWebHostEnvironment webHostEnvironment, bool renameFile = true, CancellationToken cancellationToken = default
    )
    {
        var fileExtension = Path.GetExtension(file.FileName);
        var fileName      = renameFile ? Guid.NewGuid().ToString().Replace("-", "") + fileExtension : file.FileName;
        string uploadPath = Path.Combine($"{webHostEnvironment.ContentRootPath}", "Storages", fileName);
        
        await using var fileStream = new FileStream(uploadPath , FileMode.Create);
        
        await file.CopyToAsync(fileStream, cancellationToken);
        
        return ( webHostEnvironment.IsProduction() ? uploadPath.Replace("app", "") : uploadPath , fileName , fileExtension );
    }
}