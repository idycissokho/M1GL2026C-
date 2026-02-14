namespace MemoireAppBlazor.DTOs
{
    public class FiliereDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
    }

    public class CreateFiliereDto
    {
        public string Nom { get; set; } = string.Empty;
    }

    public class UpdateFiliereDto
    {
        public string Nom { get; set; } = string.Empty;
    }
}
