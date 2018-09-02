/**************************************************************** 
 * 作    者：QKL
 * CLR 版本：4.0.30319.42000
 * 创建时间：2018/09/02 9:56:07
 * 当前版本：1.0.0.0
 * 描述说明： 
 *
*=====================================================================
 * 修改人员：
 * 修改时间：
 * 描    述：
 *
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using FSP.Core.Domain.Entities;

namespace Core.Entities
{
    public class Order:BaseEntity<Guid>
    {
        public string OrderCode { get; set; }
        public string OrderAddress { get; set; }
        public DateTime CreateTime { get; set; }
        public decimal OrderTotalPrice { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
