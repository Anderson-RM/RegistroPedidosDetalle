using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroPedidosDetalle.Entidades
{
    public class Suplidores
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("ClienteId")]
        public List<OrdenesDetalle> Detalle { get; set; } = new List<OrdenesDetalle>();
        public Suplidores()
        {
            ClienteId = 0;
            Nombre = string.Empty;
        }
    }
}
