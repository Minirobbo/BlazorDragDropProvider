# DragDropProvider

## About The Project
This is a small open source project I started to provide an easy way to add drag and drop functionality to any Blazor project! This can be used with any other UI libraries or packages, so it fits with any pre-existing code you've written.

## Getting Started
### Installation
To install DragDropProvider follow these simple steps:

1. Add the code base - TBC
2. Add the required services to the services builder (the location of this can vary for project type)
```csharp
builder.services.AddDragDropServices();
```
3. Add a ```DragDropZone``` to any razor page.
```razor
<DragDropZone TItem="A">
    <ItemRenderer>
        <!--Add Item template here, using @context to access item properties-->
    </ItemRenderer>
</DragDropZone>
```

## Contact

Isaac Robinson - [@Minirobbo](www.github.com/Minirobbo)

Project Link - https://github.com/Minirobbo/BlazorDragDropProvider