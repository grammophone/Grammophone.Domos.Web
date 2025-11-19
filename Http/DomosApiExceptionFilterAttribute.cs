using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using Grammophone.DataAccess;
using Grammophone.Domos.Logic;
using Grammophone.Domos.Web.Models;

namespace Grammophone.Domos.Web.Http
{
	/// <summary>
	/// Exception filter for Web API which exploits <see cref="UserException"/>,
	/// <see cref="AccessDeniedException"/> and <see cref="IntegrityViolationException"/>
	/// descendants to serve meaningful responses.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class DomosApiExceptionFilterAttribute : ExceptionFilterAttribute
	{
		/// <summary>
		/// Filters the exceptions and transforms response.
		/// </summary>
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			var exception = actionExecutedContext.Exception;

			var userErrorModelResponse = UserErrorParser.TryParseException(exception);

			if (userErrorModelResponse != null)
			{
				if (HttpContext.Current?.Items != null) HttpContext.Current.Items[UserErrorModelResponse.Key] = userErrorModelResponse;

				actionExecutedContext.Response =
					actionExecutedContext.Request.CreateResponse(
					userErrorModelResponse.HttpStatusCode,
					userErrorModelResponse.UserErrorModel);

				return;
			}
			else
			{
				base.OnException(actionExecutedContext);
			}
		}
	}
}
