using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroPedidosDetalle.Entidades
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ArticuloId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }

        public OrdenesDetalle()
        {


        }

        public OrdenesDetalle(int id, int ordenId, int articuloId, decimal cantidad, decimal precio)
        {
            Id = id;
            OrdenId = ordenId;
            ArticuloId = articuloId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
