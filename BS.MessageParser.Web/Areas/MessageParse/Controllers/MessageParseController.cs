using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BS.MessageParser.Tool;
using BS.MessageParser.Tool.Common;
using BS.Microservice.Web.Model;

namespace BS.Microservice.Web.Areas.MessageParse.Controllers
{
    public class MessageParseController : Controller
    {
        //
        // GET: /MessageParse/MessageParse/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Parse(string msg)
        {
            var res = new ReturnMessage(false);
            if (msg.StartsWith("5B") && msg.EndsWith("5D"))
            {
                var msgArr = Parser.HexToArray(msg);
                res.IsSuccess = true;
                res.Message = Parser.Parse(msgArr);
            }
            else if (msg.StartsWith("1AE6"))
            {
                var msgArr = msg.HexStrToByteArr();
                res.IsSuccess = true;
                res.Message = OriginParser.Parse(msgArr);
            }
            else
            {
                res.IsSuccess = false;
                res.Message = "原始报文格式错误";
            }

            return Json(res);
        }
    }
}
