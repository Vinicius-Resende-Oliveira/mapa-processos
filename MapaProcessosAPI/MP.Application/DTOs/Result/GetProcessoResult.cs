namespace MP.Application.DTOs.Result
{
    public class GetProcessoResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }

        public virtual ICollection<GetProcessoResult>? SubsProcessosNavigation { get; set; }
    }
}
