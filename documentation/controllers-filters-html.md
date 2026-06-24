# Controllers, Filters And HTML Helpers

`Grammophone.Domos.Web` provides foundation types for MVC 5 and Web API applications.

## Controllers

`LogicController` and `ModelController` are base classes for controllers that operate through Domos logic sessions. Applications typically derive concrete controllers that expose application-specific session and manager methods.

`Http.LogicApiController` provides the equivalent foundation for Web API controllers.

Controllers should avoid direct data access for business operations. They should obtain managers from the current logic session so manager access, entity access and workflow access are enforced.

## Filters

The package includes filters for:

- Domos exceptions.
- Action exceptions.
- AJAX error responses.
- Application Insights exception logging.
- Client-hints headers through `AcceptChFilterAttribute`.

Filters translate exceptions to predictable responses while preserving application-level error information.

## HTML Helpers

`HtmlExtensions` contains MVC helper methods used by Domos presentation code. These helpers are intended to reduce repetitive view code around entity selection, metadata, validation and workflow/action rendering.

In a music-domain UI, helpers can participate in rendering an album workflow action form whose arguments are determined by the selected state path.
