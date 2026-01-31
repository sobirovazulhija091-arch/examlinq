public class Subscription
{
    public int Id{get;set;}
    public int UserId{get;set;}
    public int PlanId{get;set;}
    public DateTime StartDate{get;set;}=DateTime.UtcNow;
    public DateTime EndDate{get;set;}
    public EnumStatusSubscription Status{get;set;}
    public DateTime  CreatedAt{get;set;}=DateTime.UtcNow;
    public User? Users{get;set;}
    public Plan? Plans{get;set;}
}