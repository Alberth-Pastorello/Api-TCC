namespace Core.Entidades
{
    public abstract class Usuario
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string? Token { get; private set; }
        public string? RefreshToken { get; private set; }
        public string? TipoUsuario { get; private set; }

        public Usuario(string nome, string email, TipoUsuarioEnum tipoUsuario)
        {
            Nome = nome;
            Email = email;
            TipoUsuario = tipoUsuario;
        }
    }
}