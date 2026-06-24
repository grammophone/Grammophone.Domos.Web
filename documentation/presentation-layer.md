# ASP.NET MVC 5 Presentation Layer

`Grammophone.Domos.Web` contains presentation infrastructure for ASP.NET MVC 5 and Web API applications built on Domos.

It does not define business behavior. Business behavior belongs in `LogicSession` and managers. The presentation layer helps bind HTTP input to Domos models, call secured logic, and translate exceptions into user-facing responses.

## Typical Flow

A controller derives from a Domos foundation controller or from an application-specific controller built on top of it. The controller creates or receives a logic session for the current user and obtains managers through session methods.

In the music-domain example, an MVC controller can create a `MusicSession`, request a `RecordLabelCatalogManager` for a selected label, and execute manager methods to edit albums. The manager acquisition itself enforces access.

## View Pages

`ViewPage`, `ModelViewPage` and `ViewPageTrait` make Domos session and public-domain facilities available to MVC views. Applications can derive their own view page base classes to expose strongly typed sessions and public domains.

## User Errors

`UserErrorParser` and user-error models help convert exceptions into structured error payloads. Filters use this to produce consistent JSON or view responses for application-level exceptions.
