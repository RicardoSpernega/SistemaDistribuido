using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSisDistribuidos.Models
{
    public class Voo
    {
        public string Codigo { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime Horario { get; set; }
        public string AuxHorario 
        {
            get { return this.Horario.ToString(); }
            set { this.AuxHorario = AuxHorario;   }         
        }
        public string Companhia { get; set; }
        public string Operando { get; set; }
    }
}