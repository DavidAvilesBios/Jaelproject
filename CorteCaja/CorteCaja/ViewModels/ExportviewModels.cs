using System;
using System.Collections.Generic;
using CorteCaja.Models;
using System.Linq;
using System.Web;

namespace CorteCaja.ViewModels
{
    public class ExportviewModels
    {
        public List<Agent> AgentsList { get; set; }
        public DateTime SelectedDate { get; set; }
        public int AgentId  {get;set;}
        public DateTime Fecha{ get; set; }
        public int CFolio { get; set; }
        public int CIDAGENTE { get; set; }
        public double CRAZONSOCIAL { get; set; }
        public double CTOTAL { get; set; }
        public int CIDPROYECTO{ get; set; }
        public double Efectivo { get; set; }
        public double Cheque{ get; set; }
        public double Transferencia{ get; set; }
        public double Tarjeta{ get; set; }
        public double Credito { get; set; }



    }
}