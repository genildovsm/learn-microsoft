using System.IO.Compression;
using System.Text;

namespace Streams;

public static class Program
{

    public static async Task Main(string[] args)
    {
        string diretorio = Environment.CurrentDirectory + Path.AltDirectorySeparatorChar;

        string arquivo = diretorio + "exemplo.md";
        string log = diretorio + "registros.log";
        string texto = "Usando FileStream";
        string arquivoBruto = diretorio + "arquivo-bruto.txt";
        string arquivoComprimido = diretorio + "arquivo-comprimido.gz";

        // Escrever para arquivo

        using (FileStream fs = new(arquivo, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = Encoding.UTF8.GetBytes(texto);
            await fs.WriteAsync(buffer);
        }

        // Ler do arquivo

        using (FileStream fs = new(arquivo, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[fs.Length];
            _ = await fs.ReadAsync(buffer);
            string? result = Encoding.UTF8.GetString(buffer);

            Console.WriteLine(result);
        }

        string mensagem = "Usando MemoryStream";

        using (MemoryStream ms = new())
        {
            // Escrita no MemoryStream

            byte[] buffer = Encoding.UTF8.GetBytes(mensagem);
            await ms.WriteAsync(buffer);

            // Leitura do MemoryStream

            ms.Position = 0;

            byte[] readBuffer = new byte[ms.Length];
            await ms.ReadAsync(readBuffer);

            string result = Encoding.UTF8.GetString(readBuffer);
            Console.WriteLine(result + "\n");
        }

        // Utilizando um StreamWriter para retornar dados em CSV

        using (MemoryStream ms = new())
        {
            using (StreamWriter writer = new(ms))
            {
                await writer.WriteLineAsync("Conference,Date,Checkout");
                await writer.WriteLineAsync("NWE Summit,2025-05-01,true");
                await writer.WriteLineAsync("Fortinet Security Summit,2025-09-23,false");
                await writer.FlushAsync();

                ms.Position = 0;

                Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));

                // para retornar no response de uma API
                // return Results.File(ms.ToArray(),"text/csv","conferences.csv");
            }
        }

        // Ler o conteúdo de todas as linhas de um arquivo

        using (StreamReader reader = new(arquivo))
        {
            string? linha;

            while ((linha = await reader.ReadLineAsync()) != null)
            {
                Console.WriteLine(linha);
            }
        }

        // Escrevendo em arquivos

        using (StreamWriter writer = new(log))
        {
            await writer.WriteLineAsync("Log entry: " + DateTime.Now.ToShortDateString());
        }

        // Compactação de stream

        using (var fs = File.OpenRead(arquivoBruto)) {
            using (var fsCompressedFile = File.Create(arquivoComprimido)) {
                using (var gzip = new GZipStream(fsCompressedFile, CompressionMode.Compress)) {
                    await fs.CopyToAsync(gzip);
                }
            }
        }
    }

}
