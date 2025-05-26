using System.Text.Json;

namespace apiCatalogo.Models;

/// <summary>
/// Detalhamento de erro
/// </summary>
public class ErrorDetails
{
    /// <summary>
    /// Código de status
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Mensagem
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Rastreamento
    /// </summary>
    public string? Trace { get; set; }

    /// <summary>
    /// Converter para string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
