namespace fabiostefani.io.CleanArch.Domain.Interfaces
{
    public interface IItemRepository
    {
        Item? GetById(string id);
    }
}