using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL Layout entity interface. Each entity mast have identify number
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Entity identify number
        /// </summary>
        int Id { get; set; }
    }
}
