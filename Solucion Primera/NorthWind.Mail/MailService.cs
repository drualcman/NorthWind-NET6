using NorthWind.Entities.Interfaces;

namespace NorthWind.Mail
{
    /// <summary>
    /// Implementacion para enviar correos electronicos
    /// </summary>
    public class MailService : IMailService
    {
        readonly IApplicationStatusLogger Logger;

        /// <summary>
        /// Constructor que recibe el application log para notificar
        /// </summary>
        /// <param name="logger"></param>
        public MailService(IApplicationStatusLogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Enviar un correo electronico con el mensaje enviado
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ValueTask Send(string message)
        {
            Logger.Log($"*** MailService: {message} ***");
            Logger.Log($"*** MailService: Servidor de correo no configurado ***");
            return ValueTask.CompletedTask;
        }
    }
}