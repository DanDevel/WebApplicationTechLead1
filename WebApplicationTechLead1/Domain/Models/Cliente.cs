using System.ComponentModel.DataAnnotations;

namespace WebApplicationTechLead1.Domain.Models
{
    public class Cliente
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório.")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "O porte da empresa é obrigatório.")]
        [RegularExpression("^(pequena|média|grande)$", ErrorMessage = "O porte da empresa deve ser 'pequena', 'média' ou 'grande'.")]
        public string PorteEmpresa { get; set; }

        public Cliente() { }

        public Cliente(string nomeEmpresa, string porteEmpresa)
        {
            NomeEmpresa = nomeEmpresa;
            PorteEmpresa = porteEmpresa;
        }

        public Cliente Clone()
        {
            return(Cliente) this.MemberwiseClone();
        }
    }
}
