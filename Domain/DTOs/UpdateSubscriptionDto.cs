public class UpdateSubscriptionDto
{
    public int Id{get;set;}
    public int UserId{get;set;}
    public int PlanId{get;set;}
    public DateTime EndDate{get;set;}
    public EnumStatusSubscription Status{get;set;}
}