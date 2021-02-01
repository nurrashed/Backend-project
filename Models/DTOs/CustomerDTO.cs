using System.Collections.Generic;

public class CustomerDTO{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string HomeAddress { get; set; }
    //public ICollection<OrderDTO> Orders { get; set; }
}