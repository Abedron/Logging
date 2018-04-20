# Logging
Simple logging library solution for fast implementation into any C# project.

## Introduction
`Log` class is singleton without namespace and does not require initialization. You can make custom `Writer` for variable targeting (console, database, file, ...). Library contains default writer for console.

## Example
```csharp
static void Main(string[] args)
{
    ILogger logger = Log.Logger;
    logger.Enabled = false;
    Log.Debug("Hide", LogChannel.Init);
    
    logger.Enabled = true;
    Log.Debug("Show", LogChannel.Init);
    
    logger.RemoveAllWriters();
    Log.Debug("Hide", LogChannel.Init);
    
    logger.AddWriter(logger.DefaultWriter);
    Log.Debug("Show: I am here again!", LogChannel.Network);
}

enum LogChannel
{
    None,
    Init,
    Network,
    Detector
}
```
*Output:*
```
[Init] Show
[Network] Show: I am here again!
```
