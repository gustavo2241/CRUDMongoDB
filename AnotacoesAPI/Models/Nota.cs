using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnotacoesAPI.Models
{
    public class Nota
    {
        public Guid Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Conteudo { get; set; }
        [Required]
        public int Acessos { get; set; }
    }
}
