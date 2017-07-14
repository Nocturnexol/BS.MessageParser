using System;
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
            if (msg.StartsWith("5B", StringComparison.InvariantCultureIgnoreCase) &&
                msg.EndsWith("5D", StringComparison.InvariantCultureIgnoreCase))
            {
                var msgArr = Parser.HexToArray(msg);
                res.IsSuccess = true;
                res.Message = Parser.Parse(msgArr);
            }
            else if (msg.StartsWith("1AE6", StringComparison.InvariantCultureIgnoreCase))
            {
                var msgArr = msg.HexStrToByteArr();
                res.IsSuccess = true;
                string cmd;
                res.Message = OriginParser.Parse(msgArr, out cmd);
                if (!string.IsNullOrEmpty(cmd))
                {
                    res.Text = cmd;
                }
            }
            else if (msg.StartsWith("2BD4", StringComparison.InvariantCultureIgnoreCase))
            {
                var msgArr = msg.HexStrToByteArr();
                res.IsSuccess = true;
                res.Message = OriginParser.ParseDown(msgArr);
            }
            else
            {
                res.IsSuccess = false;
                res.Message = "原始报文格式错误";
            }

            return Json(res);
        }

        public ViewResult Locate(string lat, string lon,string time)
        {
            //var point = new GPSPoint(string.Format("{0},{1}", lon.TrimEnd('°'), lat.TrimEnd('°')));
            //var newPoint=GPSConvert.Wgs84_To_Gcj02(point);
            //var p = GPSConvert.Gcj02_To_Bd09(newPoint);
            ViewBag.Lat = lat.TrimEnd('°');
            ViewBag.Lon = lon.TrimEnd('°');
            ViewBag.time = time;
            return View();
        }

    }
}
