namespace Gestao.Cadastro.Digital.Domain.Entities.Auth
{
    public class RefreshToken
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiraEm { get; set; }
        public bool Revogado { get; set; }
        public bool Ativo { get; private set; }

        public void Revogar() => Ativo = false;
        public bool Valido() => Ativo && ExpiraEm > DateTime.UtcNow;

        public Usuario Usuario { get; private set; } = null!;
    }
}
