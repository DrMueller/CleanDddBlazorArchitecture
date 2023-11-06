using JetBrains.Annotations;

namespace Mmu.CleanBlazor.Presentation2.Areas.Test.Components
{
    [UsedImplicitly]
    public partial class TestPage
    {
        private const string Path = "/Test";

        public const string ExceptionMessage = "Test exception";

        private static string ErrorPropertyWithException => throw new Exception(ExceptionMessage);
    }
}