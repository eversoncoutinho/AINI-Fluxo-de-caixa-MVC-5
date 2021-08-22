using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AINI_Fluxo_de_caixa.Models
{
    public class Operation
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data  { get; set; }
        [Display(Name = "Nome da Operação")]
        public string Nome { get; set; }
        [Display(Name = "Tipo (E-entrada, S-Saida)")]
        public string Tipo { get; set; } //E -  entrada S - Saida
        public decimal Valor { get; set; }
    }
}