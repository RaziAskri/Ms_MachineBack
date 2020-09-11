using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.MSmachine.Domain.DTO
{
    public class NbrMachineDTO
    {
        public Guid id_fournisseur { get; set; }
        public string label { get; set; }
        public int nbrMachine { get; set; }
    }
}