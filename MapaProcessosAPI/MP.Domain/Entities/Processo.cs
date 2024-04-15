using System.Data;

namespace MP.Domain.Entities
{
    public class Processo
    {
        public Processo()
        { }

        public Guid Id { get; set; }
        public Guid? IdProcessoPai { get; set; }
        public Processo? ProcessoPai { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<Processo> SubsProcessosNavigation { get; set; }

        public void AddProcesso()
        {
            this.Id = Guid.NewGuid();
            this.IsActive = true;
            this.DateCreated = DateTime.Now;
            this.DateUpdated = DateTime.Now;
        }

        public void DeleteProcesso()
        {
            this.IsActive = false;
            this.DateUpdated = DateTime.Now;
        }

        public Processo RemoveProcessoPai()
        {
            this.IdProcessoPai = null;
            this.ProcessoPai = null;
            this.DateUpdated = DateTime.Now;

            return this;
        }

        public void UpdateProcesso(string? nome, string? descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.DateUpdated = DateTime.Now;
        }

        public void UpdateProcessoPai(Processo processoPai)
        {
            this.IdProcessoPai = processoPai.Id;
            this.ProcessoPai = processoPai;
            this.DateUpdated = DateTime.Now;
        }

    }
}
