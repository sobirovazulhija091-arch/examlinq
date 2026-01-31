public class Payment
{
    public int Id{get;set;}
    public int UserId{get;set;}
    public int SubscriptionId{get;set;}
    public decimal Amount{get;set;}
    public DateTime PaidAt{get;set;}=DateTime.UtcNow;
    public EnumStatusPayment Status{get;set;}
    public string Provider{get;set;}=null!;
    public string  ExternalReference{get;set;}=null!;
    public User? Users{get;set;}
}