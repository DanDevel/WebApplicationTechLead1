using System.Collections.Generic;
using System.Text;

namespace WebApplicationTechLead1.Domain.Models
{
    public sealed class NovoUsuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public NovoUsuario Clone()
        {
            return (NovoUsuario) this.MemberwiseClone();
        }
    }

}
