using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Services;
using Lamar;

var container = new Container(cfg =>
{
    cfg.Scan(scanner =>
    {
        scanner.AssembliesFromApplicationBaseDirectory();
        scanner.LookForRegistries();
    });
});

container
    .GetInstance<IConsoleCommandsStartupService>()
    .Start();