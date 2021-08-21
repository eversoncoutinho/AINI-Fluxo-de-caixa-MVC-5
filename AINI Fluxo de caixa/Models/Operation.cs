using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AINI_Fluxo_de_caixa.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime Data  { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; } //E -  entrada S - Saida
        public decimal Valor { get; set; }
    }
}