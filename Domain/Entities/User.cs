using System.Runtime.InteropServices.Marshalling;

public class User
{
    public int Id{get;set;}
    public string FullName{get;set;}=null!;
    public string Email{get;set;}=null!;
    public DateTime CreatedAt{get;set;}= DateTime.UtcNow;
     public List<CourseAccess> CourseAccesses{get;set;}=[];
      public List<Payment> Payments{get;set;}=[];
      public List<Subscription> Subscriptions{get;set;}=[];

}