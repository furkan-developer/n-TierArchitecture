using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Entities.Abstract;

namespace WebAPI.Entities
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Dicontinued { get; set; }

        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
    }
}
