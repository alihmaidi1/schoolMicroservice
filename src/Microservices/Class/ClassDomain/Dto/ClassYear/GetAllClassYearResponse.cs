namespace ClassDomain.Dto.ClassYear;

public class GetAllClassYearResponse
{
    
    public Guid Id { get; set; }
    
    public List<BillResponse> Billings { get; set; }
    
}

public class BillResponse
{
    
    public Guid Id { get; set; }
    public float Money { get; set; }
    
    public DateTime date { get; set; }
    
}