using System.Net;

namespace ControleTarefas.WebApi.Responses
{
    public class DefaultResourses
    {
        public HttpStatusCode HttpStatus { get; set; }

        public List<string> Messages { get; set; }

        public DefaultResourses(HttpStatusCode httpStatusCode, List<string> messages)
        {
            HttpStatus = httpStatusCode;
            Messages = messages;
        }
    }
}
