using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        // Variáveis de configuração
        private const string PATH_STORAGE = @"X:\tmp\Csharp_Cripto\CriptoV2\documentos";
        private const string FILENAME_TO_ENCRYPT = "20250926-190232_arquivo.pdf";
        private const int BUFFER_SIZE = 524288; // 512KB - melhor para arquivos grandes
        private const string PASSPHRASE = "scrum2025";

        // ⚡ OTIMIZAÇÃO: Converte senha uma única vez
        private static readonly char[] PASSPHRASE_CHARS = PASSPHRASE.ToCharArray();

        // Configurações PGP Simétricas
        private const SymmetricKeyAlgorithmTag SYMMETRIC_ALGORITHM = SymmetricKeyAlgorithmTag.Aes256;
        private const HashAlgorithmTag HASH_ALGORITHM = HashAlgorithmTag.Sha256;
        private const int S2K_ITERATIONS = 0x10000;

        // ⚡ OTIMIZAÇÃO: Buffer reutilizável para operações de criptografia
        private const int CRYPTO_BUFFER_SIZE = 524288; // 512KB

        static void Main()
        {
            // Executa a versão async de forma síncrona
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            string inputPath = Path.Combine(PATH_STORAGE, FILENAME_TO_ENCRYPT);
            string outputPath = Path.Combine(PATH_STORAGE, "arquivo_encriptado.pdf");
            string decryptedPath = Path.Combine(PATH_STORAGE, "arquivo_decriptado.pdf");

            try
            {
                if (!Directory.Exists(PATH_STORAGE))
                    throw new DirectoryNotFoundException($"Diretório não encontrado: {PATH_STORAGE}");

                // Encriptar 
                Console.WriteLine("Iniciando Criptografia GPG Simétrica...");
                var encryptStatus = await EncryptFileWithPassphraseAsync(inputPath, outputPath);

                if (encryptStatus.hasError)
                    throw new Exception(encryptStatus.message);

                Console.WriteLine($"Arquivo cifrado salvo em: {outputPath}\n");

                // Decriptar 
                Console.WriteLine("Iniciando Decriptografia GPG Simétrica...");
                var decryptStatus = await DecryptFileWithPassphraseAsync(outputPath, decryptedPath);

                if (decryptStatus.hasError)
                    throw new Exception(decryptStatus.message);

                Console.WriteLine($"Arquivo decriptado salvo em: {decryptedPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
            }
        }

        public static async Task<(bool hasError, string message)> EncryptFileWithPassphraseAsync(
            string inputFile,
            string outputFile)
        {
            FileStream inputStream = null;
            FileStream outputStream = null;
            Stream cOut = null;
            Stream lOut = null;

            try
            {
                // Validação de entrada de dados
                var validateStatus = ValidateEncryptionInputs(inputFile, outputFile);
                if (validateStatus.hasError)
                    throw new ArgumentException(validateStatus.message);

                // ⚡ OTIMIZAÇÃO: FileStream com FileOptions.Asynchronous para I/O assíncrono
                outputStream = new FileStream(outputFile, FileMode.Create,
                    FileAccess.Write, FileShare.None, BUFFER_SIZE,
                    FileOptions.Asynchronous | FileOptions.SequentialScan);

                var random = new SecureRandom();

                PgpEncryptedDataGenerator encryptedDataGenerator = new PgpEncryptedDataGenerator(
                    SYMMETRIC_ALGORITHM,
                    true,
                    random
                );

                encryptedDataGenerator.AddMethod(PASSPHRASE_CHARS, HASH_ALGORITHM);

                // Buffer maior para criptografia
                cOut = encryptedDataGenerator.Open(outputStream, new byte[CRYPTO_BUFFER_SIZE]);

                PgpLiteralDataGenerator literalDataGenerator = new PgpLiteralDataGenerator();
                lOut = literalDataGenerator.Open(
                    cOut,
                    PgpLiteralData.Binary,
                    new FileInfo(inputFile)
                );

                // ⚡ OTIMIZAÇÃO: FileStream assíncrono para leitura
                inputStream = new FileStream(inputFile, FileMode.Open,
                    FileAccess.Read, FileShare.Read, BUFFER_SIZE,
                    FileOptions.Asynchronous | FileOptions.SequentialScan);

                // ⚡ OTIMIZAÇÃO: Cópia assíncrona com buffer customizado
                await CopyStreamAsync(inputStream, lOut, BUFFER_SIZE);

                // Limpeza ordenada
                lOut.Close();
                literalDataGenerator.Close();
                cOut.Close();
                encryptedDataGenerator.Close();

                return (false, "Criptografia concluída com sucesso.");
            }
            catch (Exception ex)
            {
                await DeleteFileIfExistsAsync(outputFile);
                return (true, ex.Message);
            }
            finally
            {
                // ⚡ OTIMIZAÇÃO: Garante liberação de recursos
                if (inputStream != null) inputStream.Dispose();
                if (lOut != null) lOut.Dispose();
                if (cOut != null) cOut.Dispose();
                if (outputStream != null) outputStream.Dispose();
            }
        }

        public static async Task<(bool hasError, string message)> DecryptFileWithPassphraseAsync(
            string inputFile,
            string outputFile)
        {
            FileStream inputStream = null;
            FileStream outputStream = null;

            try
            {
                var decryptStatus = ValidateDecryptionInputs(inputFile, outputFile);
                if (decryptStatus.hasError)
                    throw new ArgumentException(decryptStatus.message);

                // ⚡ OTIMIZAÇÃO: Streams assíncronos com FileOptions.Asynchronous
                inputStream = new FileStream(inputFile, FileMode.Open,
                    FileAccess.Read, FileShare.Read, BUFFER_SIZE,
                    FileOptions.Asynchronous | FileOptions.SequentialScan);

                outputStream = new FileStream(outputFile, FileMode.Create,
                    FileAccess.Write, FileShare.None, BUFFER_SIZE,
                    FileOptions.Asynchronous | FileOptions.SequentialScan);

                Stream decodeCipherStream = PgpUtilities.GetDecoderStream(inputStream);
                PgpObjectFactory pgpFact = new PgpObjectFactory(decodeCipherStream);
                PgpObject o = pgpFact.NextPgpObject();

                PgpEncryptedDataList encList;
                if (o is PgpEncryptedDataList)
                {
                    encList = (PgpEncryptedDataList)o;
                }
                else
                {
                    encList = (PgpEncryptedDataList)pgpFact.NextPgpObject();
                }

                // Busca dados criptografados por senha
                PgpPbeEncryptedData pbed = null;
                foreach (PgpEncryptedData ed in encList.GetEncryptedDataObjects())
                {
                    pbed = ed as PgpPbeEncryptedData;
                    if (pbed != null) break;
                }

                if (pbed == null)
                    throw new PgpException("Arquivo PGP não contém dados criptografados por senha (PBE).");

                Stream clearStream = pbed.GetDataStream(PASSPHRASE_CHARS);
                PgpObjectFactory clearFact = new PgpObjectFactory(clearStream);
                PgpObject message = clearFact.NextPgpObject();

                PgpLiteralData literalData = message as PgpLiteralData;
                if (literalData != null)
                {
                    Stream dataStream = literalData.GetInputStream();

                    // ⚡ OTIMIZAÇÃO: Cópia assíncrona personalizada
                    await CopyStreamAsync(dataStream, outputStream, BUFFER_SIZE);
                }
                else
                {
                    throw new PgpException("Mensagem PGP não contém dados literais.");
                }

                // Verificação de integridade
                if (pbed.IsIntegrityProtected() && !pbed.Verify())
                {
                    throw new PgpException("Falha na verificação da integridade dos dados (MDC). O arquivo pode estar corrompido.");
                }

                return (false, string.Empty);
            }
            catch (PgpDataValidationException)
            {
                await DeleteFileIfExistsAsync(outputFile);
                return (true, "Erro ao decriptar a chave de sessão usando a senha.");
            }
            catch (Exception ex)
            {
                await DeleteFileIfExistsAsync(outputFile);
                return (true, ex.Message);
            }
            finally
            {
                // ⚡ OTIMIZAÇÃO: Garante liberação de recursos
                if (inputStream != null) inputStream.Dispose();
                if (outputStream != null) outputStream.Dispose();
            }
        }

        /// <summary>
        /// ⚡ OTIMIZAÇÃO: Cópia assíncrona customizada com buffer grande
        /// Substitui Streams.PipeAll que é síncrono
        /// </summary>
        private static async Task CopyStreamAsync(Stream source, Stream destination, int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            int bytesRead;

            while ((bytesRead = await source.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await destination.WriteAsync(buffer, 0, bytesRead);
            }

            // Garante que todos os dados foram escritos
            await destination.FlushAsync();
        }

        private static (bool hasError, string message) ValidateEncryptionInputs(string inputFile, string outputFile)
        {
            if (string.IsNullOrWhiteSpace(inputFile))
                return (true, "Caminho do arquivo de entrada é obrigatório.");

            if (string.IsNullOrWhiteSpace(outputFile))
                return (true, "Caminho do arquivo de saída é obrigatório.");

            if (!File.Exists(inputFile))
                return (true, $"Arquivo não encontrado: {inputFile}");

            if (string.Equals(Path.GetFullPath(inputFile), Path.GetFullPath(outputFile), StringComparison.OrdinalIgnoreCase))
                return (true, "Arquivo de entrada e saída não podem ser o mesmo.");

            return (false, string.Empty);
        }

        private static (bool hasError, string message) ValidateDecryptionInputs(string inputFile, string outputFile)
        {
            if (string.IsNullOrWhiteSpace(inputFile))
                return (true, "Caminho do arquivo de entrada é obrigatório.");

            if (string.IsNullOrWhiteSpace(outputFile))
                return (true, "Caminho do arquivo de saída é obrigatório.");

            if (!File.Exists(inputFile))
                return (true, $"Arquivo criptografado não encontrado: {inputFile}");

            if (string.Equals(Path.GetFullPath(inputFile), Path.GetFullPath(outputFile), StringComparison.OrdinalIgnoreCase))
                return (true, "Arquivo de entrada e saída não podem ser o mesmo.");

            return (false, string.Empty);
        }

        /// <summary>
        /// ⚡ OTIMIZAÇÃO: Versão assíncrona para deletar arquivos
        /// </summary>
        private static async Task DeleteFileIfExistsAsync(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    // Task.Run para não bloquear a thread principal
                    await Task.Run(() => File.Delete(path));
                }
                catch
                {
                    /* Ignorar erros */
                }
            }
        }
    }
}