using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using BS.MessageParser.Tool.Model;

namespace BS.MessageParser.Tool
{
    public class Parser
    {
        public const string EndTag = "00"; // 可变长度字符串结束符
        private static readonly Encoding EncodingGbk = Encoding.GetEncoding("GBK");//系统默认编码

        /// <summary>
        /// 将16进制字符串按2个长度进行分割
        /// </summary>
        /// <param name="hexString">16进制字符串</param>
        /// <returns></returns>
        public static string[] HexToArray(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if (hexString.Length % 2 != 0)
                hexString += " ";
            string[] returnBytes = new string[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = hexString.Substring(i * 2, 2);
            return returnBytes;
        }

        /// <summary>
        /// 解析报文
        /// </summary>
        /// <param name="msg"></param>
        public static string Parse(string[] msg)
        {
            var res = string.Empty;
            string msg_type = string.Empty;
            try
            {
                // 处理经转义处理的字符
                string[] msg_data = Parser.RestoreEscapedChars(msg);
                if (msg_data == null || msg_data.Length == 3)
                {
                    return res;
                }
                UInt32 MSG_LENGTH = Parser.GetUInt32(msg_data, 1);
                //长度相等则数据有效
                if (MSG_LENGTH == msg_data.Length)
                {
                    msg_type = Parser.GetBcd(msg_data, 9, 2);

                    if (msg_type == "0101")//GPS
                    {
                        Structs.Struct0101 obj = ConverTo0101(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0102")//到离站
                    {
                        Structs.Struct0102 obj = ConverTo0102(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0103")//WIFI
                    {
                        Structs.Struct0103 obj = ConverTo0103(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0104") //车辆状态
                    {
                        Structs.Struct0104 obj = ConverTo0104(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0105")//CAN总线
                    {
                        Structs.Struct0105 obj = ConverTo0105(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0106")//外设状态数据
                    {
                        Structs.Struct0106 obj = ConverTo0106(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0107")//超级电车数据
                    {
                        Structs.Struct0107 obj = ConverTo0107(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0108") // 能源车CAN数据
                    {
                        Structs.Struct0108 obj = ConverTo0108(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0201")//司机刷卡
                    {
                        Structs.Struct0201 obj = ConverTo0201(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0204")//发送通话请求
                    {
                        Structs.Struct0204 obj = ConverTo0204(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0208")//乘客卡刷卡统计信息
                    {
                        Structs.Struct0208 obj = ConverTo0208(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0209") //电子票箱统计信息
                    {
                        Structs.Struct0209 obj = ConverTo0209(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0210")//	员工刷卡数据
                    {
                        Structs.Struct0210 obj = ConverTo0210(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0207")//图片抓拍应答
                    {
                        Structs.Struct0207 obj = ConverTo0207(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0212")//图片数据包
                    {
                        Structs.Struct0212 obj = ConverTo0212(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0213")//图像模块状态指令
                    {
                        Structs.Struct0213 obj = ConverTo0213(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0215")//设定报警默认摄像头编号应答
                    {
                        Structs.Struct0215 obj = ConverTo0215(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0216")//客流计信息 add by hjh 2014-03-07
                    {
                        Structs.Struct0216 obj = ConverTo0216(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0301")//GPS车载设备信息 add by hjh 2014-05-20
                    {
                        Structs.Struct0301 obj = ConverTo0301(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0308")//手动切换线路 add by hjh 2014-03-07
                    {
                        Structs.Struct0308 obj = ConverTo0308(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "030A")
                    {
                        Structs.Struct030A obj = ConverTo030A(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "030B")//切换线路应答
                    {
                        Structs.Struct030B obj = ConverTo030B(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0314")//手动报警
                    {
                        Structs.Struct0314 obj = ConverTo0314(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0317")
                    {
                        Structs.Struct0317 obj = ConverTo0317(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0318")//发送实时计划应答
                    {
                        Structs.Struct0318 obj = ConverTo0318(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0321")//司机请求加入退出营运
                    {
                        Structs.Struct0321 obj = ConverTo0321(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0322")
                    {
                        Structs.Struct0322 obj = ConverTo0322(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0323")//平台加入退出营运应答（营运状态应答）
                    {
                        Structs.Struct0323 obj = ConverTo0323(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0324")//短信发送
                    {
                        Structs.Struct0324 obj = ConverTo0324(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0325")//短信应答
                    {
                        Structs.Struct0325 obj = ConverTo0325(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0327")//提取缓存数据
                    {
                        Structs.Struct0327 obj = ConverTo0327(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0328")//发送SIM卡ICCID号码请求SIM卡电话号码
                    {
                        Structs.Struct0328 obj = ConverTo0328(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "032A")//司机阅读短信确认应答
                    {
                        Structs.Struct032A obj = ConverTo032A(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0401")   // 登陆信息
                    {
                        Structs.Struct0401 obj = Parser.ConvertTo0401(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0402")  // 补发GPS位置数据
                    {
                        Structs.Struct0402 obj = Parser.ConvertTo0402(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "04FD") // 通用应答
                    {
                        Structs.Struct04FD obj = Parser.ConvertTo04FD(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "04FE") // 通用应答
                    {
                        Structs.Struct04FE obj = Parser.ConvertTo04FE(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0403") // 模拟信号启停命令
                    {
                        Structs.Struct0403 obj = Parser.ConvertTo0403(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0404") // 
                    {
                        Structs.Struct0404 obj = Parser.ConvertTo0404(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0405") // 应答0404命令
                    {
                        Structs.Struct0405 obj = Parser.ConvertTo0405(msg_data);
                        res = GetStructVal(obj);
                    }
                    else if (msg_type == "0406") // 同步发车时间
                    {
                        Structs.Struct0406 obj = Parser.ConvertTo0406(msg_data);
                        res = GetStructVal(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
                //ShowMessage("处理包异常:" + ex.ToString());
            }
            return res;
        }

        private static string GetStructVal(object obj)
        {
            StringBuilder sb = new StringBuilder();
            if (obj != null)
            {
                Type t = obj.GetType();
                PropertyInfo[] properties = t.GetProperties();
                foreach (var p in properties)
                {
                    var val = p.GetValue(obj, null);
                    if (p.PropertyType == typeof(DateTime))
                    {
                        sb.AppendFormat("{0} => {1:yyyy-MM-dd HH:mm:ss},", p.Name, Convert.ToDateTime(val));
                    }
                    else
                    {
                        sb.AppendFormat("{0} => {1},", p.Name, val);
                    }
                    sb.Append("\r\n");
                }
            }
            return sb.ToString();
        }

        #region 数据解析
        /// <summary>
        /// 解析0101数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0101 ConverTo0101(string[] msg_data)
        {
            Structs.Struct0101 obj = new Structs.Struct0101();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");
            List<byte> gpsdatetimes = (List<byte>)GetString(msg_data, 47, 60, "string");
            obj.GPSDateTime = EncodingGbk.GetString(gpsdatetimes.ToArray());
            //obj.GPSDateTime = GetTimeByString(obj.GPSDateTime); //设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.GPSDateTime = GetTimeByStrinGPS(obj.GPSDateTime, ref obj);  //140404 修改屏蔽异常，加快处理
            List<byte> senddatetimes = (List<byte>)GetString(msg_data, 61, 74, "string");
            obj.SendDateTime = EncodingGbk.GetString(senddatetimes.ToArray());
            obj.SendDateTime = GetTimeByString(obj.SendDateTime); //设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.ToDir = Convert.ToInt32((string)GetString(msg_data, 75, 75, "int"), 16);
            obj.Lon = Convert.ToUInt32((string)GetString(msg_data, 76, 79, "int"), 16) / 1000000d;
            obj.Lat = Convert.ToUInt32((string)GetString(msg_data, 80, 83, "int"), 16) / 1000000d;
            obj.Speed = Convert.ToInt32((string)GetString(msg_data, 84, 85, "int"), 16);
            obj.Height = Convert.ToInt32((string)GetString(msg_data, 86, 87, "int"), 16);
            obj.Angle = Convert.ToInt32((string)GetString(msg_data, 88, 89, "int"), 16);
            obj.PrevLevel = Convert.ToInt32((string)GetString(msg_data, 90, 91, "int"), 16);
            obj.NextLevel = Convert.ToInt32((string)GetString(msg_data, 92, 93, "int"), 16);
            obj.NextStationMeter = Convert.ToInt32((string)GetString(msg_data, 94, 95, "int"), 16);
            obj.RunStatus = Convert.ToInt32((string)GetString(msg_data, 96, 96, "int"), 16);//营运状态
            obj.Status = Convert.ToInt32((string)GetString(msg_data, 97, 97, "int"), 16);//车辆状态
            if (msg_data.Length >= 102) // 针对2.0协议
            {
                obj.Overspeed = Convert.ToInt32((string)GetString(msg_data, 98, 98, "int"), 16);//超速标准
            }

            return obj;
        }

        /// <summary>
        /// 解析0102数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0102 ConverTo0102(string[] msg_data)
        {
            Structs.Struct0102 obj = new Structs.Struct0102();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");
            obj.Source = Convert.ToInt32((string)GetString(msg_data, 47, 47, "int"), 16);
            obj.Arrive = Convert.ToInt32((string)GetString(msg_data, 48, 48, "int"), 16);
            List<byte> gpsdatetimes = (List<byte>)GetString(msg_data, 49, 62, "string");
            obj.Time = EncodingGbk.GetString(gpsdatetimes.ToArray());
            obj.Time = GetTimeByString(obj.Time); //设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.Level = Convert.ToInt32((string)GetString(msg_data, 63, 64, "int"), 16);
            obj.ToDir = Convert.ToInt32((string)GetString(msg_data, 65, 65, "int"), 16);
            obj.Lon = Convert.ToUInt32((string)GetString(msg_data, 66, 69, "int"), 16) / 1000000d;
            obj.Lat = Convert.ToUInt32((string)GetString(msg_data, 70, 73, "int"), 16) / 1000000d;
            obj.Angle = Convert.ToInt32((string)GetString(msg_data, 74, 75, "int"), 16);
            if (msg_data.Length >= 80) // 针对2.0协议
            {
                obj.StopReportingType = Convert.ToInt32((string)GetString(msg_data, 76, 76, "int"), 16);
            }

            return obj;
        }

        /// <summary>
        /// 解析0103数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0103 ConverTo0103(string[] msg_data)
        {
            Structs.Struct0103 obj = new Structs.Struct0103();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");
            List<byte> gpsdatetimes = (List<byte>)GetString(msg_data, 47, 60, "string");
            obj.Time = EncodingGbk.GetString(gpsdatetimes.ToArray());
            obj.Time = GetTimeByString(obj.Time); //设置格式为 yyyy-MM-dd hh:mm:ss 
            List<byte> senddatetimes = (List<byte>)GetString(msg_data, 61, 74, "string");
            obj.SendDateTime = EncodingGbk.GetString(senddatetimes.ToArray());
            obj.SendDateTime = GetTimeByString(obj.SendDateTime); //设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.WiFiCount = Convert.ToInt32((string)GetString(msg_data, 75, 75, "int"), 16);
            obj.WiFiDatas = new List<Structs.StructWiFiData>();
            int rdindex = 75;
            if (obj.WiFiCount > 0)
            {
                for (int j = 0; j < obj.WiFiCount; j++)
                {
                    Structs.StructWiFiData wifi = new Structs.StructWiFiData();
                    List<byte> ssiddata = (List<byte>)GetString(msg_data, rdindex + 1, rdindex + 20, "string");
                    wifi.SSID = EncodingGbk.GetString(ssiddata.ToArray()).Trim().Replace("\0", "");
                    string wifidata = (string)GetString(msg_data, rdindex + 21, rdindex + 26, "hex");
                    wifi.WiFiID = wifidata.Substring(0, 2) + ":" + wifidata.Substring(2, 2) + ":" + wifidata.Substring(4, 2) + ":" + wifidata.Substring(6, 2) + ":" + wifidata.Substring(8, 2) + ":" + wifidata.Substring(10, 2);
                    wifi.Strength = Convert.ToInt32((string)GetString(msg_data, rdindex + 27, rdindex + 27, "int"), 16);//到离站
                    rdindex += 27;
                    obj.WiFiDatas.Add(wifi);
                }
            }

            return obj;
        }

        /// <summary>
        /// 解析0104数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0104 ConverTo0104(string[] msg_data)
        {
            Structs.Struct0104 obj = new Structs.Struct0104();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");//手机IMSI	20	STRING
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");//线路名称ID	4	UINT32
            List<byte> datetimes = (List<byte>)GetString(msg_data, 47, 60, "string");//时间	14	TIME
            obj.Time = EncodingGbk.GetString(datetimes.ToArray());
            obj.Time = GetTimeByString(obj.Time);//设置格式为 yyyy-MM-dd hh:mm:ss
            obj.Lon = Convert.ToInt32((string)GetString(msg_data, 61, 64, "int"), 16) / 1000000d;//经度	4	经纬度
            obj.Lat = Convert.ToInt32((string)GetString(msg_data, 65, 68, "int"), 16) / 1000000d;//纬度	4	经纬度
            obj.Speed = Convert.ToInt32((string)GetString(msg_data, 69, 70, "int"), 16);//GPS速度	2	UINT16
            obj.Status = Convert.ToInt32((string)GetString(msg_data, 71, 74, "int"), 16);//状态信息，32个BIT

            return obj;
        }

        /// <summary>
        /// 解析0105数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0105 ConverTo0105(string[] msg_data)
        {
            Structs.Struct0105 obj = new Structs.Struct0105();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");//手机IMSI	20	STRING
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");//线路名称ID	4	UINT32
            List<byte> datetimes = (List<byte>)GetString(msg_data, 47, 60, "string");//时间	14	TIME
            obj.Time = EncodingGbk.GetString(datetimes.ToArray());
            obj.Time = GetTimeByString(obj.Time);//设置格式为 yyyy-MM-dd hh:mm:ss
            obj.Lon = Convert.ToInt32((string)GetString(msg_data, 61, 64, "int"), 16) / 1000000d;//经度	4	经纬度
            obj.Lat = Convert.ToInt32((string)GetString(msg_data, 65, 68, "int"), 16) / 1000000d;//纬度	4	经纬度
            obj.GPSSpeed = Convert.ToInt32((string)GetString(msg_data, 69, 70, "int"), 16);//GPS速度	2	UINT16
            obj.EngineRunTime = Convert.ToInt32((string)GetString(msg_data, 71, 74, "int"), 16) * 0.05;//发动机运行总时间	04H	UINT32,计算公式：值*0.05
            obj.Mileage = Convert.ToInt32((string)GetString(msg_data, 75, 78, "int"), 16) * 5;//里程	04H	UINT32,计算公式：值*5
            obj.Total_Oil = Convert.ToInt32((string)GetString(msg_data, 79, 82, "int"), 16) / 2;//总油耗	04H	UINT32 计算公式：值/2
            obj.Oil = Convert.ToInt32((string)GetString(msg_data, 83, 83, "int"), 16) * 0.4;//油表	01H	UINT8 计算公式：值*0.4
            obj.Water_Temperature = Convert.ToInt32((string)GetString(msg_data, 84, 84, "int"), 16) - 40;//水温	01H	UINT8	计算公式：值-40
            obj.Engine_Speed = Convert.ToInt32((string)GetString(msg_data, 85, 86, "int"), 16) * 0.125;//发动机转速	02H UINT16	计算公式：值*0.125
            obj.Speed = Convert.ToInt32((string)GetString(msg_data, 87, 88, "int"), 16) / 256;//速度	02H UINT16	计算公式：值/256
            obj.shousha = (byte)Convert.ToInt32((string)GetString(msg_data, 89, 89, "int"), 16);//手刹	01H
            obj.ShouSha = ((obj.shousha & (byte)0x0c) == (byte)0x04) ? 1 : 0;//假=(值&0x0c)==0x00	真=(值&0x0c)==0x04
            obj.js_xh_lh = (byte)Convert.ToInt32((string)GetString(msg_data, 90, 90, "int"), 16);//脚刹、巡航、离合	01H
            obj.JiaoSha = ((obj.js_xh_lh & (byte)0x30) == (byte)0x10) ? 1 : 0;//假=(值&0x30)==0x00	真=(值&0x30)==0x10
            obj.XunHang = ((obj.js_xh_lh & (byte)0x03) == (byte)0x01) ? 1 : 0;//假=(值&0x03)==0x00	真=(值&0x03)==0x01
            obj.LiHe = ((obj.js_xh_lh & (byte)0xc0) == (byte)0x40) ? 1 : 0;//假=(值&0xc0)==0x00	真=(值&0xc0)==0x40

            return obj;
        }

        /// <summary>
        /// 解析0106数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0106 ConverTo0106(string[] msg_data)
        {
            Structs.Struct0106 obj = new Structs.Struct0106();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");//手机IMSI	20	STRING
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            List<byte> time = (List<byte>)GetString(msg_data, 43, 56, "string");
            obj.Time = EncodingGbk.GetString(time.ToArray());
            obj.Time = GetTimeByString(obj.Time); //设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.GPS = Convert.ToInt32((string)GetString(msg_data, 57, 57, "hex"), 16);
            obj.WiFi = Convert.ToInt32((string)GetString(msg_data, 58, 58, "hex"), 16);
            obj.CAN = Convert.ToInt32((string)GetString(msg_data, 59, 59, "hex"), 16);
            obj.POS = Convert.ToInt32((string)GetString(msg_data, 60, 60, "hex"), 16);
            obj.ET = Convert.ToInt32((string)GetString(msg_data, 61, 61, "hex"), 16);
            obj.DVR = Convert.ToInt32((string)GetString(msg_data, 62, 62, "hex"), 16);
            obj.JWC = Convert.ToInt32((string)GetString(msg_data, 63, 63, "hex"), 16);
            obj.RFID = Convert.ToInt32((string)GetString(msg_data, 64, 64, "hex"), 16);

            return obj;
        }

        /// <summary>
        /// 解析0107数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0107 ConverTo0107(string[] msg_data)
        {
            Structs.Struct0107 obj = new Structs.Struct0107();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");//手机IMSI	20	STRING
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            List<byte> time = (List<byte>)GetString(msg_data, 43, 56, "string");
            obj.Time = EncodingGbk.GetString(time.ToArray());
            obj.Time = GetTimeByString(obj.Time); //设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.TotalMileage = Convert.ToInt64((string)GetString(msg_data, 57, 60, "hex"), 16);
            obj.Current = Convert.ToInt32((string)GetString(msg_data, 61, 62, "hex"), 16) - 1000;
            obj.Voltage = Convert.ToInt32((string)GetString(msg_data, 63, 64, "hex"), 16);
            obj.VoltageDifference = Convert.ToInt32((string)GetString(msg_data, 65, 66, "hex"), 16);
            obj.MeanTemperature = Convert.ToInt32((string)GetString(msg_data, 67, 67, "hex"), 16) - 40;
            obj.SOC = Convert.ToInt32((string)GetString(msg_data, 68, 68, "hex"), 16);
            obj.AllowMaxTemperature = Convert.ToInt32((string)GetString(msg_data, 69, 69, "hex"), 16) - 40;
            obj.Speed = Convert.ToInt32((string)GetString(msg_data, 70, 70, "hex"), 16);
            obj.MaxTemperature = Convert.ToInt32((string)GetString(msg_data, 71, 71, "hex"), 16) - 40;
            obj.MaxTBoxNo = Convert.ToInt32((string)GetString(msg_data, 72, 72, "hex"), 16);
            obj.TemperatureDifference = Convert.ToInt32((string)GetString(msg_data, 73, 73, "hex"), 16);
            obj.AirCondition = Convert.ToInt32((string)GetString(msg_data, 74, 74, "hex"), 16) - 30;

            return obj;
        }

        /// <summary>
        /// 解析0108数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0108 ConverTo0108(string[] msg_data)
        {
            Structs.Struct0108 obj = new Structs.Struct0108();
            int startIndex = 23;
            // 车辆ID
            obj.VehicleId = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            // 线路ID
            obj.LineId = GetBcd(msg_data, startIndex, 4);
            startIndex += 4;
            // 时间
            obj.Time = GetTimeString(msg_data, startIndex);
            startIndex += 14;
            // 经度
            obj.Lon = GetLonLat(msg_data, startIndex);
            startIndex += 4;
            // 纬度
            obj.Lat = GetLonLat(msg_data, startIndex);
            startIndex += 4;
            // 速度
            obj.Speed = GetUInt16(msg_data, startIndex);
            startIndex += 2;
            // 是否报警数据
            obj.IsAlertData = GetBcd(msg_data, startIndex, 1);
            startIndex += 1;
            // 报文条数
            obj.RecordCount = GetUInt8(msg_data, startIndex);
            startIndex += 1;
            // 数据内容
            obj.Datas = new List<Structs.StructPGNData>(obj.RecordCount);
            for (int j = 0; j < obj.RecordCount; j++)
            {
                Structs.StructPGNData data = new Structs.StructPGNData();
                data.ID = GetBcd(msg_data, startIndex, 2);
                startIndex += 2;
                data.Data = GetBcd(msg_data, startIndex, 8);
                startIndex += 8;
                obj.Datas.Add(data);
            }

            return obj;
        }

        /// <summary>
        /// 解析0201数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0201 ConverTo0201(string[] msg_data)
        {
            Structs.Struct0201 obj = new Structs.Struct0201();
            //牌照号
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            //线路名称ID
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");
            //刷卡记录数
            obj.Count = Convert.ToInt32((string)GetString(msg_data, 47, 47, "hex"), 16);
            //产生记录时间
            obj.Time = strToDataTime("20" + (string)GetString(msg_data, 48, 53, "hex"), "datetime");//设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.UID = Convert.ToInt64((string)GetString(msg_data, 54, 57, "int"), 16);
            obj.IssueDate = strToDataTime((string)GetString(msg_data, 58, 61, "hex"), "date"); // 设置格式为 yyyy-MM-dd
            obj.IssueNum = (string)GetString(msg_data, 62, 65, "hex");
            obj.ExpiryDate = strToDataTime((string)GetString(msg_data, 66, 69, "hex"), "date"); // 设置格式为 yyyy-MM-dd
            obj.TypeOfWork = Convert.ToInt32((string)GetString(msg_data, 70, 71, "hex"), 16);
            obj.IssuerCode = (string)GetString(msg_data, 72, 74, "hex");
            obj.GroupCode = (string)GetString(msg_data, 75, 76, "hex");
            obj.CropCode = (string)GetString(msg_data, 77, 78, "hex");
            obj.LineCode = (string)GetString(msg_data, 79, 80, "hex");
            obj.TeamCode = (string)GetString(msg_data, 81, 82, "hex");
            obj.EmployeeCode = (string)GetString(msg_data, 83, 86, "hex");
            obj.SignIn = Convert.ToInt32((string)GetString(msg_data, 87, 87, "hex"), 16);
            obj.Manufacturer = (string)GetString(msg_data, 88, 88, "hex");
            obj.EquipmentCode = (string)GetString(msg_data, 89, 92, "hex");
            obj.Reserv = (string)GetString(msg_data, 93, 96, "hex");

            return obj;
        }

        /// <summary>
        /// 解析0204数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0204 ConverTo0204(string[] msg_data)
        {
            Structs.Struct0204 obj = new Structs.Struct0204();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");

            return obj;
        }

        /// <summary>
        /// 解析0207数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0207 ConverTo0207(string[] msg_data)
        {
            Structs.Struct0207 obj = new Structs.Struct0207();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");//牌照号	20	STRING
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.Result = Convert.ToInt32((string)GetString(msg_data, 43, 43, "int"), 16);
            List<byte> contents = (List<byte>)GetString(msg_data, 44, 93, "string");//牌照号	20	STRING
            obj.FailReason = EncodingGbk.GetString(contents.ToArray()).Trim().Replace("\0", "");

            return obj;
        }

        /// <summary>
        /// 解析0208数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0208 ConverTo0208(string[] msg_data)
        {
            Structs.Struct0208 obj = new Structs.Struct0208();
            //牌照号
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            //线路名称ID
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");
            //发送时间
            List<byte> senddatetimes = (List<byte>)GetString(msg_data, 47, 60, "string");
            obj.SendDateTime = strToDataTime(EncodingGbk.GetString(senddatetimes.ToArray()), "datetime"); //设置格式为 yyyy-MM-dd hh:mm:ss 
            //上下行
            obj.UpDown = Convert.ToInt32((string)GetString(msg_data, 61, 61, "int"), 16);
            //站点编号
            obj.StationLevel = Convert.ToInt32((string)GetString(msg_data, 62, 63, "int"), 16);
            //本站普通卡刷卡次数--int
            obj.CommonCardTimes = Convert.ToInt32((string)GetString(msg_data, 64, 64, "int"), 16);
            //本站普通卡刷卡金额
            obj.CommonCardMoney = Convert.ToInt32((string)GetString(msg_data, 65, 68, "hex")) / 10d;
            //本站换乘优惠卡刷卡次数--int
            obj.PreferenceCardTimes = Convert.ToInt32((string)GetString(msg_data, 69, 69, "int"), 16);
            //本站换乘优惠卡刷卡金额
            obj.PreferenceCardMoney = Convert.ToInt32((string)GetString(msg_data, 70, 73, "hex")) / 10d;
            //本站老年人卡刷卡次数--int
            obj.EldelyCardTimes = Convert.ToInt32((string)GetString(msg_data, 74, 74, "int"), 16);
            //本站老年人卡刷卡金额
            obj.EldelyCardMoney = Convert.ToInt32((string)GetString(msg_data, 75, 78, "hex")) / 10d;
            //本站员工卡刷卡次数--int
            obj.EmployeeCardTimes = Convert.ToInt32((string)GetString(msg_data, 79, 79, "int"), 16);
            //本站员工卡刷卡金额
            obj.EmployeeCardMoney = Convert.ToInt32((string)GetString(msg_data, 80, 83, "hex")) / 10d;
            //本站学生卡刷卡次数--int
            obj.PupilCardTimes = Convert.ToInt32((string)GetString(msg_data, 84, 84, "int"), 16);
            //本站学生卡刷卡金额
            obj.PupilCardMoney = Convert.ToInt32((string)GetString(msg_data, 85, 88, "hex")) / 10d;
            //本站临时卡刷卡次数--int
            obj.TempCardTimes = Convert.ToInt32((string)GetString(msg_data, 89, 89, "int"), 16);
            //本站临时卡刷卡金额
            obj.TempCardMoney = Convert.ToInt32((string)GetString(msg_data, 90, 93, "hex")) / 10d;
            //保留类型
            obj.KeepType = (string)GetString(msg_data, 94, 103, "int");
            //本站累计刷卡次数--int
            obj.SumCardTimes = Convert.ToInt32((string)GetString(msg_data, 104, 105, "int"), 16);
            //本站累计刷卡金额
            obj.SumCardMoney = Convert.ToInt32((string)GetString(msg_data, 106, 109, "hex")) / 10d;
            //总共累计刷卡次数
            obj.TotalCardTimes = Convert.ToInt32((string)GetString(msg_data, 110, 113, "int"), 16);
            //总共累计刷卡金额
            obj.TotalCardMoney = Convert.ToInt32((string)GetString(msg_data, 114, 117, "hex")) / 10d;
            //当前司售人员发行流水号
            obj.DriverCardNo = (string)GetString(msg_data, 118, 121, "hex");

            return obj;
        }

        /// <summary>
        /// 解析0209数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0209 ConverTo0209(string[] msg_data)
        {
            Structs.Struct0209 obj = new Structs.Struct0209();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");
            List<byte> senddatetimes = (List<byte>)GetString(msg_data, 47, 60, "string");
            obj.SendDateTime = strToDataTime(EncodingGbk.GetString(senddatetimes.ToArray()), "datetime"); //设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.UpDown = Convert.ToInt32((string)GetString(msg_data, 61, 61, "int"), 16);
            obj.StationLevel = Convert.ToInt32((string)GetString(msg_data, 62, 63, "int"), 16);
            if (msg_data.Length >= 91) // ToDo:2014-04-17 edit by hjh [新增生产厂商(1byte)、设备编号(4byte)]
            {
                // 生产厂商
                obj.Manufacturer = ((char)Convert.ToInt32(msg_data[64], 16)).ToString();
                //设备编号
                obj.EquipmentNo = Convert.ToInt64((string)GetString(msg_data, 65, 68, "int"), 16).ToString();
                //硬币金额
                obj.CoinAmount = Convert.ToInt32((string)GetString(msg_data, 69, 70, "int"), 16) / 10d;
                //纸币金额
                obj.PaperAmount = Convert.ToInt32((string)GetString(msg_data, 71, 72, "int"), 16) / 10d;
                //未识别金额纸币张数
                obj.PaperUnknownCount = Convert.ToInt32((string)GetString(msg_data, 73, 74, "int"), 16);
                //累计硬币金额
                obj.TotalCoinAmount = Convert.ToInt32((string)GetString(msg_data, 75, 78, "int"), 16) / 10d;
                //累计纸币金额
                obj.TotalPaperAmount = Convert.ToInt32((string)GetString(msg_data, 79, 82, "int"), 16) / 10d;
                //累计未识别金额纸币张数
                obj.TotalPaperUnknown = Convert.ToInt32((string)GetString(msg_data, 83, 86, "int"), 16);
                // 刷卡机状态
                obj.Status = Convert.ToInt32((string)GetString(msg_data, 87, 87, "int"), 16);
            }
            else
            {
                //硬币金额
                obj.CoinAmount = Convert.ToInt32((string)GetString(msg_data, 64, 65, "int"), 16) / 10d;
                //纸币金额
                obj.PaperAmount = Convert.ToInt32((string)GetString(msg_data, 66, 67, "int"), 16) / 10d;
                //未识别金额纸币张数
                obj.PaperUnknownCount = Convert.ToInt32((string)GetString(msg_data, 68, 69, "int"), 16);
                //累计硬币金额
                obj.TotalCoinAmount = Convert.ToInt32((string)GetString(msg_data, 70, 73, "int"), 16) / 10d;
                //累计纸币金额
                obj.TotalPaperAmount = Convert.ToInt32((string)GetString(msg_data, 74, 77, "int"), 16) / 10d;
                //累计未识别金额纸币张数
                obj.TotalPaperUnknown = Convert.ToInt32((string)GetString(msg_data, 78, 81, "int"), 16);
                // 刷卡机状态
                obj.Status = Convert.ToInt32((string)GetString(msg_data, 82, 82, "int"), 16);
            }

            return obj;
        }

        /// <summary>
        /// 解析0210数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0210 ConverTo0210(string[] msg_data)
        {
            Structs.Struct0210 obj = new Structs.Struct0210();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");//手机IMSI	20	STRING
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");//线路名称ID
            List<byte> datetimes = (List<byte>)GetString(msg_data, 47, 60, "string");//时间	14	TIME
            obj.Time = EncodingGbk.GetString(datetimes.ToArray());
            obj.Time = GetTimeByString(obj.Time);// 设置格式为 yyyy-MM-dd hh:mm:ss 
            List<byte> cardids = (List<byte>)GetString(msg_data, 61, 70, "string");//员工号 10个字节
            obj.CardId = EncodingGbk.GetString(cardids.ToArray()).Trim().Replace("\0", "");

            return obj;
        }

        /// <summary>
        /// 解析0212数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0212 ConverTo0212(string[] msg_data)
        {
            Structs.Struct0212 obj = new Structs.Struct0212();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");//牌照号	20	STRING
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            //图片编号
            obj.ImageNo = Convert.ToInt32((string)GetString(msg_data, 43, 43, "int"), 16);
            //摄像头编号
            obj.CameraNo = Convert.ToInt32((string)GetString(msg_data, 44, 44, "int"), 16);
            //页码
            obj.PageCount = Convert.ToInt32((string)GetString(msg_data, 45, 46, "int"), 16);
            //图像数据长度
            obj.Lenght = Convert.ToInt32((string)GetString(msg_data, 47, 48, "int"), 16);
            //图像数据异或和
            obj.CRC = Convert.ToInt32((string)GetString(msg_data, 49, 49, "hex"), 16);
            //图像数据HEX 当前位置开始到 结束位置减去 最后一位 和 CRC位置共 3个字节 减去索引位置1
            string picData = (string)GetString(msg_data, 50, msg_data.Length - 4, "hex");
            obj.Content = picData;

            return obj;
        }

        /// <summary>
        /// 解析0213数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0213 ConverTo0213(string[] msg_data)
        {
            Structs.Struct0213 obj = new Structs.Struct0213();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");//牌照号	20	STRING
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.Cmd = (string)GetString(msg_data, 43, 43, "hex");
            obj.CmdArg = (string)GetString(msg_data, 44, 44, "hex");

            return obj;
        }

        /// <summary>
        /// 解析0215数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0215 ConverTo0215(string[] msg_data)
        {
            Structs.Struct0215 obj = new Structs.Struct0215();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.Result = Convert.ToInt32((string)GetString(msg_data, 43, 43, "hex"), 16);//是否设置成功
            List<byte> MsgSendErroByte = (List<byte>)GetString(msg_data, 44, 93, "string");
            obj.FailReason = EncodingGbk.GetString(MsgSendErroByte.ToArray()).Replace("\0", "");//失败原因

            return obj;
        }

        /// <summary>
        /// 解析0216数据 Add by hjh 2014-03-07
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0216 ConverTo0216(string[] msg_data)
        {
            Structs.Struct0216 obj = new Structs.Struct0216();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");
            List<byte> senddatetimes = (List<byte>)GetString(msg_data, 47, 60, "string");
            obj.SendDateTime = EncodingGbk.GetString(senddatetimes.ToArray());
            obj.SendDateTime = GetTimeByString(obj.SendDateTime); //设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.ToDir = Convert.ToInt32((string)GetString(msg_data, 61, 61, "int"), 16);
            obj.Level = Convert.ToInt32((string)GetString(msg_data, 62, 63, "int"), 16);
            obj.FrontDoorUp = Convert.ToInt32((string)GetString(msg_data, 64, 64, "int"), 16);
            obj.FrontDoorDown = Convert.ToInt32((string)GetString(msg_data, 65, 65, "int"), 16);
            obj.MiddleDoorUp = Convert.ToInt32((string)GetString(msg_data, 66, 66, "int"), 16);
            obj.MiddleDoorDown = Convert.ToInt32((string)GetString(msg_data, 67, 67, "int"), 16);
            obj.BackDoorUp = Convert.ToInt32((string)GetString(msg_data, 68, 68, "int"), 16);
            obj.BackDoorDown = Convert.ToInt32((string)GetString(msg_data, 69, 69, "int"), 16);
            // 增加前中后门上下客累计值[eidt by hjh 2015-1-27]
            int startIndex = 70;
            if (msg_data.Length > 94)
            {
                obj.TotalFrontDoorUp = GetUInt32(msg_data, startIndex);
                startIndex += 4;
                obj.TotalFrontDoorDown = GetUInt32(msg_data, startIndex);
                startIndex += 4;
                obj.TotalMiddleDoorUp = GetUInt32(msg_data, startIndex);
                startIndex += 4;
                obj.TotalMiddleDoorDown = GetUInt32(msg_data, startIndex);
                startIndex += 4;
                obj.TotalBackDoorUp = GetUInt32(msg_data, startIndex);
                startIndex += 4;
                obj.TotalBackDoorDown = GetUInt32(msg_data, startIndex);
                startIndex += 4;
            }
            obj.Reserv = GetString(msg_data, startIndex, 21); // 保留字段21
            startIndex += 21;

            return obj;
        }

        /// <summary>
        /// 解析0301数据（GPS设备信息）
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0301 ConverTo0301(string[] msg_data)
        {
            Structs.Struct0301 obj = new Structs.Struct0301();
            // 车辆Id
            List<byte> byteList = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(byteList.ToArray()).Trim().Replace("\0", "");
            // 时间
            byteList = (List<byte>)GetString(msg_data, 43, 56, "string");
            obj.SendDateTime = strToDataTime(EncodingGbk.GetString(byteList.ToArray()), "datetime"); //设置格式为 yyyy-MM-dd hh:mm:ss 

            int startIndex = 57;
            // 通讯软件版本
            byteList = GetString(msg_data, startIndex);
            obj.SoftVersion = EncodingGbk.GetString(byteList.ToArray()).Trim().Replace("\0", "");
            startIndex += byteList.Count + 1;
            // 设备序列号
            byteList = GetString(msg_data, startIndex);
            obj.EquipmentNo = EncodingGbk.GetString(byteList.ToArray()).Trim().Replace("\0", "");
            startIndex += byteList.Count + 1;
            // 线路名
            byteList = GetString(msg_data, startIndex);
            obj.LineName = EncodingGbk.GetString(byteList.ToArray()).Trim().Replace("\0", "");
            startIndex += byteList.Count + 1;
            // 线路ID 3,BCD
            obj.LineId = GetBcd(msg_data, startIndex, 3).PadLeft(8, '0');
            startIndex += 3;

            // 车牌号码
            byteList = GetString(msg_data, startIndex);
            obj.VehicleNo = EncodingGbk.GetString(byteList.ToArray()).Trim().Replace("\0", "");
            startIndex += byteList.Count + 1;
            // SIM卡ICCID号码
            byteList = GetString(msg_data, startIndex);
            obj.ICCID = EncodingGbk.GetString(byteList.ToArray()).Trim().Replace("\0", "");
            startIndex += byteList.Count + 1;
            // 生产厂商
            obj.Manufacturer = ((char)Convert.ToInt32(msg_data[startIndex], 16)).ToString();

            return obj;
        }

        /// <summary>
        /// 解析0308数据 Add by hjh 2014-03-07
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0308 ConverTo0308(string[] msg_data)
        {
            Structs.Struct0308 obj = new Structs.Struct0308();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.NewLineId = (string)GetString(msg_data, 43, 46, "hex");
            obj.OldLineId = (string)GetString(msg_data, 47, 50, "hex");
            if (msg_data.Length > 54) // 添加报站语音序号字段[2014-12-29 add by hjh]
            {
                obj.VoiceNo = Convert.ToInt32((string)GetString(msg_data, 51, 51, "hex"), 16);
            }

            return obj;
        }

        /// <summary>
        /// 解析030A数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct030A ConverTo030A(string[] msg_data)
        {
            Structs.Struct030A obj = new Structs.Struct030A();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = Convert.ToUInt32((string)GetString(msg_data, 43, 46, "hex"), 16).ToString();
            obj.VoiceNo = Convert.ToInt32((string) GetString(msg_data, 47, 47, "hex"), 16);
            obj.SubLineCode = Convert.ToInt32((string) GetString(msg_data, 48, 48, "hex"), 16);
            obj.ReportType = Convert.ToInt32((string) GetString(msg_data, 49, 49, "hex"), 16);
            obj.UpDown = Convert.ToInt32((string)GetString(msg_data, 50, 50, "hex"), 16);
            obj.ReportCode = (string) GetString(msg_data, 51, 66, "hex");
            return obj;
        }

        /// <summary>
        /// 解析030B数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct030B ConverTo030B(string[] msg_data)
        {
            Structs.Struct030B obj = new Structs.Struct030B();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.Result = Convert.ToInt32((string)GetString(msg_data, 43, 43, "hex"), 16);//是否发送成功
            List<byte> MsgSendErroByte = (List<byte>)GetString(msg_data, 44, 93, "string");
            obj.FailReason = EncodingGbk.GetString(MsgSendErroByte.ToArray()).Replace("\0", "");//发送错误原因

            return obj;
        }

        /// <summary>
        /// 解析0314数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0314 ConverTo0314(string[] msg_data)
        {
            Structs.Struct0314 obj = new Structs.Struct0314();
            List<byte> mobiles = (List<byte>)GetString(msg_data, 23, 42, "string");//手机IMSI	20	STRING
            obj.VehicleId = EncodingGbk.GetString(mobiles.ToArray()).Trim().Replace("\0", "");
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");//线路名称ID	4	UINT32
            List<byte> datetimes = (List<byte>)GetString(msg_data, 47, 60, "string");//时间	14	TIME
            obj.Time = EncodingGbk.GetString(datetimes.ToArray());
            obj.Time = GetTimeByString(obj.Time); // 设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.Lon = Convert.ToUInt32((string)GetString(msg_data, 61, 64, "int"), 16) / 1000000d;//经度	4	经纬度
            obj.Lat = Convert.ToUInt32((string)GetString(msg_data, 65, 68, "int"), 16) / 1000000d;//纬度	4	经纬度
            obj.Speed = Convert.ToInt32((string)GetString(msg_data, 69, 70, "int"), 16);//GPS速度	2
            obj.AlertCode = Convert.ToInt32((string)GetString(msg_data, 71, 72, "int"), 16);//GPS速度	2

            return obj;
        }

        /// <summary>
        /// 解析0317数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0317 ConverTo0317(string[] msg_data)
        {
            Structs.Struct0317 obj = new Structs.Struct0317();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            List<byte> nums = (List<byte>)GetString(msg_data, 43, 62, "string");
            obj.VehicleNumber = EncodingGbk.GetString(nums.ToArray()).Trim().Replace("\0", "");
            obj.CompleteBC = Convert.ToInt32((string) GetString(msg_data, 63, 63, "hex"), 16);
            obj.PlanBC = Convert.ToInt32((string) GetString(msg_data, 64, 64, "hex"), 16);

            obj.FaCheTime = Convert.ToInt32((string) GetString(msg_data, 65, 65, "hex"), 16) + ":" +
                            Convert.ToInt32((string) GetString(msg_data, 66, 66, "hex"), 16);
            List<byte> datetimes = (List<byte>)GetString(msg_data, 67, 80, "string");//时间	14	TIME
            obj.UpdateTime = EncodingGbk.GetString(datetimes.ToArray());
            obj.UpdateTime = GetTimeByString(obj.UpdateTime); // 设置格式为 yyyy-MM-dd hh:mm:ss 
            return obj;

        }

        /// <summary>
        /// 解析0318数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0318 ConverTo0318(string[] msg_data)
        {
            Structs.Struct0318 obj = new Structs.Struct0318();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.Result = Convert.ToInt32((string)GetString(msg_data, 43, 43, "hex"), 16);//是否发送成功
            List<byte> MsgSendErroByte = (List<byte>)GetString(msg_data, 44, 93, "string");
            obj.FailReason = EncodingGbk.GetString(MsgSendErroByte.ToArray()).Replace("\0", "");//发送错误原因

            return obj;
        }

        /// <summary>
        /// 解析0321数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0321 ConverTo0321(string[] msg_data)
        {
            Structs.Struct0321 obj = new Structs.Struct0321();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            //线路名称ID
            obj.LineId = (string)GetString(msg_data, 43, 46, "hex");
            List<byte> senddatetimes = (List<byte>)GetString(msg_data, 47, 60, "string");
            obj.Time = strToDataTime(EncodingGbk.GetString(senddatetimes.ToArray()), "datetime");// 设置格式为 yyyy-MM-dd hh:mm:ss 
            obj.Lon = Convert.ToInt32((string)GetString(msg_data, 61, 64, "int"), 16) / 1000000d;
            obj.Lat = Convert.ToInt32((string)GetString(msg_data, 65, 68, "int"), 16) / 1000000d;
            obj.Speed = Convert.ToInt32((string)GetString(msg_data, 69, 70, "int"), 16);
            obj.InOut = Convert.ToInt32((string)GetString(msg_data, 71, 71, "int"), 16);

            return obj;
        }

        /// <summary>
        /// 解析0322数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0322 ConverTo0322(string[] msg_data)
        {
            Structs.Struct0322 obj = new Structs.Struct0322();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = Convert.ToUInt32((string)GetString(msg_data, 43, 46, "hex"), 16).ToString();
            obj.Mode = (string) GetString(msg_data, 47, 47, "hex");
            return obj;
        }

        /// <summary>
        /// 解析0323数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0323 ConverTo0323(string[] msg_data)
        {
            Structs.Struct0323 obj = new Structs.Struct0323();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.Result = Convert.ToInt32((string)GetString(msg_data, 43, 43, "hex"), 16);//是否发送成功
            List<byte> MsgSendErroByte = (List<byte>)GetString(msg_data, 44, 93, "string");
            obj.FailReason = EncodingGbk.GetString(MsgSendErroByte.ToArray()).Replace("\0", "");//发送错误原因

            return obj;
        }

        /// <summary>
        /// 解析0323数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0324 ConverTo0324(string[] msg_data)
        {
            Structs.Struct0324 obj = new Structs.Struct0324();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.LineId = Convert.ToUInt32((string)GetString(msg_data, 43, 46, "hex"), 16).ToString();
            obj.Type = Convert.ToInt32((string) GetString(msg_data, 47, 47, "hex"), 16).ToString();
            obj.Content =
                EncodingGbk.GetString(((List<byte>) GetString(msg_data, 48, 147, "string")).ToArray())
                    .Trim()
                    .Replace("\0", "");
            obj.MsgId = Convert.ToInt32((string) GetString(msg_data, 148, 151, "hex"), 16).ToString();

            return obj;
        }

        /// <summary>
        /// 解析0325数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0325 ConverTo0325(string[] msg_data)
        {
            Structs.Struct0325 obj = new Structs.Struct0325();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.Result = Convert.ToInt32((string)GetString(msg_data, 43, 43, "hex"), 16);//是否发送成功
            List<byte> MsgSendErroByte = (List<byte>)GetString(msg_data, 44, 93, "string");
            obj.FailReason = EncodingGbk.GetString(MsgSendErroByte.ToArray()).Replace("\0", "");//发送错误原因

            return obj;
        }

        /// <summary>
        /// 解析0327数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0327 ConverTo0327(string[] msg_data)
        {
            Structs.Struct0327 obj = new Structs.Struct0327();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");//手机IMSI	20	STRING
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.Result = Convert.ToInt32((string)GetString(msg_data, 43, 43, "int"), 16);//应答 1成功 0失败
            obj.Date = "20" + Convert.ToInt32((string)GetString(msg_data, 44, 44, "int"), 16).ToString().PadLeft(2, '0') + "-" + Convert.ToInt32((string)GetString(msg_data, 45, 45, "int"), 16).ToString().PadLeft(2, '0') + "-" + Convert.ToInt32((string)GetString(msg_data, 46, 46, "int"), 16).ToString().PadLeft(2, '0');//日期
            obj.Time = Convert.ToInt32((string)GetString(msg_data, 47, 47, "int"), 16).ToString().PadLeft(2, '0') + ":" + Convert.ToInt32((string)GetString(msg_data, 48, 48, "int"), 16).ToString().PadLeft(2, '0');
            obj.RecordCount = Convert.ToInt32((string)GetString(msg_data, 49, 49, "int"), 16);
            obj.Datas = new List<Structs.StructCacheData>();
            int startIndex = 50;
            //提取
            //50 开始
            for (int j = 0; j < obj.RecordCount; j++)
            {
                Structs.StructCacheData cache = new Structs.StructCacheData();
                cache.Time = Convert.ToInt32((string)GetString(msg_data, (startIndex), (startIndex), "int"), 16).ToString().PadLeft(2, '0') + ":" + Convert.ToInt32((string)GetString(msg_data, (startIndex + 1), (startIndex + 1), "int"), 16).ToString().PadLeft(2, '0') + ":" + Convert.ToInt32((string)GetString(msg_data, (startIndex + 2), (startIndex + 2), "int"), 16).ToString().PadLeft(2, '0');
                startIndex += 3;
                cache.Lon = Convert.ToInt32((string)GetString(msg_data, startIndex, startIndex + 3, "int"), 16) / 1000000d;//经度	4	经纬度
                startIndex += 4;
                cache.Lat = Convert.ToInt32((string)GetString(msg_data, startIndex, startIndex + 3, "int"), 16) / 1000000d;//纬度	4	经纬度
                startIndex += 4;
                cache.Speed = Convert.ToInt32((string)GetString(msg_data, startIndex, startIndex + 1, "int"), 16);
                startIndex += 2;
                cache.Angle = Convert.ToInt32((string)GetString(msg_data, startIndex, startIndex + 1, "int"), 16);
                startIndex += 2;
                obj.Datas.Add(cache);
            }

            return obj;
        }

        /// <summary>
        /// 解析0328数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct0328 ConverTo0328(string[] msg_data)
        {
            Structs.Struct0328 obj = new Structs.Struct0328();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");

            List<byte> iccid = (List<byte>)GetString(msg_data, 43, 63, "string");
            obj.ICCID = EncodingGbk.GetString(iccid.ToArray()).Replace("\0", "");//发送错误原因

            return obj;
        }

        /// <summary>
        /// 解析032A数据
        /// </summary>
        /// <param name="msg_data"></param>
        /// <returns></returns>
        public static Structs.Struct032A ConverTo032A(string[] msg_data)
        {
            Structs.Struct032A obj = new Structs.Struct032A();
            List<byte> codes = (List<byte>)GetString(msg_data, 23, 42, "string");
            obj.VehicleId = EncodingGbk.GetString(codes.ToArray()).Trim().Replace("\0", "");
            obj.MsgId = Convert.ToInt32((string)GetString(msg_data, 43, 46, "hex"), 16).ToString();//短信ID
            obj.Result = Convert.ToInt32((string)GetString(msg_data, 47, 47, "hex"), 16);//返回代码
            return obj;
        }
        #endregion
        #region 解析5B5D报文相关方法
        /// <summary>
        /// 解析调度客户端登录数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Structs.Struct0401 ConvertTo0401(string[] msg_data)
        {
            Structs.Struct0401 obj = new Structs.Struct0401();
            int startIndex = 23;
            // 线路Id
            obj.LineId = GetBcd(msg_data, startIndex, 3);
            startIndex += 3;
            // 线路名
            obj.LineName = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            // 登录名
            obj.LoginName = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            // 登录时间
            obj.LoginTime = Get7BcdTime(msg_data, startIndex);
            startIndex += 7;
            // 版本号
            obj.Version = GetString(msg_data, startIndex, 8);
            startIndex += 8;

            return obj;
        }

        /// <summary>
        /// 解析04EF协议
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Structs.Struct04FE ConvertTo04FE(string[] msg_data)
        {
            Structs.Struct04FE obj = new Structs.Struct04FE();
            int startIndex = 23;
            // 命令字
            obj.MSG_ID = GetBcd(msg_data, startIndex, 2);
            startIndex += 2;
            // 命令序列号
            obj.MSG_SN = GetUInt32(msg_data, startIndex);
            startIndex += 4;
            // 附加消息
            int count;
            obj.MSG = GetVString(msg_data, startIndex, out count);

            return obj;
        }

        /// <summary>
        /// 解析04EF协议
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Structs.Struct04FD ConvertTo04FD(string[] msg_data)
        {
            Structs.Struct04FD obj = new Structs.Struct04FD();
            int startIndex = 23;
            // 命令字
            obj.MSG_ID = GetBcd(msg_data, startIndex, 2);
            startIndex += 2;
            // 命令序列号
            obj.MSG_SN = GetUInt32(msg_data, startIndex);
            startIndex += 4;
            // 附加消息
            int count;
            obj.MSG = GetVString(msg_data, startIndex, out count);

            return obj;
        }

        /// <summary>
        /// 解析GPS位置数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Structs.Struct0402 ConvertTo0402(string[] msg_data)
        {
            Structs.Struct0402 obj = new Structs.Struct0402();
            int startIndex = 23;
            obj.LineId = GetBcd(msg_data, startIndex, 3);
            startIndex += 3;
            obj.LineName = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            obj.VehicleId = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            obj.GPSDateTime = Get7BcdTime(msg_data, startIndex);
            startIndex += 7;
            obj.SendDateTime = Get7BcdTime(msg_data, startIndex);
            startIndex += 7;
            obj.UpDown = GetUInt8(msg_data, startIndex);
            startIndex += 1;
            obj.Lon = GetLonLat(msg_data, startIndex);
            startIndex += 4;
            obj.Lat = GetLonLat(msg_data, startIndex);
            startIndex += 4;
            obj.Lon84 = GetLonLat(msg_data, startIndex);
            startIndex += 4;
            obj.Lat84 = GetLonLat(msg_data, startIndex);
            startIndex += 4;
            obj.Speed = GetUInt16(msg_data, startIndex);
            startIndex += 2;
            obj.Angle = GetUInt16(msg_data, startIndex);
            startIndex += 2;
            obj.NextLevel = GetUInt8(msg_data, startIndex);
            startIndex += 1;
            obj.NextStationMeter = GetUInt16(msg_data, startIndex);
            startIndex += 2;
            obj.RunStatus = GetUInt8(msg_data, startIndex);//营运状态
            startIndex += 1;
            obj.VehStatus = GetUInt8(msg_data, startIndex);//车辆状态
            startIndex += 1;
            obj.Overspeed = GetUInt8(msg_data, startIndex);//超速标准
            startIndex += 1;
            obj.Location = GetUInt8(msg_data, startIndex);//位置
            startIndex += 1;
            obj.Source = GetUInt8(msg_data, startIndex);//来源 01:GPS 02：RFID 03：WIFI 04：模拟信号
            startIndex += 1;

            return obj;
        }

        /// <summary>
        /// 解析0403协议
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Structs.Struct0403 ConvertTo0403(string[] msg_data)
        {
            Structs.Struct0403 obj = new Structs.Struct0403();
            int startIndex = 23;
            obj.LineId = GetBcd(msg_data, startIndex, 3);
            startIndex += 3;
            obj.LineName = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            obj.VehicleId = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            obj.OnOff = GetUInt8(msg_data, startIndex);
            startIndex += 1;
            obj.StationLevel = GetUInt8(msg_data, startIndex);
            startIndex += 1;
            obj.UpDown = GetUInt8(msg_data, startIndex);
            startIndex += 1;
            obj.QC_Count = GetUInt8(msg_data, startIndex);
            startIndex += 1;

            return obj;
        }

        /// <summary>
        /// 解析0404协议
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Structs.Struct0404 ConvertTo0404(string[] msg_data)
        {
            Structs.Struct0404 obj = new Structs.Struct0404();
            int startIndex = 23;
            obj.LineId = GetBcd(msg_data, startIndex, 3);
            startIndex += 3;
            obj.LineName = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            obj.VehicleId = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            int count;
            obj.MSG = GetVString(msg_data, startIndex, out count);
            startIndex += count;

            return obj;
        }

        /// <summary>
        /// 解析0405协议
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Structs.Struct0405 ConvertTo0405(string[] msg_data)
        {
            Structs.Struct0405 obj = new Structs.Struct0405();
            int startIndex = 23;
            obj.LineId = GetBcd(msg_data, startIndex, 3);
            startIndex += 3;
            obj.LineName = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            obj.VehicleId = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            obj.MSG_SN = GetUInt32(msg_data, startIndex);
            startIndex += 4;
            int count;
            obj.MSG = GetVString(msg_data, startIndex, out count);
            startIndex += count;

            return obj;
        }

        /// <summary>
        /// 解析0406协议
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Structs.Struct0406 ConvertTo0406(string[] msg_data)
        {
            Structs.Struct0406 obj = new Structs.Struct0406();
            int startIndex = 23;
            obj.LineId = GetBcd(msg_data, startIndex, 3);
            startIndex += 3;
            obj.LineName = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            obj.UpDown = GetUInt8(msg_data, startIndex);
            startIndex += 1;
            obj.SendDateTime = GetBcd(msg_data, startIndex, 4);
            startIndex += 4;
            obj.VehicleId = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            obj.SyncTime = GetBcd(msg_data, startIndex, 2);
            startIndex += 2;
            obj.VehicleId2 = GetString(msg_data, startIndex, 20);
            startIndex += 20;
            obj.SyncTime2 = GetBcd(msg_data, startIndex, 2);
            startIndex += 2;

            return obj;
        }

        #endregion
        /// <summary>
        /// 拆分数据
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="msgtype"></param>
        /// <returns></returns>
        private static object GetString(string[] msgs, int start, int end, string msgtype)
        {
            List<byte> msgarry = new List<byte>();
            string msg = "0x";
            for (int i = start; i <= end; i++)
            {
                if (msgtype == "string")
                {
                    msgarry.Add((byte)Convert.ToInt32(msgs[i], 16));
                }
                else
                {
                    msg += msgs[i];
                }
            }
            if (msgtype == "string")
            {
                return msgarry;
            }
            else if (msgtype == "hex")
            {
                return msg = msg.Replace("0x", "");
            }
            else
            {
                return msg;
            }
        }
        private static string GetTimeByString(string time)
        {
            StringBuilder sb = new StringBuilder(20);
            try
            {
                if (time.Length >= 14)
                {
                    sb.Append(time.Substring(0, 4));
                    sb.Append("-");
                    sb.Append(time.Substring(4, 2));
                    sb.Append("-");
                    sb.Append(time.Substring(6, 2));
                    sb.Append(" ");
                    sb.Append(time.Substring(8, 2));
                    sb.Append(":");
                    sb.Append(time.Substring(10, 2));
                    sb.Append(":");
                    sb.Append(time.Substring(12, 2));
                }
            }
            catch (Exception ex)
            {
            }
            string rtn = sb.ToString();
            sb = null;
            return string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Parse(rtn));

        }

        /// <summary>
        /// 获取定长字符串,位数不够以0x00填充
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="start">开始位置</param>
        /// <param name="count">截取长度</param>
        /// <returns></returns>
        private static string GetString(string[] msgs, int start, int count)
        {
            string s = string.Empty;
            if (start < msgs.Length)
            {
                var bts = msgs.Skip(start).Take(count).Select(p => Convert.ToByte(p, 16)).ToArray();
                s = EncodingGbk.GetString(bts).Replace("\0", "");
            }
            return s;
        }

        /// <summary>
        /// 获取uint32类型字段的值
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="start">开始位置</param>
        /// <returns></returns>
        public static UInt32 GetUInt32(string[] msgs, int start)
        {
            string s = GetBcd(msgs, start, 4);
            return Convert.ToUInt32(s, 16);
        }

        /// <summary>
        /// 获取BCD字符串
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="start">开始位置</param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetBcd(string[] msgs, int start, int count)
        {
            string s = string.Empty;
            if (start < msgs.Length)
            {
                s = string.Join("", msgs.Skip(start).Take(count));
            }
            return s;
        }

        /// <summary>
        /// 部分老车载发送的gps信号中的时间是非法的
        /// 用异常来处理效率很低
        /// add by zyh  140404
        /// </summary>
        /// <param name="time"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string GetTimeByStrinGPS(string time, ref Structs.Struct0101 obj)
        {
            StringBuilder sb = new StringBuilder(20);
            sb.Append(time.Substring(0, 4));
            sb.Append("-");
            sb.Append(time.Substring(4, 2));
            sb.Append("-");
            sb.Append(time.Substring(6, 2));
            sb.Append(" ");
            sb.Append(time.Substring(8, 2));
            sb.Append(":");
            sb.Append(time.Substring(10, 2));
            sb.Append(":");
            sb.Append(time.Substring(12, 2));
            DateTime dt;
            string rtn = sb.ToString();
            sb = null;
            if (DateTime.TryParse(rtn, out dt)) //检查是否是合法时间
            {
                obj.invalidGpsDT = false;
                return rtn;
            }
            else
            {
                obj.invalidGpsDT = true;
                return "INVALIDDT:" + rtn;
            }
        }

        /// <summary>
        /// 解析不定长字符串,以0x00结尾
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="start">开始位置</param>
        /// <param name="count"></param>
        /// <returns></returns>
        private static string GetVString(string[] msgs, int start, out int count)
        {
            string s = string.Empty;
            count = 0;
            if (start < msgs.Length)
            {
                var bts = msgs.Skip(start).TakeWhile(p => p != EndTag).Select(p => Convert.ToByte(p, 16)).ToArray();
                count = bts.Length + 1;
                s = EncodingGbk.GetString(bts);
            }
            return s;
        }
        /// <summary>
        /// 解析TIME类型的值(14位长度定长字符串),返回"yyyy-MM-dd HH:mm:ss"格式字符串
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="start">开始位置</param>
        /// <returns>返回"yyyy-MM-dd HH:mm:ss"格式字符串</returns>
        private static string GetTimeString(string[] msgs, int start)
        {
            string time = EncodingGbk.GetString(msgs.Skip(start).Take(14).Select(p => Convert.ToByte(p, 16)).ToArray());
            StringBuilder sb = new StringBuilder(20);
            sb.Append(time.Substring(0, 4));
            sb.Append("-");
            sb.Append(time.Substring(4, 2));
            sb.Append("-");
            sb.Append(time.Substring(6, 2));
            sb.Append(" ");
            sb.Append(time.Substring(8, 2));
            sb.Append(":");
            sb.Append(time.Substring(10, 2));
            sb.Append(":");
            sb.Append(time.Substring(12, 2));
            return sb.ToString();
        }
        /// <summary>
        /// 还原经转义处理的字符 5A-01=>5B;5A-02=>5A;5E-01=>5D;5E-02=>5E;
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string[] RestoreEscapedChars(string[] bytes)
        {
            string[] arr = null;
            if (bytes != null && bytes.Length > 0)
            {
                string str = string.Join("-", bytes.Select(p => p.ToUpper()));
                arr = str.Replace("5A-01", "5B").Replace("5A-02", "5A").Replace("5E-01", "5D").Replace("5E-02", "5E").Split('-');
            }
            return arr;
        }
        /// <summary>
        /// 获取uint32_t类型经纬度的值,如121.1234567度
        /// </summary>
        /// <param name="bts"></param>
        /// <param name="start">开始位置</param>
        /// <returns></returns>
        public static double GetLonLat(string[] bts, int start)
        {
            string str = GetBcd(bts, start, 4);
            double d = Convert.ToUInt32(str, 16) / 1000000d;
            return Math.Round(d, 6);
        }
        /// <summary>
        /// 获取uint8类型字段的值
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="start">开始位置</param>
        /// <returns></returns>
        private static int GetUInt8(string[] msgs, int start)
        {
            return Convert.ToInt32(msgs[start], 16);
        }

        /// <summary>
        /// 获取uint16类型字段的值
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="start">开始位置</param>
        /// <returns></returns>
        private static UInt16 GetUInt16(string[] msgs, int start)
        {
            string s = GetBcd(msgs, start, 2);
            return Convert.ToUInt16(s, 16);
        }
        private static string strToDataTime(string time, string typename)
        {
            string datetime = DateTime.Parse("2000-01-01").ToString(CultureInfo.InvariantCulture);
            try
            {
                if (typename == "date")
                {
                    if (time.Length >= 8)
                    {
                        datetime = time.Substring(0, 4) + "-" + time.Substring(4, 2) + "-" + time.Substring(6, 2);
                    }
                }
                else
                {
                    if (time.Length >= 14)
                    {
                        datetime = time.Substring(0, 4) + "-" + time.Substring(4, 2) + "-" + time.Substring(6, 2) + " " + time.Substring(8, 2) + ":" + time.Substring(10, 2) + ":" + time.Substring(12, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                // ignored
            }
            return datetime;
        }
        /// <summary>
        /// 解析不定长字符串
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="start">开始位置</param>
        /// <returns></returns>
        private static List<byte> GetString(string[] msgs, int start)
        {
            List<byte> byteList = new List<byte>();
            string s = null;
            while (start < msgs.Length)
            {
                s = msgs[start];
                if (s == EndTag) // 遇到结束符"00"则退出循环
                {
                    break;
                }
                byteList.Add((byte)Convert.ToInt32(s, 16));
                start++;
            }
            return byteList;
        }
        /// <summary>
        /// 解析7位BCD类型时间YYYYMMDDHHmmss
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="start">开始位置</param>
        /// <returns></returns>
        public static DateTime Get7BcdTime(string[] msgs, int start)
        {
            string time = GetBcd(msgs, start, 7);
            StringBuilder sb = new StringBuilder(20);
            sb.Append(time.Substring(0, 4));
            sb.Append("-");
            sb.Append(time.Substring(4, 2));
            sb.Append("-");
            sb.Append(time.Substring(6, 2));
            sb.Append(" ");
            sb.Append(time.Substring(8, 2));
            sb.Append(":");
            sb.Append(time.Substring(10, 2));
            sb.Append(":");
            sb.Append(time.Substring(12, 2));
            return Convert.ToDateTime(sb.ToString());
        }


    }
}