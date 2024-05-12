if (!Console.IsInputRedirected)
    Console.WriteLine("Please enter the path you wish to trash. Close Standard Input to exit.");

while (Console.ReadLine() is { } line)
    Console.WriteLine(await Rubbish.MoveAsync(line) ? "OK" : "ERR");
