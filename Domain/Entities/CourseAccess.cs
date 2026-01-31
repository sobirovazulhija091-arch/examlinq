public class CourseAccess
{
    public int Id{get;set;}
    public int UserId{get;set;}
    public int CourseId{get;set;}
    public DateTime GrantedAt{get;set;}=DateTime.UtcNow;
    public DateTime RevokedAt{get;set;}=DateTime.UtcNow;
    public bool IsActive{get;set;}
    public Course? Courses{get;set;}
    public User? Users{get;set;}

}