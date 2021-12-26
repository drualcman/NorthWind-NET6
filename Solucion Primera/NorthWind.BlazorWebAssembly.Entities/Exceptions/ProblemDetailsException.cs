using System.Text.Json;

namespace NorthWind.BlazorWebAssembly.Entities.Exceptions
{
    /// <summary>
    /// Encapsular los errores para aplicaciones blazor
    /// </summary>
    public class ProblemDetailsException : Exception
    {
        /// <summary>
        /// Titulo
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Detalle
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Tipo
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Parametros con errores
        /// </summary>
        public IDictionary<string, string> InvalidParams { get; set; }

        /// <summary>
        /// constructor basico
        /// </summary>
        public ProblemDetailsException() { }
        /// <summary>
        /// contructor que recibe la respuesta con los errores
        /// </summary>
        /// <param name="jsonResponse"></param>
        public ProblemDetailsException(JsonElement jsonResponse)
        {
            var Values = JsonSerializer
            .Deserialize<ProblemDetailsException>(
            jsonResponse.GetRawText(),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });



            Title = Values.Title;
            Detail = Values.Detail;
            Status = Values.Status;
            Type = Values.Type;



            if (jsonResponse.TryGetProperty("invalid-params",
            out JsonElement InvalidParams))
            {
                this.InvalidParams = JsonSerializer
                .Deserialize<Dictionary<string, string>>(
                InvalidParams.GetRawText());
            }
        }
        /// <summary>
        /// Sobreescribir para reciber solo el Mensaje
        /// </summary>
        public override string Message => Title;
    }
}