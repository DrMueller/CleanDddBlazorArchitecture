namespace Mmu.CleanBlazor.QualityTests.TestingInfrastructure
{
    internal static class TypeExtensions
    {
        // Take from https://stackoverflow.com/questions/64809750/how-to-check-if-type-is-a-record
        internal static bool IsRecord(this Type type)
        {
            return type.GetMethods().Any(m => m.Name == "<Clone>$");
        }
    }
}