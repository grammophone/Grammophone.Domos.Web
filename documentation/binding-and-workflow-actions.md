# Binding And Workflow Action Models

Domos workflows often require binding an entity, a state path and dynamic action arguments from HTTP input. `Grammophone.Domos.Web` provides MVC 5 binders and models for that purpose.

## Entity Binding

`EntityModelBinderProvider`, `KeyedEntityModelBinder` and `ValueKeyedEntityModelBinder` help bind posted keys to entity instances or value-keyed references.

This is useful for forms where a user selects an entity relation by ID. For example, a music form can post an `AlbumID` or `RecordLabelID` and the binder can resolve the corresponding entity through the domain container rather than requiring the action method to parse IDs manually.

## Complex MVVM Binding

`BindingSetup`, `ValueProviderExtensions`, `DomosMetadataProvider`, `DomosValidatorProvider` and custom validator support are intended for view models that contain entities with relationships and validation metadata.

The goal is to make rich edit screens possible without replacing the secured manager layer. The controller should still pass the bound result to a manager method that enforces business rules.

## Workflow Action Binding

`ActionExecutionModel`, `StatePathExecutionModel` and `StatefulObjectExecutionModel` represent workflow actions from the presentation layer.

`ActionExecutionModelBinderProvider` and `ActionExecutionModelBinder` bind dynamic action parameters described by workflow `ParameterSpecification` metadata. This allows a path such as `ApproveForRelease` to require a dynamic release date, reviewer note or other argument without hard-coding every workflow action form.

In a music-domain workflow, a form can post an album ID, a state path code and an `ApproveForRelease` release date. The model binder produces an execution model, and the controller passes it to the workflow manager.
