using System.Reflection;
using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Models;
using DatabaseBuddy.Infrastructure.DockerStuff.Services;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Specifications;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace DatabaseBuddy.ConsoleCommands.ShowData
{
    public class ShowDataConsoleCommand : IConsoleCommand
    {
        private readonly IContainerManager _containerManager;
        private readonly IQueryService _queryService;

        public string Description { get; } = "Shows all individuals as a console table.";
        public ConsoleKey Key { get; } = ConsoleKey.F3;

        public ShowDataConsoleCommand(
            IContainerManager containerManager,
            IQueryService queryService)
        {
            _containerManager = containerManager;
            _queryService = queryService;
        }

        public async Task ExecuteAsync()
        {
            await _containerManager.AssureStartedAsync();

            var individuals = await _queryService.QueryAsync(new IndividualSpec());
            WriteTable(individuals.ToList());
        }

        private static string FormatCell(object? value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (value is DateTime dt)
            {
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            }

            if (value is DateTimeOffset dto)
            {
                return dto.ToString("yyyy-MM-dd HH:mm:ss zzz");
            }

            return value.ToString() ?? string.Empty;
        }

        private static IEnumerable<PropertyInfo> GetReadableProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetMethod != null && p.GetMethod.GetParameters().Length == 0);
        }

        private static void PrintRow(IReadOnlyList<string> cells, IReadOnlyList<int> widths)
        {
            Console.Write('|');

            for (var i = 0; i < cells.Count; i++)
            {
                var cell = cells[i] ?? string.Empty;
                Console.Write(' ');
                Console.Write(cell.PadRight(widths[i]));
                Console.Write(' ');
                Console.Write('|');
            }

            Console.WriteLine();
        }

        private static void PrintSeparator(IReadOnlyList<int> widths)
        {
            Console.Write('+');

            for (var i = 0; i < widths.Count; i++)
            {
                Console.Write(new string('-', widths[i] + 2));
                Console.Write('+');
            }

            Console.WriteLine();
        }

        private static void WriteTable<T>(IReadOnlyList<T> rows)
        {
            if (rows.Count == 0)
            {
                Console.WriteLine("No individuals found.");

                return;
            }

            var columns = GetReadableProperties(typeof(T))
                .OrderBy(p => p.Name, StringComparer.Ordinal)
                .ToArray();

            if (columns.Length == 0)
            {
                Console.WriteLine("No readable columns found.");

                return;
            }

            var header = columns.Select(c => c.Name).ToArray();

            var data = new string[rows.Count][];

            for (var i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                data[i] = columns
                    .Select(p => FormatCell(p.GetValue(row)))
                    .ToArray();
            }

            var widths = new int[columns.Length];

            for (var c = 0; c < columns.Length; c++)
            {
                var maxDataWidth = data.Select(r => r[c].Length).DefaultIfEmpty(0).Max();
                widths[c] = Math.Max(header[c].Length, maxDataWidth);
            }

            PrintSeparator(widths);
            PrintRow(header, widths);
            PrintSeparator(widths);

            for (var i = 0; i < data.Length; i++)
            {
                PrintRow(data[i], widths);
            }

            PrintSeparator(widths);
        }
    }
}