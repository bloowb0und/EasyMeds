namespace EasyMeds.IoT;

public class User
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string Email { get; set; }
    public List<int> Prescriptions { get; set; }
}