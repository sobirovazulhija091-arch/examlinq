using System.Runtime.InteropServices.Marshalling;

public class UpdateUserDto
{
    public int Id{get;set;}
    public string FullName{get;set;}=null!;
    public string Email{get;set;}=null!;

}