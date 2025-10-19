namespace Mmu.CleanBlazor.Presentation2.Shared.Components.SelectElements.MultiSelection
{
    public class ItemWithIdAndNameViewModel
    {
        public int Id { get; init; }

        public required string Name { get; init; }

        public static ItemWithIdAndNameViewModel Create(int id, string name)
        {
            return new ItemWithIdAndNameViewModel
            {
                Id = id,
                Name = name
            };
        }

        public static ItemWithIdAndNameViewModel CreateEmpty()
        {
            return new ItemWithIdAndNameViewModel
            {
                Id = 0,
                Name = string.Empty
            };
        }
    }
}