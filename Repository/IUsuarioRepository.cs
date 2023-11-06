namespace Practico9
{
    public interface IUsuarioRepository
    {
        public void Create(Usuario usuario);
        public List<Usuario> GetAll();
        public Usuario GetById(int id);
        public void Update(int id, Usuario usuario);
        //public void Remove(int id); */
    }
}