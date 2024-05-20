namespace WebApplicationTechLead1.Domain.Models
{
    public class UsuarioUnico
    {
        private static UsuarioUnico _instance = null;
        private static readonly object _instanceLock = new object();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Cliente> _cliente { get; set; }
        public static UsuarioUnico GetInstance()
        {
            if (_instance != null) return _instance;
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new UsuarioUnico();
                }
            }
            return _instance;
        }
    }
}
