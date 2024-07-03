using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie12_13
{
    public class TableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }   
    }
}
