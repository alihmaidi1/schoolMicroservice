using ClassDomain.Dto.Class;

namespace ClassDomain.Dto.Stage;

public class GetStageresponse
{
    
    
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<GetClassResponse> Classes { get; set; }
    
}