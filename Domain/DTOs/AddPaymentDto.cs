public class AddPaymentDto
{
    public int UserId{get;set;}
    public int SubscriptionId{get;set;}
    public decimal Amount{get;set;}
    public EnumStatusPayment Status{get;set;}
    public string Provider{get;set;}=null!;
    public string  ExternalReference{get;set;}=null!;
}