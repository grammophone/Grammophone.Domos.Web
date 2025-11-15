using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Grammophone.DataAccess;
using Grammophone.Domos.Logic;
using Grammophone.Domos.Web.Mvc;

namespace Grammophone.Domos.Web.Http
{
	/// <summary>
	/// Web API Filter attribute to record system exceptions to Applications Insights,
	/// excluding exceptions targeted to the user.
	/// </summary>
	public class ApplicationInsightsApiExceptionFilter : ExceptionFilterAttribute
	{
		/// <summary>
		/// Records the system exceptions and does nothing for the rest.
		/// </summary>
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			var exception = actionExecutedContext.Exception;

			ApplicationInsightsLogging.LogException(exception);
		}
	}
}
