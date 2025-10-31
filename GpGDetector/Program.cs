class Program
{
    static void Main()
    {
        string path = "apagar.txt.gpg";
        bool result = GpgDetector.IsGpgFile(path);

        Console.WriteLine(
            result
            ? "✅ É um arquivo GPG/OpenPGP válido.\n"
            : "❌ Não é um arquivo GPG válido.\n"
        );
    }
}