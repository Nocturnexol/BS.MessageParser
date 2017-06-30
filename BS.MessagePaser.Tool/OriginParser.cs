using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BS.MessageParser.Tool.Model;
using BS.MessageParser.Tool.Common;

namespace BS.MessageParser.Tool
{
    public static class OriginParser
    {
        private static readonly Encoding MessageEncoding = Encoding.GetEncoding("GBK");
        public static string Parse(byte[] arr)
        {
            int vnEndIndex;
            var data = arr.ParseBaseData(out vnEndIndex);
            var bodyArr = arr.CloneRange(vnEndIndex + 8, arr.Length - 6 - (vnEndIndex + 8) + 1);
            var res = string.Empty;
            if (data.CommandCode == 0x10)
            {
                var body = Parse0X10(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x11)
            {
                var body = Parse0X11(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x14)
            {
                var body = Parse0X14(bodyArr);
                res= GetString(body);
            }
            else if (data.CommandCode == 0x17)
            {
                var body = Parse0X17(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x18)
            {
                var body = Parse0X18(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x1a)
            {
                var body = Parse0X1A(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x20)
            {
                var body = Parse0X20(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x25 || data.CommandCode == 0x26 || data.CommandCode == 0x27)
            {
                var body = Parse0X252627(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x33)
            {
                var body = Parse0X33(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x3a)
            {
                var body = Parse0X3A(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x3b)
            {
                var body = Parse0X3B(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x40 || data.CommandCode == 0x41)
            {
                var body = Parse0X4041(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x42)
            {
                var body = Parse0X42(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x43)
            {
                var body = Parse0X43(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x44)
            {
                var body = Parse0X44(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x45)
            {
                var body = Parse0X45(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x47)
            {
                var body = Parse0X47(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x48)
            {
                var body = Parse0X48(bodyArr);
                res = GetString(body);
            }
            else if (data.CommandCode == 0x49)
            {
                var body = Parse0X49(bodyArr);
                res = GetString(body);
            }
            return GetString(data) + res;
        }

        private static Data0X10 Parse0X10(IList<byte> arr)
        {
            var body=new Data0X10();
            body.ResponseCommand = arr[0];
            body.ResponseNum = arr[1];
            body.ResponseReturn = arr.CloneRange(2, arr.Count - 2).ByteArrToLong();
            return body;
        }
        private static Data0X11 Parse0X11(IList<byte> arr)
        {
            var body = new Data0X11();
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            body.VehicleStatus = arr[12];
            var verEndIndex = Array.IndexOf(arr.CloneRange(13, arr.Count - 13), (byte)0) + 13;
            body.SoftwareVer = MessageEncoding.GetString(arr.CloneRange(13, verEndIndex - 13));

            var deviceNumStrEndIndex =
                Array.IndexOf(arr.CloneRange(verEndIndex + 1, arr.Count - (verEndIndex + 1)), (byte) 0) + verEndIndex +
                1;
            body.DeviceNum =
                MessageEncoding.GetString(arr.CloneRange(verEndIndex + 1, deviceNumStrEndIndex - (verEndIndex + 1)));

            var lineNameEndIndex =
                Array.IndexOf(arr.CloneRange(deviceNumStrEndIndex + 1, arr.Count - (deviceNumStrEndIndex + 1)), (byte) 0) +
                deviceNumStrEndIndex + 1;
            body.LineName =
                MessageEncoding.GetString(arr.CloneRange(deviceNumStrEndIndex + 1,
                    lineNameEndIndex - (deviceNumStrEndIndex + 1)));

            body.LineId = arr.CloneRange(lineNameEndIndex + 1, 3).ByteArrToInt();

            var plateNumEndIndex =
                Array.IndexOf(arr.CloneRange(lineNameEndIndex + 4, arr.Count - (lineNameEndIndex + 4)), (byte) 0) +
                lineNameEndIndex + 4;
            body.PlateNum =
                MessageEncoding.GetString(arr.CloneRange(lineNameEndIndex + 4,
                    plateNumEndIndex - (lineNameEndIndex + 4)));

            var simEndIndex =
                Array.IndexOf(arr.CloneRange(plateNumEndIndex + 1, arr.Count - (plateNumEndIndex + 1)), (byte) 0) +
                plateNumEndIndex + 1;
            body.SIM =
                MessageEncoding.GetString(arr.CloneRange(plateNumEndIndex + 1, simEndIndex - (plateNumEndIndex + 1)));

            body.Factory = MessageEncoding.GetString(arr.CloneRange(simEndIndex + 1, 1));

            return body;
        }
        private static Data0X14 Parse0X14(IList<byte> arr)
        {
            var body = new Data0X14();
            var driverIdStrEndIndex = Array.IndexOf(arr.CloneRange(29, arr.Count - 29), (byte)0) + 29;
            var localeStrEndIndex =
                Array.IndexOf(arr.CloneRange(driverIdStrEndIndex + 3, arr.Count - (driverIdStrEndIndex + 3)), (byte)0) +
                driverIdStrEndIndex + 3;
            var cellIdStrEndIndex =
                Array.IndexOf(arr.CloneRange(localeStrEndIndex + 1, arr.Count - (localeStrEndIndex + 1)), (byte)0) +
                localeStrEndIndex + 1;
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            body.VehicleStatus = arr[12];
            body.DirectionMark = arr[13];
            body.NextStationNum = arr[14];
            body.DistanceToNextStation = Convert.ToUInt16(arr.CloneRange(15, 2).ByteArrToHexStr(), 16);
            body.IsInStation = arr[17];
            body.IsCaching = arr[18];
            body.Mileage = arr.CloneRange(19, 3).ByteArrToInt();
            body.OverspeedCriterion = arr[22];
            body.Temperature = Convert.ToUInt16(arr.CloneRange(23, 2).ByteArrToHexStr(), 16);
            body.FuelInt = Convert.ToUInt16(arr.CloneRange(25, 2).ByteArrToHexStr(), 16);
            body.FuelFraction = arr[27];
            body.ServiceStatus = arr[28];
            body.DriverId = MessageEncoding.GetString(arr.CloneRange(29, driverIdStrEndIndex - 29));
            body.SIMCardType = arr[driverIdStrEndIndex + 1];
            body.BaseLocationStatus = arr[driverIdStrEndIndex + 2];
            body.BaseLocationLocale = MessageEncoding.GetString(arr.CloneRange(driverIdStrEndIndex + 3, localeStrEndIndex - (driverIdStrEndIndex + 3)));
            body.BaseLocationCellId = MessageEncoding.GetString(arr.CloneRange(localeStrEndIndex + 1, cellIdStrEndIndex - (localeStrEndIndex + 1)));
            return body;
        }

        private static Data0X17 Parse0X17(IList<byte> arr)
        {
            var body = new Data0X17();
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            body.VehicleStatus = arr[12];
            body.HotSpotPeriod = arr[13];
            body.HotSpotCount = arr[14];
            var hotspots = arr.CloneRange(15, arr.Count - 15);
            var list = new List<HotSpot>();
            for (var i = 0; i < body.HotSpotCount; i++)
            {
                var ssidEndIndex = Array.IndexOf(hotspots, (byte)0);
                var hotspot=new HotSpot();
                hotspot.SSID = MessageEncoding.GetString(hotspots.CloneRange(0, ssidEndIndex));
                hotspot.IPv6 = Convert.ToInt64(hotspots.CloneRange(ssidEndIndex + 1, 6).ByteArrToHexStr(), 16);
                hotspot.SignalIntensity = hotspots[ssidEndIndex + 7];
                list.Add(hotspot);
                hotspots = hotspots.Skip(ssidEndIndex + 8).ToArray();
            }
            body.HotSpots = list;
            return body;
        }

        private static Data0X18 Parse0X18(IList<byte> arr)
        {
            var body = new Data0X18();
            if (arr.Count == 0) return body;
            body.GPS = arr[0];
            if (arr.Count <= 1) return body;
            body.WiFi = arr[1];
            if (arr.Count <= 2) return body;
            body.CAN = arr[2];
            if (arr.Count <= 3) return body;
            body.POS = arr[3];
            if (arr.Count <= 4) return body;
            body.Coin = arr[4];
            if (arr.Count <= 5) return body;
            body.DVR = arr[5];
            if (arr.Count <= 6) return body;
            body.Sensor = arr[6];
            if (arr.Count <= 7) return body;
            body.RFID = arr[7];
            return body;
        }

        private static Data0X1A Parse0X1A(IList<byte> arr)
        {
            var body = new Data0X1A();
            body.Date = GetDateStr(arr.CloneRange(0, 3));
            body.Time = GetTimeStr(arr.CloneRange(3, 2));
            body.RecordCount = arr[5];
            var records = arr.CloneRange(6, arr.Count - 6);
            var list = new List<Record>();
            for (var i = 0; i < body.RecordCount; i++)
            {
                var record = new Record();
                record.Time = GetTimeStr(records.CloneRange(0, 3));
                record.Longitude = GetLongLatitude(records.CloneRange(3, 4));
                record.Latitude = GetLongLatitude(records.CloneRange(7, 4));
                record.InstantaneousVelocity = records[11];
                record.Azimuth = records[12];
                list.Add(record);
                records = records.Skip(13).ToArray();
            }
            body.Records = list;
            return body;
        }

        private static Data0X20 Parse0X20(IList<byte> arr)
        {
            var body = new Data0X20();
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            if (arr.Count <= 12) return body;
            body.VehicleStatus = arr[12];
            if (arr.Count <= 13) return body;
            body.Status = arr[13];
            return body;
        }

        private static Data0X252627 Parse0X252627(IList<byte> arr)
        {
            var body=new Data0X252627();
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            if (arr.Count <= 12) return body;
            body.VehicleStatus = arr[12];
            if (arr.Count <= 16) return body;
            body.WorkTime = Convert.ToUInt32(arr.CloneRange(13, 4).ByteArrToHexStr(), 16);
            body.SIMCardType = arr[20];
            if (arr.Count <= 21) return body;
            body.BaseLocationStatus = arr[21];

            var localeStrEndIndex = Array.IndexOf(arr.CloneRange(22, arr.Count - 22), (byte) 0) + 22;
            var cellIdStrEndIndex =
                Array.IndexOf(arr.CloneRange(localeStrEndIndex + 1, arr.Count - (localeStrEndIndex + 1)), (byte)0) +
                localeStrEndIndex + 1;
            body.BaseLocationLocale = MessageEncoding.GetString(arr.CloneRange(22, localeStrEndIndex - 22));
            body.BaseLocationCellId = MessageEncoding.GetString(arr.CloneRange(localeStrEndIndex + 1, cellIdStrEndIndex - (localeStrEndIndex + 1)));
            return body;
        }

        private static Data0X33 Parse0X33(IList<byte> arr)
        {
            var body=new Data0X33();
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            if (arr.Count <= 12) return body;
            body.VehicleStatus = arr[12];
            if (arr.Count <= 13) return body;
            body.ButtonInfo = arr[13];

            if (arr.Count <= 14) return body;
            body.DriverId = MessageEncoding.GetString(arr.Skip(14).ToArray());

            return body;
        }

        private static Data0X3A Parse0X3A(IList<byte> arr)
        {
            var body=new Data0X3A();
            if (arr.Count <= 0) return body;
            body.ImgId = arr[0];
            if (arr.Count <= 1) return body;
            body.CameraId = arr[1];
            if (arr.Count <= 3) return body;
            body.PageNum = Convert.ToUInt16(arr.CloneRange(2, 2).ByteArrToHexStr(), 16);
            if (arr.Count <= 5) return body;
            body.ImgDataLength = Convert.ToUInt16(arr.CloneRange(4, 2).ByteArrToHexStr(), 16);
            if (arr.Count <= 6) return body;
            body.XOrSum = arr[6];

            if (arr.Count <= 7) return body;
            body.ImgData = arr.Skip(7).ByteArrToHexStr();

            return body;
        }

        private static Data0X3B Parse0X3B(IList<byte> arr)
        {
            var body = new Data0X3B();
            if (arr.Count <= 0) return body;
            body.StatusCommand = arr[0];
            if (arr.Count <= 1) return body;
            body.CommandParam = arr[1];
            return body;
        }

        private static Data0X4041 Parse0X4041(IList<byte> arr)
        {
            var body = new Data0X4041();
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            body.VehicleStatus = arr[12];
            body.DirectionMark = arr[13];
            body.StationNum = arr[14];
            body.LineId = Convert.ToUInt32(arr.CloneRange(15, 3).ByteArrToHexStr(), 16);

            var lineNameEndIndex = Array.IndexOf(arr.CloneRange(18, arr.Count - 18), (byte)0) + 18;
            var driverIdEndIndex =
                Array.IndexOf(arr.CloneRange(lineNameEndIndex + 1, arr.Count - (lineNameEndIndex + 1)), (byte)0) +
                lineNameEndIndex + 1;
            body.LineName = MessageEncoding.GetString(arr.CloneRange(18, lineNameEndIndex - 18));
            body.DriverId = MessageEncoding.GetString(arr.CloneRange(lineNameEndIndex + 1, driverIdEndIndex - (lineNameEndIndex + 1)));

            body.ReportMode = arr[driverIdEndIndex + 1];
            return body;
        }

        private static Data0X42 Parse0X42(IList<byte> arr)
        {
            var body = new Data0X42();
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            if (arr.Count <= 12) return body;
            body.VehicleStatus = arr[12];

            if (arr.Count <= 13) return body;
            body.OverspeedMark = arr[13];
            var driverIdEndIndex = Array.IndexOf(arr.CloneRange(14, arr.Count - 14), (byte)0) + 14;
            body.DriverId = MessageEncoding.GetString(arr.CloneRange(14, driverIdEndIndex - 14));

            return body;
        }

        private static Data0X43 Parse0X43(IList<byte> arr)
        {
            var body = new Data0X43();
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            if (arr.Count <= 12) return body;
            body.VehicleStatus = arr[12];
            if (arr.Count <= 13) return body;
            body.OfflineMark = arr[13];

            var driverIdEndIndex = Array.IndexOf(arr.CloneRange(14, arr.Count - 14), (byte)0) + 14;
            body.DriverId = MessageEncoding.GetString(arr.CloneRange(14, driverIdEndIndex - 14));
            return body;
        }

        private static Data0X44 Parse0X44(IList<byte> arr)
        {
            var body=new Data0X44();
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            if (arr.Count <= 12) return body;
            body.VehicleStatus = arr[12];
            if (arr.Count <= 13) return body;
            body.AbnormalStatus = arr[13];

            var driverIdEndIndex = Array.IndexOf(arr.CloneRange(14, arr.Count - 14), (byte)0) + 14;
            body.DriverId = MessageEncoding.GetString(arr.CloneRange(14, driverIdEndIndex - 14));
            return body;
        }

        private static Data0X45 Parse0X45(IList<byte> arr)
        {
            var body = new Data0X45();
            body.Latitude = GetLongLatitude(arr.CloneRange(0, 4));
            body.Longitude = GetLongLatitude(arr.CloneRange(4, 4));
            body.InstantaneousVelocity = Convert.ToUInt16(arr.CloneRange(8, 2).ByteArrToHexStr(), 16);
            body.Azimuth = Convert.ToUInt16(arr.CloneRange(10, 2).ByteArrToHexStr(), 16);
            body.VehicleStatus = arr[12];
            body.DirectionMark = arr[13];
            body.StationNum = arr[14];

            body.DataType = arr[15];

            body.Data = arr.Skip(16).ByteArrToHexStr();

            return body;
        }

        private static Data0X47 Parse0X47(IList<byte> arr)
        {
            var body=new Data0X47();
            if (arr.Count <= 3) return body;
            body.MsgId = Convert.ToUInt32(arr.CloneRange(0, 4).ByteArrToHexStr(), 16);
            if (arr.Count <= 3) return body;
            body.ReturnCode = arr[4];
            return body;
        }

        private static Data0X48 Parse0X48(IList<byte> arr)
        {
            var body = new Data0X48();
            body.CardNum = MessageEncoding.GetString(arr.CloneRange(0, arr.Count));
            return body;
        }

        private static Data0X49 Parse0X49(IList<byte> arr)
        {
            var body = new Data0X49();
            var newLineNameEndIndex = Array.IndexOf(arr.CloneRange(0, arr.Count), (byte) 0);
            var oldLineNameEndIndex =
                Array.IndexOf(arr.CloneRange(newLineNameEndIndex + 4, arr.Count - (newLineNameEndIndex + 4)), (byte) 0) +
                newLineNameEndIndex + 4;

            body.NewLineName = MessageEncoding.GetString(arr.CloneRange(0, newLineNameEndIndex));
            body.NewLineId = Convert.ToUInt32(arr.CloneRange(newLineNameEndIndex + 1, 3).ByteArrToHexStr(), 16);

            body.OldLineName =
                MessageEncoding.GetString(arr.CloneRange(newLineNameEndIndex + 4,
                    oldLineNameEndIndex - (newLineNameEndIndex + 4)));
            body.OldLineId = Convert.ToUInt32(arr.CloneRange(oldLineNameEndIndex + 1, 3).ByteArrToHexStr(), 16);

            if (arr.Count <= oldLineNameEndIndex + 4) return body;
            body.Num = arr[oldLineNameEndIndex + 4];

            return body;
        }

        private static BaseData ParseBaseData(this byte[] arr,out int endIndex)
        {
            var vnEndIndex = Array.IndexOf(arr.CloneRange(10, 16), (byte)0) + 10;
            endIndex = vnEndIndex;
            var data = new BaseData();
            //data.BeginMark = Convert.ToUInt16(arr.CloneRange(0, 2).ByteArrToHexStr(), 16);
            data.DataLength = Convert.ToUInt16(arr.CloneRange(2, 2).ByteArrToHexStr(), 16);
            data.Version = arr[4];
            data.SerialNum1 = arr[5];
            data.WireStatus = arr[6];
            data.SerialNum2 = Convert.ToUInt16(arr.CloneRange(7, 2).ByteArrToHexStr(), 16);
            data.Status = arr[9];
            data.VehicleNum = MessageEncoding.GetString(arr.CloneRange(10, vnEndIndex - 10));
            data.Date = GetDateStr(arr.CloneRange(vnEndIndex + 1, 3));
            data.Time = GetTimeStr(arr.CloneRange(vnEndIndex + 4, 3));
            data.CommandCode = arr[vnEndIndex + 7];
            data.LineId = arr.CloneRange(arr.Length - 5, 3).ByteArrToInt();
            data.SubLineCode = arr[arr.Length - 2];
            data.CheckCode = arr[arr.Length - 1];
            return data;
        }

        private static string GetLongLatitude(IList<byte> arr)
        {
            return string.Format("{0}°{1}.{2}{3}", arr[0], arr[1], arr[2], arr[3]);
        }
        private static string GetDateStr(IList<byte> date)
        {
            return string.Format("20{0:d2}-{1:d2}-{2:d2}", date[0], date[1], date[2]);
        }
        private static string GetTimeStr(IList<byte> time)
        {
            return time.Count > 2
                ? string.Format("{0:d2}:{1:d2}:{2:d2}", time[0], time[1], time[2])
                : string.Format("{0:d2}:{1:d2}", time[0], time[1]);
        }
        private static string GetString(object obj)
        {
            var sb = new StringBuilder();
            if (obj != null)
            {
                var t = obj.GetType();
                var properties = t.GetProperties();
                foreach (var p in properties)
                {
                    var val = p.GetValue(obj, null);
                    var objs = p.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    var attr = objs.Length > 0 ? (DescriptionAttribute)objs[0] : null;
                    if (p.PropertyType == typeof(DateTime))
                    {
                        sb.AppendFormat("{0} => {1:yyyy-MM-dd HH:mm:ss},", attr != null ? attr.Description : p.Name,
                            Convert.ToDateTime(val));
                    }
                    else if (p.PropertyType.IsGenericType)
                    {
                        sb.AppendFormat("{0}=>,", attr != null ? attr.Description : p.Name);
                        var count = p.PropertyType.GetProperty("Count").GetValue(val, null);
                        for (var i = 0; i <(int) count; i++)
                        {
                            sb.AppendFormat("{0}、,", i + 1);
                            sb.AppendFormat(GetString(p.PropertyType.GetMethod("get_Item").Invoke(val, new object[] {i})));
                        }
                    }
                    else if (!p.PropertyType.IsPrimitive && p.PropertyType != typeof(string))
                    {
                        
                    }
                    else
                    {
                        sb.AppendFormat("{0} => {1},", attr != null ? attr.Description : p.Name, val);
                    }
                    sb.Append("\r\n");
                }
            }
            return sb.ToString();
        }
    }
}