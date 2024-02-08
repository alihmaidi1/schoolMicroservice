namespace ClassDomain.Dto.Bill;

public class GetBillResponse
{
    public Guid Id { get; set; }
    
    public float Money { get; set; }
    
    public DateTime Date { get; set; }
}