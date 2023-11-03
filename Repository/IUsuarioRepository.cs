namespace Practico9
{
    public interface IUsuarioRepository
    {
        public void Create(Usuario usuario);
        public void Update(Usuario usuario);
        public List<Usuario> GetAll();
        /* public void GetById(int id);
        public void Remove(int id); */
    }
}