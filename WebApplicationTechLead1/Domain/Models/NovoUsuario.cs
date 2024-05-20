using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationTechLead1.Domain.Models
{
    public interface IName {

        string GetName()
        {
            return "name";
        }
    }

    public sealed class NovoUsuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public NovoUsuario Clone()
        {
            return (NovoUsuario)this.MemberwiseClone();
        }
    }

    public class NovoUsuarioTemporario : NovoUsuario, IName   
    {
        public string s1 { get; set; }
        string GetName()
        {
            return "name";
        }
    }

}
