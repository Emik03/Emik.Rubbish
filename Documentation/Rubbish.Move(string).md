### [Emik](Emik.md 'Emik').[Rubbish](Rubbish.md 'Emik.Rubbish')

## Rubbish.Move(string) Method

Moves the file or directory to the recycling bin.

```csharp
public static bool Move(string? path);
```
#### Parameters

<a name='Emik.Rubbish.Move(string).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path to move to the recycling bin. This can be relative or absolute.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
The value [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the operation was successful, otherwise; [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

### Example
  
The following example moves the file or directory `test.txt`  
(which is relative to the current working directory) to the recycling bin.  
  
```csharp  
using System;  
using Emik;  
  
  
if (Rubbish.Move("test.txt"))  
    Console.WriteLine("Sent text.txt to the recycle bin.");  
else  
    Console.WriteLine("Failed to move test.txt.");  
```

### Remarks
  
Unlike other IO operations, this method does not ever throw.