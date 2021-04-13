namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Customer
  {
    private string _name = null;
    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        _name = value;
      }
    }

    public Customer(string name)
    {
      Name = name;
    }

    public override string ToString()
    {
      return $"{Name}";
    }
  
  }
}
