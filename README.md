# Grammophone.Domos.Web

`Grammophone.Domos.Web` provides ASP.NET MVC 5 and Web API presentation helpers for Domos applications.

The package focuses on binding, validation, error handling and controller base classes that make it easier to expose operations backed by `LogicSession` instances, entity relations and workflow actions.

## Main Features

- MVC model binders for entities referenced by keys and by selected values.
- Binding support for workflow action execution models with dynamic workflow arguments.
- Validation and metadata providers for Domos models.
- Exception filters for user-facing errors, AJAX errors and Application Insights logging.
- MVC and Web API foundation controllers that operate through logic sessions.
- View-page traits and HTML helpers for common Domos UI patterns.

## Documentation

- [Presentation layer](documentation/presentation-layer.md)
- [Binding and workflow action models](documentation/binding-and-workflow-actions.md)
- [Controllers, filters and HTML helpers](documentation/controllers-filters-html.md)
