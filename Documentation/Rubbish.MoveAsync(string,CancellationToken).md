### [Emik](Emik.md 'Emik').[Rubbish](Rubbish.md 'Emik.Rubbish')

## Rubbish.MoveAsync(string, CancellationToken) Method

Moves the file or directory to the recycling bin asynchronously.

```csharp
public static System.Threading.Tasks.Task<bool> MoveAsync(string? path, System.Threading.CancellationToken token=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Emik.Rubbish.MoveAsync(string,System.Threading.CancellationToken).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The path to move to the recycling bin. This can be relative or absolute.

<a name='Emik.Rubbish.MoveAsync(string,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to cancel the operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') responsible for the operation, returning the value [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool')  
if the operation was successful, otherwise; [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

### Example
  
The following example moves the file or directory `test.txt`  
(which is relative to the current working directory) to the recycling bin.  
  
```csharp  
using System;  
using Emik;  
  
  
if (await Rubbish.MoveAsync("test.txt"))  
    Console.WriteLine("Sent text.txt to the recycle bin.");  
else  
    Console.WriteLine("Failed to move test.txt.");  
```

### Remarks
  
Unlike other IO operations, this method does not ever throw.