namespace TutorialProject.Models
{
    public class Contacts
{
    public int Id { get; set; }
    public string? Cname { get; set; } // Add ? to make it nullable
    public string? Email { get; set; }
    public string? Message { get; set; }
}

}
