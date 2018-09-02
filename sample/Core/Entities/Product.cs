/**************************************************************** 
 * 作    者：QKL
 * CLR 版本：4.0.30319.42000
 * 创建时间：2018/08/31 23:18:39
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
    public class Product:BaseEntity<Guid>
    {
        public string ProductName { get; set; }

        public decimal DefaultPrice { get; set; }
    }
}
