using System.Web.Http.Filters;

namespace MusicApi.Attribute
{
    public class ExceptionHandling : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            string exceptionMessage = string.Empty;
            if (context.Exception.InnerException == null)
            {
                exceptionMessage = context.Exception.Message;
            }
            else
            {
                exceptionMessage = context.Exception.InnerException.Message;
            }
            //We can log this exception message to the file or database.
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(exceptionMessage),
                    ReasonPhrase = exceptionMessage
            };
            context.Response = response;
        }

    }
}
