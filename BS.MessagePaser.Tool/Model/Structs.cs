using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BS.MessageParser.Tool.Model
{
    public class Structs
    {

        #region 0x01 车辆业务和状态数据

        #region 0x0101:车辆gps数据(上行)
        /// <summary>
        /// 车辆gps数据结构(上行)
        /// </summary>
        public struct Struct0101
        {
            //public string LineName { get; set; }
            //public string VehicleNo { get; set; }
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 定位时间[14,time]
            /// </summary>
            public string GPSDateTime { get; set; }
            /// <summary>
            /// 发送时间[14,time]
            /// </summary>
            public string SendDateTime { get; set; }
            /// <summary>
            /// 经度[4,经纬度]
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 纬度[4,经纬度]
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 上下行:0-上；1-下
            /// </summary>
            public int ToDir { get; set; }
            /// <summary>
            /// 速度[2,unit16]KM/H，定位设置上传的行车速度，四舍五入
            /// </summary>
            public int Speed { get; set; }
            /// <summary>
            /// 海拔高度[2,unit16]单位M,四舍五入
            /// </summary>
            public int Height { get; set; }
            /// <summary>
            /// 方向角[2,unit16](方向0~359,单位为度（o），正北为0，顺时针)
            /// </summary>
            public int Angle { get; set; }
            /// <summary>
            /// 上一站级序号[2,unit16]
            /// </summary>
            public int PrevLevel { get; set; }
            /// <summary>
            /// 下一站级序号[2,unit16]
            /// </summary>
            public int NextLevel { get; set; }
            /// <summary>
            /// 距下一站距离[2,unit16],单位M
            /// </summary>
            public int NextStationMeter { get; set; }
            /// <summary>
            /// 营运/非营运状态[1,byte],11H:线路营运；12H:交通车；13H:特约车；41H:正常退出；42H:故障；43H:保养；44H:事故；45H:肇事；46H:加油；
            /// </summary>
            public int RunStatus { get; set; }
            /// <summary>
            /// 车辆状态[1,byte],8 bit,[0](是否熄火：0-开车；1-熄火);[7](是否缓存数据：0-实时数据;1-缓存数据)
            /// </summary>
            public int Status { get; set; }
            /// <summary>
            /// 超速标准[1,unit8],单位：公里/小时
            /// </summary>
            public int Overspeed { get; set; }

            /// <summary>
            /// 02经度
            /// </summary>
            public double Lon02 { get; set; }
            /// <summary>
            /// 02纬度
            /// </summary>
            public double Lat02 { get; set; }

            /// <summary>
            /// True: GPS时间非法
            /// </summary>
            public Boolean invalidGpsDT { get; set; }
        }
        #endregion

        #region 0x0102:到离站数据(上行)
        /// <summary>
        /// 到离站数据(上行)
        /// </summary>
        public struct Struct0102
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 数据来源[1,byte]:1-gps;2-wifi;3-lbs
            /// </summary>
            public int Source { get; set; }
            /// <summary>
            /// 进出站类型[1,byte]：0-到站;1-离站
            /// </summary>
            public int Arrive { get; set; }
            /// <summary>
            /// 时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 站级序号[2,unit16]
            /// </summary>
            public int Level { get; set; }
            /// <summary>
            /// 上下行[1,byte]:0-上；1-下
            /// </summary>
            public int ToDir { get; set; }
            /// <summary>
            /// 经度[4,经纬度]
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 纬度[4,经纬度]
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 方向角[2,unit16](方向0~359,单位为度（o），正北为0，顺时针)
            /// </summary>
            public int Angle { get; set; }
            /// <summary>
            /// 报站方式[1,byte]:0-自动报站；1-手工报站
            /// </summary>
            public int StopReportingType { get; set; }
        }
        #endregion

        #region 0x0103:WiFi数据(上行)
        /// <summary>
        /// wifi数据(上行)
        /// </summary>
        public struct Struct0103
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 发送时间[14,time]
            /// </summary>
            public string SendDateTime { get; set; }
            /// <summary>
            /// wifi热点个数[1,unit8]
            /// </summary>
            public int WiFiCount { get; set; }
            /// <summary>
            /// wifi数据
            /// </summary>
            public List<StructWiFiData> WiFiDatas { get; set; }
        }
        /// <summary>
        /// wifi信号
        /// </summary>
        public struct StructWiFiData
        {
            /// <summary>
            /// SSID[20,string]
            /// </summary>
            public string SSID { get; set; }
            /// <summary>
            /// WiFiID[6,bytes]
            /// </summary>
            public string WiFiID { get; set; }
            /// <summary>
            /// Strength[1,unit8]
            /// </summary>
            public int Strength { get; set; }
        }
        #endregion

        #region 0x0104:车辆状态数据(上行)
        /// <summary>
        /// 车辆状态数据(上行)
        /// </summary>
        public struct Struct0104
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 经度[4,经纬度]
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 纬度[4,经纬度]
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 速度[2,unit16]KM/H，定位设置上传的行车速度，四舍五入
            /// </summary>
            public int Speed { get; set; }
            /// <summary>
            /// 状态[4,unit32]32bit
            /// </summary>
            public int Status { get; set; }

            /// <summary>
            /// 02经度
            /// </summary>
            public double Lon02 { get; set; }
            /// <summary>
            /// 02纬度
            /// </summary>
            public double Lat02 { get; set; }
        }
        #endregion

        #region 0x0105:CAN总线数据(上行)
        /// <summary>
        /// CAN总线数据(上行)
        /// </summary>
        public struct Struct0105
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 经度[4,经纬度]
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 纬度[4,经纬度]
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 速度[2,unit16]KM/H，定位设置上传的行车速度，四舍五入
            /// </summary>
            public int GPSSpeed { get; set; }
            /// <summary>
            /// 发动机运行总时间[4,unit32] 计算公式：值*0.05
            /// </summary>
            public double EngineRunTime { get; set; }
            /// <summary>
            /// 里程[4,unit32]计算公式：值*5
            /// </summary>
            public int Mileage { get; set; }
            /// <summary>
            /// 总油耗[4,unit32]计算公式：值/2
            /// </summary>
            public double Total_Oil { get; set; }
            /// <summary>
            /// 油表[1,unit8] 计算公式：值*0.4
            /// </summary>
            public double Oil { get; set; }
            /// <summary>
            /// 水温[1,unit8]计算公式：值-40
            /// </summary>
            public int Water_Temperature { get; set; }
            /// <summary>
            /// 发动机转速[2,unit16]计算公式：值*0.125
            /// </summary>
            public double Engine_Speed { get; set; }
            /// <summary>
            /// 速度[2,unit16]计算公式：值/256
            /// </summary>
            public int Speed { get; set; }
            /// <summary>
            /// 手刹[1,byte]
            /// </summary>
            public byte shousha { get; set; }
            /// <summary>
            /// 手刹,假=(值&0x0c)==0x00	真=(值&0x0c)==0x04
            /// </summary>
            public int ShouSha { get; set; }
            /// <summary>
            /// 脚刹、巡航、离合[1,byte]
            /// </summary>
            public byte js_xh_lh { get; set; }
            /// <summary>
            /// 脚刹,假=(值&0x30)==0x00	真=(值&0x30)==0x10
            /// </summary>
            public int JiaoSha { get; set; }
            /// <summary>
            /// 巡航,假=(值&0x03)==0x00	真=(值&0x03)==0x01
            /// </summary>
            public int XunHang { get; set; }
            /// <summary>
            /// 离合,假=(值&0xc0)==0x00	真=(值&0xc0)==0x40
            /// </summary>
            public int LiHe { get; set; }


            /// <summary>
            /// 02经度
            /// </summary>
            public double Lon02 { get; set; }
            /// <summary>
            /// 02纬度
            /// </summary>
            public double Lat02 { get; set; }
        }
        #endregion

        #region 0x0106:外设自检状态数据(上行)
        /// <summary>
        /// CAN总线数据(上行)
        /// </summary>
        public struct Struct0106
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// GPS[1,hex],=00H：未连接；=01H：已定位；	=EEH：未定位；
            /// </summary>
            public int GPS { get; set; }
            /// <summary>
            /// WiFi[1,hex],=00H：未连接；=01H：已连接
            /// </summary>
            public int WiFi { get; set; }
            /// <summary>
            /// CAN[1,hex],=00H：未连接；=01H：已连接
            /// </summary>
            public int CAN { get; set; }
            /// <summary>
            /// POS机[1,hex],=00H：未连接；=01H：已连接
            /// </summary>
            public int POS { get; set; }
            /// <summary>
            /// ET(投币机)[1,hex],=00H：未连接；=01H：已连接
            /// </summary>
            public int ET { get; set; }
            /// <summary>
            /// DVR[1,hex],=00H：未连接；=01H：已连接
            /// </summary>
            public int DVR { get; set; }
            /// <summary>
            /// 温度传感器(JWC)[1,hex],=00H：未连接；=01H：已连接
            /// </summary>
            public int JWC { get; set; }
            /// <summary>
            /// RFID（无线射频识别）[1,hex],=00H：未连接；=01H：已连接
            /// </summary>
            public int RFID { get; set; }
        }
        #endregion

        #region 0x0107:超级电车数据(上行)
        /// <summary>
        /// 超级电车数据(上行)
        /// </summary>
        public struct Struct0107
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 累计行驶里程[4,unit32],偏移:0Km		范围:0~9999999.99Km
            /// </summary>
            public double TotalMileage { get; set; }
            /// <summary>
            /// 电池组充放电电流[2,unit16],偏移:1000A		范围:-1000~1000A
            /// </summary>
            public double Current { get; set; }
            /// <summary>
            /// 电池组总电压[2,unit16],偏移:0V			范围:0~1000V
            /// </summary>
            public double Voltage { get; set; }
            /// <summary>
            /// 电池单体电压压差[2,unit16],偏移:0V			范围:0~6V
            /// </summary>
            public double VoltageDifference { get; set; }
            /// <summary>
            /// 电池组平均温度[1,unit8],偏移:-40℃		范围:-40~210℃
            /// </summary>
            public double MeanTemperature { get; set; }
            /// <summary>
            /// 电池组SOC[1,unit8],偏移:0%			范围:0~100%
            /// </summary>
            public double SOC { get; set; }
            /// <summary>
            /// 电池组允许最高温度[1,unit8],偏移:-40℃		范围:-40~210℃
            /// </summary>
            public double AllowMaxTemperature { get; set; }
            /// <summary>
            /// 车速信号[1,unit8],偏移:0Km/h		范围:0~250Km/h
            /// </summary>
            public double Speed { get; set; }
            /// <summary>
            /// 极大值温度[1,unit8],偏移:-40℃		范围:-40~210℃
            /// </summary>
            public double MaxTemperature { get; set; }
            /// <summary>
            /// 极大值温度所在箱号[1,unit8],偏移：0			范围：1～16	
            /// </summary>
            public int MaxTBoxNo { get; set; }
            /// <summary>
            /// 电池温差[1,unit8],偏移:0℃		范围:0~250℃
            /// </summary>
            public double TemperatureDifference { get; set; }
            /// <summary>
            /// 空调温度[1,unit8],偏移:-30℃		范围:-30~97℃
            /// </summary>
            public double AirCondition { get; set; }
        }
        #endregion

        #region 0x0108:新能源车CAN(上行)
        /// <summary>
        /// 新能源车CAN(上行)
        /// </summary>
        public struct Struct0108
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 经度[4,经纬度]
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 纬度[4,经纬度]
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 速度[2,unit16]KM/H，定位设置上传的行车速度，四舍五入
            /// </summary>
            public int Speed { get; set; }
            /// <summary>
            /// 是否报警数据[1,byte]:00-正常；01-报警数据；FF-无效
            /// </summary>
            public string IsAlertData { get; set; }
            /// <summary>
            /// 报文条数[1,byte]
            /// </summary>
            public int RecordCount { get; set; }
            /// <summary>
            /// PGN数据
            /// </summary>
            public List<StructPGNData> Datas { get; set; }
        }
        // PGN数据结构体
        public struct StructPGNData
        {
            /// <summary>
            /// PGN编号[2,bytes]
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// PGN数据[8,bytes]
            /// </summary>
            public string Data { get; set; }
        }
        #endregion

        #endregion

        #region 0x02 基础管理数据

        #region 0x0201:司机POS机刷卡数据(上行)
        /// <summary>
        /// 司机POS数卡数据(上行)
        /// </summary>
        public struct Struct0201
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 刷卡记录数[1,byte]
            /// </summary>
            public int Count { get; set; }
            /// <summary>
            /// 产生记录时间[6,BCD]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 司售卡的UID号[4,bytes]
            /// </summary>
            public long UID { get; set; }
            /// <summary>
            /// 发行日期[4,BCD]
            /// </summary>
            public string IssueDate { get; set; }
            /// <summary>
            /// 发行流水号[4,BCD]
            /// </summary>
            public string IssueNum { get; set; }
            /// <summary>
            /// 有效日期[4,BCD]
            /// </summary>
            public string ExpiryDate { get; set; }
            /// <summary>
            /// 工种[2,bytes]
            /// </summary>
            public int TypeOfWork { get; set; }
            /// <summary>
            /// 发卡方编码[3,bytes]
            /// </summary>
            public string IssuerCode { get; set; }
            /// <summary>
            /// 集团代码[2,bytes]
            /// </summary>
            public string GroupCode { get; set; }
            /// <summary>
            /// 公司编码[2,bytes]
            /// </summary>
            public string CropCode { get; set; }
            /// <summary>
            /// 线路编码[2,bytes]
            /// </summary>
            public string LineCode { get; set; }
            /// <summary>
            /// 车队编码[2,bytes]
            /// </summary>
            public string TeamCode { get; set; }
            /// <summary>
            /// 员工编号[4,bytes]
            /// </summary>
            public string EmployeeCode { get; set; }
            /// <summary>
            /// 签到签退[1,byte]：1-签到;2-签退
            /// </summary>
            public int SignIn { get; set; }
            /// <summary>
            /// 生产厂商[1,byte]
            /// </summary>
            public string Manufacturer { get; set; }
            /// <summary>
            /// 设备编号[4,BCD]
            /// </summary>
            public string EquipmentCode { get; set; }
            /// <summary>
            /// 保留字段[4,bytes]
            /// </summary>
            public string Reserv { get; set; }

            //zyh add 140408
            /// <summary>
            /// true :数据非法
            /// </summary>
            public Boolean isInvaildData { get; set; }
            /// <summary>
            /// 非法数据信息
            /// </summary>
            public string InvaildMsg { get; set; }



        }
        #endregion

        #region 0x0202:DVR视频连接和断开(下行)
        /// <summary>
        /// DVR视频连接和断开(下行)
        /// </summary>
        public struct Struct0202
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 发送时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 视频类型[1,byte],0-四合一视频；1-设备编号1；；2-设备编号2；3-设备编号3；4-设备编号4
            /// </summary>
            public int VedioType { get; set; }
            /// <summary>
            /// 请求类型[1,byte],1-连接；2-断开
            /// </summary>
            public int RequestType { get; set; }
        }
        #endregion

        #region 0x0203:DVR视频数据包(上行)
        /// <summary>
        /// DVR视频数据包(上行)
        /// </summary>
        public struct Struct0203
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 发送时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 视频类型[1,byte],0-四合一视频；1-设备编号1；；2-设备编号2；3-设备编号3；4-设备编号4
            /// </summary>
            public int VedioType { get; set; }
            /// <summary>
            /// 模式[1,byte],1-推送；2-抓取
            /// </summary>
            public int Model { get; set; }
            /// <summary>
            /// 视频流序列号[4,unit32],视频数据包的序列号
            /// </summary>
            public int VedioStreamSN { get; set; }
            /// <summary>
            /// 视频流[无限制,bytes],格式H264
            /// </summary>
            public string VedioStream { get; set; }
        }
        #endregion

        #region 0x0204:语音通话连接(上行)
        /// <summary>
        /// 语音通话连接(上行)
        /// </summary>
        public struct Struct0204
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
        }
        #endregion

        #region 0x0206:图片抓拍指令(下行)
        /// <summary>
        /// 图片抓拍指令(下行)
        /// </summary>
        public struct Struct0206
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 是否打开车灯[1,byte],0-不打开；其他-打开
            /// </summary>
            public int CarLight { get; set; }
            /// <summary>
            /// 摄像头编号[1,byte],1-1号；；2-2号；3-3号；4-4号；...
            /// </summary>
            public int CameraNo { get; set; }
            /// <summary>
            /// 图像分辨率[1,byte],1-9,分辨率从小到大
            /// </summary>
            public int ResolutionRate { get; set; }
        }
        #endregion

        #region 0x0207:图片抓拍应答(上行)
        /// <summary>
        /// 图片抓拍应答(上行)
        /// </summary>
        public struct Struct0207
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 应答[1,byte],0-失败；1-成功
            /// </summary>
            public int Result { get; set; }
            /// <summary>
            /// 错误原因[50,string]
            /// </summary>
            public string FailReason { get; set; }
        }
        #endregion

        #region 0x0208:客卡POS刷卡统计信息(上行)
        /// <summary>
        /// 乘客POS刷卡统计信息(上行)
        /// </summary>
        public struct Struct0208
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 发送时间[14,time]
            /// </summary>
            public string SendDateTime { get; set; }
            /// <summary>
            /// 上下行[1,byte]
            /// </summary>
            public int UpDown { get; set; }
            /// <summary>
            /// 站点序号[2,unit16]
            /// </summary>
            public int StationLevel { get; set; }
            /// <summary>
            /// 本站普通卡刷卡次数[1,hex]
            /// </summary>
            public int CommonCardTimes { get; set; }
            /// <summary>
            /// 本站普通卡刷卡金额[4,BCD]
            /// </summary>
            public double CommonCardMoney { get; set; }
            /// <summary>
            /// 本站换乘优惠卡刷卡次数[1,hex]
            /// </summary>
            public int PreferenceCardTimes { get; set; }
            /// <summary>
            /// 本站换乘优惠卡刷卡金额[4,BCD]
            /// </summary>
            public double PreferenceCardMoney { get; set; }
            /// <summary>
            /// 本站老年人卡刷卡次数[1,hex]
            /// </summary>
            public int EldelyCardTimes { get; set; }
            /// <summary>
            /// 本站老年人卡刷卡金额[4,BCD]
            /// </summary>
            public double EldelyCardMoney { get; set; }
            /// <summary>
            /// 本站员工卡刷卡次数[1,hex]
            /// </summary>
            public int EmployeeCardTimes { get; set; }
            /// <summary>
            /// 本站员工卡刷卡金额[4,BCD]
            /// </summary>
            public double EmployeeCardMoney { get; set; }
            /// <summary>
            /// 本站学生卡刷卡次数[1,hex]
            /// </summary>
            public int PupilCardTimes { get; set; }
            /// <summary>
            /// 本站学生卡刷卡金额[4,BCD]
            /// </summary>
            public double PupilCardMoney { get; set; }
            /// <summary>
            /// 本站临时卡刷卡次数[1,hex]
            /// </summary>
            public int TempCardTimes { get; set; }
            /// <summary>
            /// 本站临时卡刷卡金额[4,BCD]
            /// </summary>
            public double TempCardMoney { get; set; }
            //保留字段(保留2种卡类型)[10,bytes]
            public string KeepType { get; set; }
            /// <summary>
            /// 本站累计刷卡次数[2,hex]
            /// </summary>
            public int SumCardTimes { get; set; }
            /// <summary>
            /// 本站累计刷卡金额[4,BCD]
            /// </summary>
            public double SumCardMoney { get; set; }
            /// <summary>
            /// 总共累计刷卡次数[4,hex]
            /// </summary>
            public int TotalCardTimes { get; set; }
            /// <summary>
            /// 总共累计刷卡金额[4,BCD]
            /// </summary>
            public double TotalCardMoney { get; set; }
            /// <summary>
            /// 当前司售人员发行流水号[4,BCD]
            /// </summary>
            public string DriverCardNo { get; set; }
            /// <summary>
            /// 保留字段[16,hex]
            /// </summary>
            public string Extra { get; set; }
        }
        #endregion

        #region 0x0209:电子票箱统计信息(上行)
        /// <summary>
        /// 电子票箱统计信息(上行)
        /// </summary>
        public struct Struct0209
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 发送时间[14,time]
            /// </summary>
            public string SendDateTime { get; set; }
            /// <summary>
            /// 上下行[1,byte]
            /// </summary>
            public int UpDown { get; set; }
            /// <summary>
            /// 站点序号[2,unit16]
            /// </summary>
            public int StationLevel { get; set; }
            /// <summary>
            /// 生产厂商[1,byte]
            /// </summary>
            public string Manufacturer { get; set; }
            /// <summary>
            /// 设备编号[4,unit32]
            /// </summary>
            public string EquipmentNo { get; set; }
            /// <summary>
            /// 本站硬币金额[2,unit16]
            /// </summary>
            public double CoinAmount { get; set; }
            /// <summary>
            /// 本站纸币金额[2,unit16]
            /// </summary>
            public double PaperAmount { get; set; }
            /// <summary>
            /// 未识别面额纸币张数[2,unit16]
            /// </summary>
            public int PaperUnknownCount { get; set; }
            /// <summary>
            /// 累计硬币金额[4,unit32]
            /// </summary>
            public double TotalCoinAmount { get; set; }
            /// <summary>
            /// 累计纸币金额[4,unit32]
            /// </summary>
            public double TotalPaperAmount { get; set; }
            /// <summary>
            /// 累计未识别面额纸币张数[4,unit32]
            /// </summary>
            public int TotalPaperUnknown { get; set; }
            /// <summary>
            /// 智能投币机状态[1,8 bit]
            /// </summary>
            public int Status { get; set; }
        }
        #endregion

        #region 0x0210:员工刷卡数据(上行)
        /// <summary>
        /// 员工刷卡数据(上行)
        /// </summary>
        public struct Struct0210
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 刷卡时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 员工卡序列号[10,string]
            /// </summary>
            public string CardId { get; set; }

            /// <summary>
            /// 员工号
            /// </summary>
            public string EmpNo { get; set; }
            /// <summary>
            /// 员工姓名
            /// </summary>
            public string EmpName { get; set; }
        }
        #endregion

        #region 0x0211:员工刷卡应答(下行)
        /// <summary>
        /// 员工刷卡应答(下行)
        /// </summary>
        public struct Struct0211
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 卡号[10,string],员工卡序列号
            /// </summary>
            public string CardId { get; set; }
            /// <summary>
            /// 员工号[10,string]，系统员工号
            /// </summary>
            public string EmpNo { get; set; }
            /// <summary>
            /// 姓名[10,string]
            /// </summary>
            public string Name { get; set; }
        }
        #endregion

        #region 0x0212:图片数据包(上行)
        /// <summary>
        /// 图片数据包(上行)
        /// </summary>
        public struct Struct0212
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 图片编号[1,byte]
            /// </summary>
            public int ImageNo { get; set; }
            /// <summary>
            /// 摄像头编号[1,byte],1-1号；；2-2号；3-3号；4-4号；...
            /// </summary>
            public int CameraNo { get; set; }
            /// <summary>
            /// 页码[2,unit16],每页按256字节算
            /// </summary>
            public int PageCount { get; set; }
            /// <summary>
            /// 图像数据长度[2,unit16],范围：≤768,长度为255时,=0x00FF
            /// </summary>
            public int Lenght { get; set; }
            /// <summary>
            /// 图像数据异或和[1,byte],图像数据所有字节的异或和
            /// </summary>
            public int CRC { get; set; }
            /// <summary>
            /// 图像数据[可变,hex]
            /// </summary>
            public string Content { get; set; }
        }
        #endregion

        #region 0x0213:图像模块状态指令(上行)
        /// <summary>
        /// 图像模块状态指令(上行)
        /// </summary>
        public struct Struct0213
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 状态指令[1,byte]，
            /// 0x90:视频数据结束标记
            /// 0x91:意外或者强行终止
            /// 0xA0:无视频信号输入
            /// 0xB0:编码器故障
            /// 0xC0:与模块通信超时
            /// 0xDn:n=摄像头个数
            /// 0xEE:指令参数错误
            /// 0xF0:报警拍照开始
            /// </summary>
            public string Cmd { get; set; }
            /// <summary>
            /// 指令参数[1,byte]
            /// 其它指令时无意义;
            /// 指令为0xF0时，表示设备网络制式：
            /// 0x01:WIFI
            /// 0x02:2G
            /// 0x03:3G
            /// 0x04:4G
            /// 0x05:5G
            /// </summary>
            public string CmdArg { get; set; }

        }
        #endregion

        #region 0x0214:设定报警默认摄像头编号(下行)
        /// <summary>
        /// 设定报警默认摄像头编号(下行)
        /// </summary>
        public struct Struct0214
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 摄像头编号[1,byte]
            /// 0x01:摄像头1
            /// 0x02:摄像头2
            /// 0x03:摄像头3
            /// 0x04:摄像头4
            /// 0x05:摄像头5
            /// 0x06:摄像头6
            /// 0x07:摄像头7
            /// 0x08:摄像头8
            /// </summary>
            public string CameraNo { get; set; }
        }
        #endregion

        #region 0x0215:设定报警默认摄像头编号应答(上行)
        /// <summary>
        /// 设定报警默认摄像头编号应答(上行)
        /// </summary>
        public struct Struct0215
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 设置结果[1,byte],0-失败；1-成功
            /// </summary>
            public int Result { get; set; }
            /// <summary>
            /// 错误原因[50,string]
            /// </summary>
            public string FailReason { get; set; }
        }
        #endregion

        #region 0x0216:客流计信息(上行)
        /// <summary>
        /// 客流计信息(上行)
        /// </summary>
        public struct Struct0216
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路ID[4,BCD]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 发送时间[14,time]
            /// </summary>
            public string SendDateTime { get; set; }
            /// <summary>
            /// 上下行[1,byte]0-上；1-下
            /// </summary>
            public int ToDir { get; set; }
            /// <summary>
            /// 站级序号[2,unit16]
            /// </summary>
            public int Level { get; set; }
            /// <summary>
            /// 前门上客数[1,byte]0xFF 无效
            /// </summary>
            public int FrontDoorUp { get; set; }
            /// <summary>
            /// 门下客数[1,byte]0xFF 无效
            /// </summary>
            public int FrontDoorDown { get; set; }
            /// <summary>
            /// 中门上客数[1,byte]0xFF 无效
            /// </summary>
            public int MiddleDoorUp { get; set; }
            /// <summary>
            /// 中门下客数[1,byte]0xFF 无效
            /// </summary>
            public int MiddleDoorDown { get; set; }
            /// <summary>
            /// 后门上客数[1,byte]0xFF 无效
            /// </summary>
            public int BackDoorUp { get; set; }
            /// <summary>
            /// 后门下客数[1,byte]0xFF 无效
            /// </summary>
            public int BackDoorDown { get; set; }
            /// <summary>
            /// 前门上客数[4,uint32]0xFF 无效
            /// </summary>
            public long TotalFrontDoorUp { get; set; }
            /// <summary>
            /// 门下客数[4,uint32]0xFF 无效
            /// </summary>
            public long TotalFrontDoorDown { get; set; }
            /// <summary>
            /// 中门上客数[4,uint32]0xFF 无效
            /// </summary>
            public long TotalMiddleDoorUp { get; set; }
            /// <summary>
            /// 中门下客数[4,uint32]0xFF 无效
            /// </summary>
            public long TotalMiddleDoorDown { get; set; }
            /// <summary>
            /// 后门上客数[4,uint32]0xFF 无效
            /// </summary>
            public long TotalBackDoorUp { get; set; }
            /// <summary>
            /// 后门下客数[4,uint32]0xFF 无效
            /// </summary>
            public long TotalBackDoorDown { get; set; }
            /// <summary>
            /// 保留[21,bytes]默认0x00
            /// </summary>
            public string Reserv { get; set; }
        }
        #endregion

        #endregion

        #region 0x03 系统级指令

        #region 0x0301:GPS终端设备信息（上行)
        /// <summary>
        /// GPS终端设备信息(上行)
        /// </summary>
        public struct Struct0301
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 上传时间[14,time]
            /// </summary>
            public string SendDateTime { get; set; }
            /// <summary>
            /// 通讯软件版本[可变,VString]
            /// </summary>
            public string SoftVersion { get; set; }
            /// <summary>
            /// 设备序列号[可变,VString]
            /// </summary>
            public string EquipmentNo { get; set; }
            /// <summary>
            /// 线路名[4,unit32]
            /// </summary>
            public string LineName { get; set; }
            /// <summary>
            /// 线路ID[3,BCD]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 车牌号码[可变,VString]
            /// </summary>
            public string VehicleNo { get; set; }
            /// <summary>
            /// SIM卡ICCID号码[可变,VString]
            /// </summary>
            public string ICCID { get; set; }
            /// <summary>
            /// 设备厂商[1,char]
            /// </summary>
            public string Manufacturer { get; set; }
        }
        #endregion

        #region 0x0302:GPS终端登录应答(下行)
        /// <summary>
        /// GPS终端登录应答(下行)
        /// </summary>
        public struct Struct0302
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 登录结果[1,byte],1-成功;0-失败
            /// </summary>
            public int Result { get; set; }
        }
        #endregion

        #region 0x0303:GPS终端在线检测(心跳)(下行)
        /// <summary>
        /// GPS终端在线检测(心跳)(下行)
        /// </summary>
        public struct Struct0303
        {
        }
        #endregion

        #region 0x0304:设置GPS终端发送频率(下行)
        /// <summary>
        /// 设置GPS终端发送频率(下行)
        /// </summary>
        public struct Struct0304
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// GPS发送频率[2,unit],单位秒
            /// </summary>
            public int Interval { get; set; }
        }
        #endregion

        #region 0x0305:设置发送频率应答(上行)
        /// <summary>
        /// 设置发送频率应答(上行)
        /// </summary>
        public struct Struct0305
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 设置结果[1,byte],1-成功;0-失败
            /// </summary>
            public int Result { get; set; }
        }
        #endregion

        #region 0x0306:查询GPS终端上传频率(下行)
        /// <summary>
        /// 查询GPS终端上传频率(下行)
        /// </summary>
        public struct Struct0306
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
        }
        #endregion

        #region 0x0307:查询GPS上传频率应答(上行)
        /// <summary>
        /// 查询GPS上传频率应答(上行)
        /// </summary>
        public struct Struct0307
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// GPS发送频率[2,unit],单位秒
            /// </summary>
            public int Interval { get; set; }
        }
        #endregion

        #region 0x0308:设置公交线路(下行)(2.0及之前版本)
        /// <summary>
        /// 设置公交线路(下行)
        /// </summary>
        public struct Struct0308_old
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 上行站点数[2,unit]，（站点信息共28*N1字节，紧接着下行站点数之后）
            /// </summary>
            public int UpCount { get; set; }
            /// <summary>
            /// 下行站点数[2,unit]，（站点信息共28*N2字节，紧接着上行站点信息之后）
            /// </summary>
            public int DownCount { get; set; }
            /// <summary>
            /// 上行站点信息列表
            /// </summary>
            public List<StructStation> UpStations { get; set; }
            /// <summary>
            /// 下行站点信息列表
            /// </summary>
            public List<StructStation> DownStations { get; set; }
        }

        /// <summary>
        /// 站点信息
        /// </summary>
        public struct StructStation
        {
            /// <summary>
            /// 经度[4,经纬度]
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 纬度[4,经纬度]
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 站点名称[20,string]
            /// </summary>
            public string StationName { get; set; }
        }
        #endregion

        #region 0308(2.1版本)
        /// <summary>
        /// 手动切换线路(上行)
        /// </summary>
        public struct Struct0308
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 新线路ID[4,BCD]
            /// </summary>
            public string NewLineId { get; set; }
            /// <summary>
            /// 旧线路ID[4,BCD]
            /// </summary>
            public string OldLineId { get; set; }
            /// <summary>
            /// 报站语音序号[1,Unit8]
            /// </summary>
            public int VoiceNo { get; set; }

            public string NewLineName { get; set; }
            public string OldLineName { get; set; }
        }
        #endregion

        #region 0x0309:设置公交线路应答(上行)
        /// <summary>
        /// 设置公交线路应答(上行)
        /// </summary>
        public struct Struct0309
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 设置结果[1,byte],1-成功;0-失败
            /// </summary>
            public int Result { get; set; }
        }
        #endregion

        #region 0x030A:设置运营线路(下行)
        /// <summary>
        /// 设置运营线路(下行)
        /// </summary>
        public struct Struct030A
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 设置营运线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 报站语音序号[1,Unit8]
            /// </summary>
            public int VoiceNo { get; set; }
            /// <summary>
            ///子线路编码[1,Unit8]
            /// </summary>
            public int SubLineCode { get; set; }
            /// <summary>
            /// 报站类型[1,Unit8]
            /// </summary>
            public int ReportType { get; set; }
            /// <summary>
            /// 上下行[1,Unit8]
            /// </summary>
            public int UpDown { get; set; }
            /// <summary>
            /// 报站掩码[16,bytes]
            /// </summary>
            public string ReportCode { get; set; }
        }
        #endregion

        #region 0x030B:设置运营线路应答(上行)
        /// <summary>
        /// 设置运营线路应答(上行)
        /// </summary>
        public struct Struct030B
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 设置结果[1,byte],0-失败；1-成功
            /// </summary>
            public int Result { get; set; }
            /// <summary>
            /// 错误原因[50,string]
            /// </summary>
            public string FailReason { get; set; }
        }
        #endregion

        #region 0x030C:查询运营线路(下行)
        /// <summary>
        /// 查询运营线路(下行)
        /// </summary>
        public struct Struct030C
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
        }
        #endregion

        #region 0x030D:查询运营线路应答(上行)
        /// <summary>
        /// 查询运营线路应答(上行)
        /// </summary>
        public struct Struct030D
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 当前营运线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
        }
        #endregion

        #region 0x030E:重启(下行)
        /// <summary>
        /// 重启(下行)
        /// </summary>
        public struct Struct030E
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
        }
        #endregion

        #region 0x030F:重启应答(上行)
        /// <summary>
        /// 重启应答(上行)
        /// </summary>
        public struct Struct030F
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 应答结果[1,byte],0-无法重启；1-开始重启
            /// </summary>
            public int Result { get; set; }
            /// <summary>
            /// 错误原因[50,string]
            /// </summary>
            public string FailReason { get; set; }
        }
        #endregion

        #region 0x0310:TTS服务(下行)
        /// <summary>
        /// TTS服务(下行)
        /// </summary>
        public struct Struct0310
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 文本内容[256,string],语音播报内容
            /// </summary>
            public string Content { get; set; }
            /// <summary>
            /// 输出类型[1,byte],1-语音通知司机；2-语音通知乘客；3-显示屏显示文字
            /// </summary>
            public int OutputType { get; set; }
        }
        #endregion

        #region 0x0311:TTS服务应答(上行)
        /// <summary>
        /// TTS服务应答(上行)
        /// </summary>
        public struct Struct0311
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 应答[1,byte],0-TTS服务失败；1-TTS服务成功
            /// </summary>
            public int Result { get; set; }
        }
        #endregion

        #region 0x0312:GPS终端软件升级(下行)
        /// <summary>
        /// GPS终端软件升级(下行)
        /// </summary>
        public struct Struct0312
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 升级类型[1,byte],1-主机升级；2-显示屏升级
            /// </summary>
            public int UpgradeType { get; set; }
            /// <summary>
            /// 升级文件地址[256,string]
            /// </summary>
            public string FileAddress { get; set; }
        }
        #endregion

        #region 0x0313:GPS终端软件升级应答(上行)
        /// <summary>
        /// GPS终端软件升级应答(上行)
        /// </summary>
        public struct Struct0313
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 升级应答[1,byte],0-无法升级；1-开始升级
            /// </summary>
            public int Result { get; set; }
        }
        #endregion

        #region 0x0314:手动报警(上行)
        /// <summary>
        /// 手动报警(上行)
        /// </summary>
        public struct Struct0314
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 经度[4,经纬度]
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 纬度[4,经纬度]
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 速度[2,unit16],km/h 定位设备上传的行车速度，四舍五入
            /// </summary>
            public int Speed { get; set; }
            /// <summary>
            /// 报警代码[2,unit16]
            /// </summary>
            public int AlertCode { get; set; }

            /// <summary>
            /// 02经度
            /// </summary>
            public double Lon02 { get; set; }
            /// <summary>
            /// 02纬度
            /// </summary>
            public double Lat02 { get; set; }
        }
        #endregion

        #region 0x0315:设定平台IP和PORT(下行)
        /// <summary>
        /// 设定平台IP和PORT(下行)
        /// </summary>
        public struct Struct0315
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 平台IP[4,unit32]
            /// </summary>
            public string IP { get; set; }
            /// <summary>
            /// 平台Port[2,unit16]
            /// </summary>
            public int Port { get; set; }
        }
        #endregion

        #region 0x0316:设定平台IP和PORT应答(上行)
        /// <summary>
        /// 设定平台IP和PORT应答(上行)
        /// </summary>
        public struct Struct0316
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 设置应答[1,byte],0-设置失败；1-设置成功
            /// </summary>
            public int Result { get; set; }
        }
        #endregion

        #region 0x0317:实时计划(下行)
        /// <summary>
        /// 实时计划(下行)
        /// </summary>
        public struct Struct0317
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 车辆编号[20,string]
            /// </summary>
            public string VehicleNumber { get; set; }
            /// <summary>
            /// 完成班次数[1,byte]
            /// </summary>
            public int CompleteBC { get; set; }
            /// <summary>
            /// 计划班次数[1,byte]
            /// </summary>
            public int PlanBC { get; set; }
            /// <summary>
            /// 发车时间[2,bytes]，HHmm
            /// </summary>
            public string FaCheTime { get; set; }/// <summary>
            /// 完成班次更新时间[14,Time]
            /// </summary>
            public string UpdateTime { get; set; }
        }
        #endregion

        #region 0x0318:实时计划应答(上行)
        /// <summary>
        /// 实时计划应答(上行)
        /// </summary>
        public struct Struct0318
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 设置应答[1,byte],0-失败；1-成功
            /// </summary>
            public int Result { get; set; }
            /// <summary>
            /// 错误原因[50,string]
            /// </summary>
            public string FailReason { get; set; }
        }
        #endregion

        #region 0x0319:全部计划(下行)
        /// <summary>
        /// 全部计划(下行)
        /// </summary>
        public struct Struct0319
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 路牌[4,string]
            /// </summary>
            public string LuPai { get; set; }
            /// <summary>
            /// 班次总数[1,unit8]
            /// </summary>
            public int BanCiCount { get; set; }
            /// <summary>
            /// 班次详细列表
            /// </summary>
            public List<StructBanCi> BanCiList { get; set; }
        }

        /// <summary>
        /// 班次信息
        /// </summary>
        public struct StructBanCi
        {
            /// <summary>
            /// 班次编号[20,string]
            /// </summary>
            public string BanCiNo { get; set; }
            /// <summary>
            /// 上行站点数[2,unit]，（站点信息共28*N1字节，紧接着下行站点数之后）
            /// </summary>
            public int UpCount { get; set; }
            /// <summary>
            /// 发车时间[2,bytes]，HHmm
            /// </summary>
            public string FaCheTime { get; set; }
            /// <summary>
            /// 完成时间[2,bytes]，HHmm
            /// </summary>
            public string DaoDaTime { get; set; }
        }
        #endregion

        #region 0x0320:全部计划应答(上行)
        /// <summary>
        /// 全部计划应答(上行)
        /// </summary>
        public struct Struct0320
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 设置应答[1,byte],0-失败；1-成功
            /// </summary>
            public int Result { get; set; }
            /// <summary>
            /// 错误原因[50,string]
            /// </summary>
            public string FailReason { get; set; }
        }
        #endregion

        #region 0x0321:司机加入/退出营运(上行)
        /// <summary>
        /// 司机加入/退出营运(上行)
        /// </summary>
        public struct Struct0321
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 时间[14,time]
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 经度[4,经纬度]
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 纬度[4,经纬度]
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 速度[2,unit16],km/h 定位设备上传的行车速度，四舍五入
            /// </summary>
            public int Speed { get; set; }
            /// <summary>
            /// 加入/退出营运[1,byte]：11H:线路营运；12H:交通车；13H:特约车；41H:正常退出；42H:故障；43H:保养；44H:事故；45H:肇事；46H:加油；
            /// </summary>
            public int InOut { get; set; }

            /// <summary>
            /// 02经度
            /// </summary>
            public double Lon02 { get; set; }
            /// <summary>
            /// 02纬度
            /// </summary>
            public double Lat02 { get; set; }
        }
        #endregion

        #region 0x0322:平台加入/退出营运(下行)
        /// <summary>
        /// 平台加入/退出营运(下行)
        /// </summary>
        public struct Struct0322
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            ///// <summary>
            ///// 加入/退出营运[1,byte],0-加入；1-退出
            ///// </summary>
            //public int InOut { get; set; }
            ///// <summary>
            ///// 确认/取消[1,byte],0-确认；1-取消
            ///// </summary>
            //public int Ok { get; set; }
            /// <summary>
            /// 加入/退出模式[1,byte],01H=线路营运； 81H=正常退出；02H=交通车；82H=故障；03H=特约车；83H=保养；84H=事故；85H=肇事
            /// </summary>
            public string Mode { get; set; }
        }
        #endregion

        #region 0x0323:平台加入/退出营运应答(上行)
        /// <summary>
        /// 平台加入/退出营运应答(上行)
        /// </summary>
        public struct Struct0323
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 设置应答[1,byte],0-失败；1-成功
            /// </summary>
            public int Result { get; set; }
            /// <summary>
            /// 错误原因[50,string]
            /// </summary>
            public string FailReason { get; set; }
        }
        #endregion

        #region 0x0324:短信发送(下行)
        /// <summary>
        /// 短信发送(下行)
        /// </summary>
        public struct Struct0324
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 线路名ID[4,unit32]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 类型[1,byte],8 bit，bit[0]-面向乘客显示;bit[1]-要求按键应答;bit[2]-是否mp3指令;bit[3]-是否TTS不播报;
            /// </summary>
            public string Type { get; set; }
            /// <summary>
            /// 短信内容[100,string]
            /// </summary>
            public string Content { get; set; }
            /// <summary>
            /// 消息ID[4,unit32]
            /// </summary>
            public string MsgId { get; set; }
        }
        #endregion

        #region 0x0325:短信发送应答(上行)
        /// <summary>
        /// 短信发送应答(上行)
        /// </summary>
        public struct Struct0325
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 设置应答[1,byte],0-失败；1-成功
            /// </summary>
            public int Result { get; set; }
            /// <summary>
            /// 错误原因[50,string]
            /// </summary>
            public string FailReason { get; set; }
        }
        #endregion

        #region 0x0326:提取车载缓存数据(下行)
        /// <summary>
        /// 提取车载缓存数据(下行)
        /// </summary>
        public struct Struct0326
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 日期[3,bytes],YYMMDD
            /// </summary>
            public string Date { get; set; }
            /// <summary>
            /// 时间[2,bytes],HHmm
            /// </summary>
            public string Time { get; set; }
        }
        #endregion

        #region 0x0327:提取车载缓存数据应答(上行)
        /// <summary>
        /// 提取车载缓存数据应答(上行)
        /// </summary>
        public struct Struct0327
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 应答[1,byte],0-失败；1-成功；2-协议不支持
            /// </summary>
            public int Result { get; set; }
            /// <summary>
            /// 日期[3,bytes],YYMMDD
            /// </summary>
            public string Date { get; set; }
            /// <summary>
            /// 时间[2,bytes],HHmm
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 记录个数[1,byte]
            /// </summary>
            public int RecordCount { get; set; }
            /// <summary>
            /// 缓存数据
            /// </summary>
            public List<StructCacheData> Datas { get; set; }
        }

        public struct StructCacheData
        {
            /// <summary>
            /// 时间[3,bytes],HHmmss
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 经度[4,经纬度]
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 纬度[4,经纬度]
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 车速[2,unit16]KM/H，定位设置上传的行车速度，四舍五入
            /// </summary>
            public int Speed { get; set; }
            /// <summary>
            /// 方向角[2,unit16](方向0~359,单位为度（o），正北为0，顺时针)
            /// </summary>
            public int Angle { get; set; }


            /// <summary>
            /// 02经度
            /// </summary>
            public double Lon02 { get; set; }
            /// <summary>
            /// 02纬度
            /// </summary>
            public double Lat02 { get; set; }
        }
        #endregion

        #region 0x0328:发送SIM卡ICCID号码(上行)
        /// <summary>
        /// 发送SIM卡ICCID号码(上行)
        /// </summary>
        public struct Struct0328
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// SIM卡ICCID号码[21,string],20位数字字符串
            /// </summary>
            public string ICCID { get; set; }
        }
        #endregion

        #region 0x0329:发送SIM卡ICCID号码应答(下行)
        /// <summary>
        /// 发送SIM卡ICCID号码应答(下行)
        /// </summary>
        public struct Struct0329
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// SIM卡ICCID号码[21,string],20位数字字符串
            /// </summary>
            public string ICCID { get; set; }
            /// <summary>
            /// SIM卡电话号码[20,string]
            /// </summary>
            public string Telephone { get; set; }
        }
        #endregion

        #region 0x032A:司机阅读短信确认报告(上行)
        /// <summary>
        /// 司机阅读短信确认报告(上行)
        /// </summary>
        public struct Struct032A
        {
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 短信ID[4,unit32]
            /// </summary>
            public string MsgId { get; set; }
            /// <summary>
            /// 返回代码[1,hex],01-成功
            /// </summary>
            public int Result { get; set; }
        }
        #endregion

        #endregion

        #region 0x04 指令
        /// <summary>
        /// 调度客户端登陆信息(上行:调度客户端=》二道 需要应答)
        /// </summary>
        public struct Struct0401
        {
            /// <summary>
            /// 线路Id BCD,3
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 线路名 string,20
            /// </summary>
            public string LineName { get; set; }
            /// <summary>
            /// 登陆名 string,20
            /// </summary>
            public string LoginName { get; set; }
            /// <summary>
            /// 登录时间 BCD,7
            /// </summary>
            public DateTime LoginTime { get; set; }
            /// <summary>
            /// 客户端版本 string,8
            /// </summary>
            public string Version { get; set; }
        }

        /// <summary>
        /// 通用应答命令(下行:二道=》调度客户端)
        /// </summary>
        public struct Struct04FE
        {
            /// <summary>
            /// 命令字 BCD,2 对应上行消息的 消息ID
            /// </summary>
            public string MSG_ID { get; set; }
            /// <summary>
            /// 命令序列号 uint32,4 对应上行消息的 消息序号
            /// </summary>
            public UInt32 MSG_SN { get; set; }
            /// <summary>
            /// 附加信息 string,变长 应答附加消息，可为空
            /// </summary>
            public string MSG { get; set; }
        }

        /// <summary>
        /// 通用应答命令(上行:调度客户端=》二道)
        /// </summary>
        public struct Struct04FD
        {
            /// <summary>
            /// 命令字 BCD,2 对应下传消息的 消息ID
            /// </summary>
            public string MSG_ID { get; set; }
            /// <summary>
            /// 命令序列号 uint32,4 对应下传消息的 消息序号
            /// </summary>
            public UInt32 MSG_SN { get; set; }
            /// <summary>
            /// 附加信息 string,变长 应答附加消息，可为空
            /// </summary>
            public string MSG { get; set; }
        }

        /// <summary>
        /// 发送GPS位置信息(下行:二道=》调度客户端)
        /// </summary>
        public struct Struct0402
        {
            // 车辆编号
            public string VehicleNo { get; set; }

            /// <summary>
            /// 线路名ID[3,BCD]
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 线路名 string,20
            /// </summary>
            public string LineName { get; set; }
            /// <summary>
            /// 车辆ID[20,string]
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 定位时间[7,BCD]
            /// </summary>
            public DateTime GPSDateTime { get; set; }
            /// <summary>
            /// 发送时间[7,BCD]
            /// </summary>
            public DateTime SendDateTime { get; set; }
            /// <summary>
            /// 上下行:0-上；1-下
            /// </summary>
            public int UpDown { get; set; }
            /// <summary>
            /// 经度[4,经纬度]
            /// </summary>
            public double Lon { get; set; }
            /// <summary>
            /// 纬度[4,经纬度]
            /// </summary>
            public double Lat { get; set; }
            /// <summary>
            /// 84经度(车载上传的原始经纬度)
            /// </summary>
            public double Lon84 { get; set; }
            /// <summary>
            /// 84纬度(车载上传的原始经纬度)
            /// </summary>
            public double Lat84 { get; set; }
            /// <summary>
            /// 速度[2,unit16]KM/H，定位设置上传的行车速度，四舍五入
            /// </summary>
            public int Speed { get; set; }
            /// <summary>
            /// 方向角[2,unit16](方向0~359,单位为度（o），正北为0，顺时针)
            /// </summary>
            public int Angle { get; set; }
            /// <summary>
            /// 下一站站级[1,byte]
            /// </summary>
            public int NextLevel { get; set; }
            /// <summary>
            /// 距下一站距离[2,unit16],单位M
            /// </summary>
            public int NextStationMeter { get; set; }
            /// <summary>
            /// 营运/非营运状态[1,byte],11H:线路营运；12H:交通车；13H:特约车；41H:正常退出；42H:故障；43H:保养；44H:事故；45H:肇事；46H:加油；
            /// </summary>
            public int RunStatus { get; set; }
            /// <summary>
            /// 车辆状态[1,byte],8 bit,[0](是否熄火：0-开车；1-熄火);[7](是否缓存数据：0-实时数据;1-缓存数据)
            /// </summary>
            public int VehStatus { get; set; }
            /// <summary>
            /// 超速标准[1,unit8],单位：公里/小时
            /// </summary>
            public int Overspeed { get; set; }
            /// <summary>
            /// 位置[1,byte]用一个公用类中的枚举描述值
            /// </summary>
            public int Location { get; set; }
            /// <summary>
            /// 数据源[1,byte]01:GPS 02：RFID 03：WIFI 04：模拟信号
            /// </summary>
            public int Source { get; set; }

            /// <summary>
            /// True: GPS时间非法
            /// </summary>
            public Boolean invalidGpsDT { get; set; }
        }

        /// <summary>
        /// 模拟信号启停指令,MSG_ID=0x0403，上行（调度客户端=》二道）
        /// </summary>
        public struct Struct0403
        {
            /// <summary>
            /// 线路Id BCD,3
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 线路名 string,20
            /// </summary>
            public string LineName { get; set; }
            /// <summary>
            /// 车辆ID string,20
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 启停标记 byte,1 1-启动;0-停止
            /// </summary>
            public int OnOff { get; set; }
            /// <summary>
            /// 站级序号 byte,1
            /// </summary>
            public int StationLevel { get; set; }
            /// <summary>
            /// 上下行:0-上；1-下
            /// </summary>
            public int UpDown { get; set; }
            /// <summary>
            /// 模拟全程数 byte,1
            /// </summary>
            public int QC_Count { get; set; }
        }

        /// <summary>
        /// 通知调度客户端停止模拟信号,MSG_ID=0x0404，(下行:二道=》调度客户端)
        /// </summary>
        public struct Struct0404
        {
            /// <summary>
            /// 线路Id BCD,3
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 线路名 string,20
            /// </summary>
            public string LineName { get; set; }
            /// <summary>
            /// 车辆ID string,20
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 附加信息 string,变长 附加消息，可为空
            /// </summary>
            public string MSG { get; set; }
        }

        /// <summary>
        /// 应答0x0404 , MSG_ID=0x0405，上行（调度客户端=》二道）
        /// </summary>
        public struct Struct0405
        {
            /// <summary>
            /// 线路Id BCD,3
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 线路名 string,20
            /// </summary>
            public string LineName { get; set; }
            /// <summary>
            /// 车辆ID string,20
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 命令序列号 uint32,4 对应下传消息的 消息序号
            /// </summary>
            public UInt32 MSG_SN { get; set; }
            /// <summary>
            /// 附加信息 string,变长 应答附加消息，可为空
            /// </summary>
            public string MSG { get; set; }
        }

        /// <summary>
        /// 调度客户端调时同步 , MSG_ID=0x0406，上行
        /// </summary>
        public struct Struct0406
        {
            /// <summary>
            /// 线路Id BCD,3
            /// </summary>
            public string LineId { get; set; }
            /// <summary>
            /// 线路名 string,20
            /// </summary>
            public string LineName { get; set; }
            /// <summary>
            /// 上下行:0-上；1-下
            /// </summary>
            public int UpDown { get; set; }
            /// <summary>
            /// 发送时间[4,BCD] DDHHMMSS
            /// </summary>
            public string SendDateTime { get; set; }
            /// <summary>
            /// 车辆ID string,20
            /// </summary>
            public string VehicleId { get; set; }
            /// <summary>
            /// 同步时间[2,BCD] HHmm
            /// </summary>
            public string SyncTime { get; set; }
            /// <summary>
            /// 车辆ID2 string,20
            /// </summary>
            public string VehicleId2 { get; set; }
            /// <summary>
            /// 同步时间2[2,BCD] HHmm
            /// </summary>
            public string SyncTime2 { get; set; }
        }
        #endregion

    }
}