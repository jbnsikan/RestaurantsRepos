namespace Restaurants.Domain.Exceptions
{
    public class NotFoundException(string ressourceType, string ressourceIdentifier) 
        : Exception($"{ressourceType} with id: {ressourceIdentifier} doesn't exist")
    {
    }
}
