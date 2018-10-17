using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample.WebApi.Controllers
{
    /// <summary>
    /// 测试Api
    /// </summary>
    public class TestController : ApiBaseController
    {
        /// <summary>
        /// 测试GetJson
        /// </summary>
        /// <returns></returns>
        public ActionResult GetJson() {
            var test= new TestModel() {
                Id = "1",
                Name = "test"
            };
            return new JsonResult(test);
        }
    }

    public class TestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
