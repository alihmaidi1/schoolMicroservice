using ClassDomain.Entities.Subject;

namespace ClassInfrutructure.Seed;

public static class SubjectSeeder
{
    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Subjects.Any())
        {


            List<Subject> Subjects = new List<Subject>()
            {
                
                new Subject()
                {
                    
                    Name = "Math1"
                },
                
                
                new Subject()
                {
                    
                    Name = "Math2"
                },
                
                new Subject()
                {
                    
                    Name = "Arabic"
                },
                
                new Subject()
                {
                    
                    Name = "English"
                },
            };

            
            context.Subjects.AddRange(Subjects);
            context.SaveChanges();
        }
        
        


    }

}