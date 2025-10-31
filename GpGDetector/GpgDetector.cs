using Org.BouncyCastle.Bcpg.OpenPgp;

public static class GpgDetector
{
    public static bool IsGpgFile(string filePath)
    {
        try
        {
            using var fs = File.OpenRead(filePath);
            using var decoderStream = PgpUtilities.GetDecoderStream(fs); // Suporta ASCII Armor e binário

            var factory = new PgpObjectFactory(decoderStream);

            // Tenta ler o primeiro objeto PGP
            var obj = factory.NextPgpObject();
            if (obj == null)
                return false;

            // Se conseguiu criar um objeto PGP válido, o arquivo é OpenPGP
            Console.WriteLine($"\nDetectado tipo: {obj.GetType().Name}\n");
            return true;
        }
        catch (IOException)
        {
            // Problemas de leitura
            return false;
        }
        catch (PgpException)
        {
            // Não é um formato PGP válido
            return false;
        }
    }
}
