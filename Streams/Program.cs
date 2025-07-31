using System.Diagnostics;
using System.Text;
using Streams.Helpers;

namespace Streams;

/**
* Tutorias: https://www.youtube.com/watch?v=yDtjevq67cE
*
*/

public static class Program
{
    private static CancellationTokenSource? _cancellationTokenSource;

    public static async Task Main(string[] args)
    {
        _cancellationTokenSource = new CancellationTokenSource();

        string diretorio = Environment.CurrentDirectory + Path.AltDirectorySeparatorChar;
        string arquivo = diretorio + "exemplo.md";
        string log = diretorio + "registros.log";
        string texto = "Usando FileStream";

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

        // COMPRIMIR ARQUIVOS COM "ZIP"  


        var stopwatch = new Stopwatch();
        stopwatch.Start();

        try
        {
            // _cancellationTokenSource.Cancel();

            await ZipHelper.ComprimirParaZip("arquivo-bruto.txt", _cancellationTokenSource.Token);

            Console.WriteLine("ARQUIVO COMPACTADO COM SUCESSO");
        }
        catch
        {
            Console.WriteLine("COMPACTAÇÃO FOI CANCELADA");
            Console.WriteLine($"TEMPO DECORRIDO: {stopwatch.Elapsed}");
        }



    }

}
