namespace WebCRUD
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string NotesField { get; set; } = string.Empty;
        public string CreationTime { get; set; } = DateTime.Now.ToString("yyyyy-MM-dd HH:mm:ss");
    }
}
