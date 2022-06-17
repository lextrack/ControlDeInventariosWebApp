using System;
using System.Collections.Generic;

namespace ControlDeInventarios.Models
{
    public partial class Tiendum
    {
        public long Id { get; set; }
        public string? Producto { get; set; }
        public int? Entradas { get; set; }
        public int? Salidas { get; set; }
        public int? Total { get; set; }
        public int? PrecioUnitario { get; set; }
        public string? Ubicación { get; set; }
        public long? GuíaDespacho { get; set; }
        public string? Proveedor { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Observaciones { get; set; }
    }
}
