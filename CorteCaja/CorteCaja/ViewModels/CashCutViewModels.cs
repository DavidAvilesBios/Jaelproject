using CorteCaja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorteCaja.ViewModels
{
    public class CashCutViewModels
    {
        public CashCutViewModels()
        {
            AgentsList = new List<Agent>();
        }

        public List<Agent> AgentsList { get; set; }
        public DateTime SelectedDate { get; set; }
        public int MilPesos { get; set; }
        public int Quinientos { get; set; }
        public int Doscientos { get; set; }
        public int CienPesos { get; set; }
        public int CincuentaPesos { get; set; }
        public int Veinte { get; set; }
        public int DiezPesos { get; set; }
        public int CincoPesos { get; set; }
        public int DosPesos { get; set; }
        public int UnPeso { get; set; }
        public int CincuentaCentavos { get; set; }
        public int Suma { get; set; }
        public int Vales { get; set; }
    }
}