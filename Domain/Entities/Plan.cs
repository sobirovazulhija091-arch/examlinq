public class Plan
{
     public int Id{get;set;}
    public Enumplan Name{get;set;}
    public int DurationDays{get;set;}
    public decimal Price{get;set;}
    public bool IsActive{get;set;}
    public List<Subscription> Subscriptions{get;set;}=[];
}