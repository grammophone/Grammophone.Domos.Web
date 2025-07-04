using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Grammophone.DataAccess;
using Grammophone.Domos.Logic;

namespace Grammophone.Domos.Web.Mvc
{
	/// <summary>
	/// MVC Filter attribute to record system exceptions to Applications Insights,
	/// excluding exceptions targeted to the user.
	/// </summary>
	public class ApplicationInsightsExceptionFilter : FilterAttribute, IExceptionFilter
	{
		/// <summary>
		/// Records the system exceptions and does nothing for the rest.
		/// </summary>
		public void OnException(ExceptionContext actionExecutedContext)
		{
			var exception = actionExecutedContext.Exception;

			switch (exception)
			{
				case ActionException actionException:
					var actionTelemetry = new Microsoft.ApplicationInsights.TelemetryClient();

					actionTelemetry.TrackTrace(actionException.Message, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Warning);

					break;

				//case AccessDeniedException accessDeniedException:
				case IntegrityViolationException integrityConstraintExceptinon:
					var integrityConstraintMessageTelemetry = new Microsoft.ApplicationInsights.TelemetryClient();

					integrityConstraintMessageTelemetry.TrackTrace(integrityConstraintExceptinon.Message, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Information);
					break;

				case UserException userException:
					var userMessageTelemetry = new Microsoft.ApplicationInsights.TelemetryClient();

					userMessageTelemetry.TrackTrace(userException.Message, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Information);
					//case InvalidOperationException invalidOperationException:
					// These exceptions are intended to communicate errors to the user,
					// thus do not record them as system errors.
					break;

				default:
					var exceptionTelemetry = new Microsoft.ApplicationInsights.TelemetryClient();

					exceptionTelemetry.TrackException(exception);

					break;
			}
		}
	}
}
