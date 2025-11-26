using System.IO.Compression;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace System.Net.Http;

/// <summary>
/// Extension methods for HTTP-related operations.
/// </summary>
public static class HttpExtensions
{
    /// <summary>
    /// Uncompresses the content of an HTTP response if it is compressed, otherwise reads it as a string.
    /// </summary>
    /// <param name="response">The HTTP response message.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the unzipped content as a string.</returns>
    public static async Task<string> UnzipResponseAsync(this HttpResponseMessage response, CancellationToken ct = default)
    {
        // verifica se conteúdo é zipado, se for, de-zip e pega o conteúdo, senão pega como string
        if (response.Content.Headers.ContentEncoding.Contains("gzip"))
        {
            using var stream = await response.Content.ReadAsStreamAsync(ct);
            using var decompressedStream = new GZipStream(stream, CompressionMode.Decompress);
            using var reader = new StreamReader(decompressedStream);
            return await reader.ReadToEndAsync(ct);
        }
        else
        {
            return await response.Content.ReadAsStringAsync(ct);
        }
    }

    /// <summary>
    /// Uncompresses the content of an HTTP response if it is compressed, and deserializes the JSON.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="response">The HTTP response message.</param>
    /// <param name="type">The JSON type information.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized object of type <typeparamref name="T"/>.</returns>
    public static async Task<T?> UnzipFromJsonAsync<T>(
        this HttpResponseMessage response, JsonTypeInfo<T> type, CancellationToken ct = default)
    {
        var json = await response.UnzipResponseAsync(ct);
        return JsonSerializer.Deserialize(json, type);
    }
}
