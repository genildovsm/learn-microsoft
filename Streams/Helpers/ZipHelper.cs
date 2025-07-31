using System.IO.Compression;

namespace Streams.Helpers;

public class ZipHelper
{
    public static Task ComprimirParaZip(string arquivo, CancellationToken cancellationToken = default)
    {
        string diretorio = Environment.CurrentDirectory + Path.AltDirectorySeparatorChar + "Storage";
        string original = Path.Combine(diretorio, arquivo);
        string comprimido = Path.Combine(diretorio, Guid.NewGuid()+".zip");

        Task<int>? task = null;

        if (cancellationToken.IsCancellationRequested) throw new TaskCanceledException(task);

        using (var zip = ZipFile.Open(comprimido, ZipArchiveMode.Create))
        {
            zip.CreateEntryFromFile(original, Path.GetFileName(original));
        }

        return Task.CompletedTask;
    }
}
