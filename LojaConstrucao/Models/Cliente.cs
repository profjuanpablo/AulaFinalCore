

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LojaConstrucao.Models
{
    //quando criamos uma classe criamos um TIPO
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Display(Name = "nome do cliente")]
        public string NomeCliente { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
      

      
       
    }
}
