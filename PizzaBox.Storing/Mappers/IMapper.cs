namespace PizzaBox.Storing.Mappers
{
    public interface IMapper<Database, Domain>
    {
        Domain Map(Database model);
        Database Map(Domain model);
    }
}