using System.Collections.Generic;
using System.ComponentModel;

namespace BS.MessageParser.Tool.Model
{
    public class BaseDataDown
    {
        /// <summary>
        /// 命令字
        /// </summary>
        [Description("命令字")]
        public byte CommandCode { get; set; }

        /// <summary>
        /// 数据长度
        /// </summary>
        [Description("数据长度")]
        public ushort DataLength { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [Description("版本")]
        public string Version { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [Description("序列号")]
        public byte SerialNum { get; set; }

        /// <summary>
        /// 车辆编号
        /// </summary>
        [Description("车辆编号")]
        public string VehicleNum { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [Description("日期")]
        public string Date { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Description("时间")]
        public string Time { get; set; }

        /// <summary>
        /// 校验码
        /// </summary>
        [Description("校验码")]
        public string CheckCode { get; set; }

    }
    public class BaseData
    {
        /// <summary>
        /// 命令字
        /// </summary>
        [Description("命令字")]
        public byte CommandCode { get; set; }

        /// <summary>
        /// 数据长度
        /// </summary>
        [Description("数据长度")]
        public ushort DataLength { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [Description("版本")]
        public string Version { get; set; }

        /// <summary>
        /// 序列号1
        /// </summary>
        [Description("序列号1")]
        public byte SerialNum1 { get; set; }

        /// <summary>
        /// 序列号2
        /// </summary>
       [Description("序列号2")]
        public ushort SerialNum2 { get; set; }

        /// <summary>
        /// 检测线状态
        /// </summary>
        [Description("检测线状态")]
        public byte WireStatus { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public byte Status { get; set; }

        /// <summary>
        /// 车辆编号
        /// </summary>
        [Description("车辆编号")]
        public string VehicleNum { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [Description("日期")]
        public string Date { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
       [Description("时间")]
        public string Time { get; set; }

        /// <summary>
        /// 线路ID
        /// </summary>
       [Description("线路ID")]
        public int LineId { get; set; }

        /// <summary>
        /// 子线路编码
        /// </summary>
     [Description("子线路编码")]
        public byte SubLineCode { get; set; }

        /// <summary>
        /// 校验码
        /// </summary>
      [Description("校验码")]
        public string CheckCode { get; set; }

    }

    public class Data0X10
    {
        /// <summary>
        /// 应答命令字
        /// </summary>
        [Description("应答命令字")]
        public byte ResponseCommand { get; set; }

        /// <summary>
        /// 应答序列号
        /// </summary>
        [Description("应答序列号")]
        public byte ResponseNum { get; set; }

        /// <summary>
        /// 应答返回值
        /// </summary>
        [Description("应答返回值")]
        public long ResponseReturn { get; set; }

    }
    public class Data0X11
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 通讯软件版本
        /// </summary>
        [Description("通讯软件版本")]
        public string SoftwareVer { get; set; }

        /// <summary>
        /// 设备序列号
        /// </summary>
        [Description("设备序列号")]
        public string DeviceNum { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        [Description("线路名称")]
        public string LineName { get; set; }

        /// <summary>
        /// 线路ID
        /// </summary>
        [Description("线路ID")]
        public int LineId { get; set; }

        /// <summary>
        /// 车牌号码
        /// </summary>
        [Description("车牌号码")]
        public string PlateNum { get; set; }

        /// <summary>
        /// SIM卡ICCID号码
        /// </summary>
        [Description("SIM卡ICCID号码")]
        public string SIM { get; set; }

        /// <summary>
        ///车载设备厂商
        /// </summary>
        [Description("车载设备厂商")]
        public string Factory { get; set; }

    }
    public class Data0X14
    {
        /// <summary>
        /// 纬度
        /// </summary>
       [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 上下行标识
        /// </summary>
        [Description("上下行标识")]
        public byte DirectionMark { get; set; }

        /// <summary>
        /// 下一站编号
        /// </summary>
        [Description("下一站编号")]
        public byte NextStationNum { get; set; }

        /// <summary>
        /// 距离下一站
        /// </summary>
        [Description("距离下一站")]
        public ushort DistanceToNextStation { get; set; }

        /// <summary>
        /// 是否在站点内
        /// </summary>
        [Description("是否在站点内")]
        public byte IsInStation { get; set; }

        /// <summary>
        /// 是否缓存数据
        /// </summary>
        [Description("是否缓存数据")]
        public byte IsCaching { get; set; }

        /// <summary>
        /// 总里程
        /// </summary>
        [Description("总里程")]
        public int Mileage { get; set; }

        /// <summary>
        /// 超速标准
        /// </summary>
        [Description("超速标准")]
        public byte OverspeedCriterion { get; set; }

        /// <summary>
        /// 车内温度
        /// </summary>
        [Description("车内温度")]
        public ushort Temperature { get; set; }

        /// <summary>
        /// 油量（整数）
        /// </summary>
        [Description("油量（整数）")]
        public ushort FuelInt { get; set; }

        /// <summary>
        ///油量（小数） 
        /// </summary>
        [Description("油量（小数）")]
        public byte FuelFraction { get; set; }

        /// <summary>
        /// 营运状态
        /// </summary>
        [Description("营运状态")]
        public byte ServiceStatus { get; set; }

        /// <summary>
        /// 驾驶员ID
        /// </summary>
        [Description("驾驶员ID")]
        public string DriverId { get; set; }

        /// <summary>
        /// SIM卡类型
        /// </summary>
        [Description("SIM卡类型")]
        public byte SIMCardType { get; set; }

        /// <summary>
        /// 基站定位：状态
        /// </summary>
        [Description("基站定位：状态")]
        public byte BaseLocationStatus { get; set; }

        /// <summary>
        /// 基站定位：位置
        /// </summary>
        [Description("基站定位：位置")]
        public string BaseLocationLocale { get; set; }

        /// <summary>
        /// 基站定位：Cell ID
        /// </summary>
        [Description("基站定位：Cell ID")]
        public string BaseLocationCellId { get; set; }
    }

    public class Data0X17
    {  
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 热点扫描周期
        /// </summary>
        [Description("热点扫描周期")]
        public byte HotSpotPeriod { get; set; }

        /// <summary>
        /// 热点个数
        /// </summary>
        [Description("热点个数")]
        public byte HotSpotCount { get; set; }

        /// <summary>
        /// 热点列表
        /// </summary>
        [Description("热点列表")]
        public List<HotSpot> HotSpots { get; set; }
    }

    public class HotSpot
    {
        public string SSID { get; set; }
        public long IPv6 { get; set; }

        /// <summary>
        /// 信号强度
        /// </summary>
        [Description("信号强度")]
        public byte SignalIntensity { get; set; }
    }

    public class Data0X18
    {
        public byte GPS { get; set; }
        public byte WiFi { get; set; }
        public byte CAN { get; set; }
        public byte POS { get; set; }
        /// <summary>
        /// 投币机
        /// </summary>
        [Description("投币机")]
        public byte Coin { get; set; }
        public byte DVR { get; set; }
        /// <summary>
        /// 温度传感器
        /// </summary>
        [Description("温度传感器")]
        public byte Sensor { get; set; }
        public byte RFID { get; set; }
    }

    public class Data0X1A
    {
        /// <summary>
        /// 日期
        /// </summary>
        [Description("日期")]
        public string Date { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Description("时间")]
        public string Time { get; set; }

        /// <summary>
        /// 记录个数
        /// </summary>
        [Description("记录个数")]
        public byte RecordCount { get; set; }

        /// <summary>
        /// 记录列表
        /// </summary>
        [Description("记录列表")]
        public List<Record> Records { get; set; }
    }

    public class Record
    {
        /// <summary>
        /// 时间
        /// </summary>
        [Description("时间")]
        public string Time { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public byte InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public byte Azimuth { get; set; }
    }
    public class Data0X20
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public byte Status { get; set; }
    }
    public class Data0X252627
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 累计工作时间
        /// </summary>
        [Description("累计工作时间")]
        public uint WorkTime { get; set; }

        ///// <summary>
        ///// 备用
        ///// </summary>
        //[Description("*")]
        //public int Reserve { get; set; }

        /// <summary>
        /// SIM卡类型
        /// </summary>
        [Description("SIM卡类型")]
        public byte SIMCardType { get; set; }

        /// <summary>
        /// 基站定位：状态
        /// </summary>
        [Description("基站定位：状态")]
        public byte BaseLocationStatus { get; set; }

        /// <summary>
        /// 基站定位：位置
        /// </summary>
        [Description("基站定位：位置")]
        public string BaseLocationLocale { get; set; }

        /// <summary>
        /// 基站定位：Cell ID
        /// </summary>
        [Description("基站定位：Cell ID")]
        public string BaseLocationCellId { get; set; }


    }
    public class Data0X33
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 按键信息
        /// </summary>
        [Description("按键信息")]
        public byte ButtonInfo { get; set; }

        /// <summary>
        /// 驾驶员身份ID
        /// </summary>
        [Description("驾驶员身份ID")]
        public string DriverId { get; set; }
    }

    public class Data0X3A
    {
        /// <summary>
        /// 图片编号
        /// </summary>
        [Description("图片编号")]
        public byte ImgId { get; set; }

        /// <summary>
        /// 摄像头编号
        /// </summary>
        [Description("摄像头编号")]
        public byte CameraId { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [Description("页码")]
        public ushort PageNum { get; set; }

        /// <summary>
        /// 图像数据长度
        /// </summary>
        [Description("图像数据长度")]
        public ushort ImgDataLength { get; set; }

        /// <summary>
        /// 图像数据异或和
        /// </summary>
        [Description("图像数据异或和")]
        public byte XOrSum { get; set; }

        /// <summary>
        /// 图像数据
        /// </summary>
        [Description("图像数据")]
        public string ImgData { get; set; }
    }

    public class Data0X3B
    {
        /// <summary>
        /// 状态指令
        /// </summary>
        [Description("状态指令")]
        public byte StatusCommand { get; set; }

        /// <summary>
        /// 指令参数
        /// </summary>
        [Description("指令参数")]
        public byte CommandParam { get; set; }
    }
    public class Data0X4041
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 上下行标识
        /// </summary>
        [Description("上下行标识")]
        public byte DirectionMark { get; set; }

        /// <summary>
        /// 站点编号
        /// </summary>
        [Description("站点编号")]
        public byte StationNum { get; set; }

        /// <summary>
        /// 线路ID
        /// </summary>
        [Description("线路ID")]
        public uint LineId { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        [Description("线路名称")]
        public string LineName { get; set; }

        /// <summary>
        /// 驾驶员身份ID
        /// </summary>
        [Description("驾驶员身份ID")]
        public string DriverId { get; set; }

        /// <summary>
        /// 报站方式
        /// </summary>
        [Description("报站方式")]
        public byte ReportMode { get; set; }
    }
    public class Data0X42
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 超速标识
        /// </summary>
        [Description("超速标识")]
        public byte OverspeedMark { get; set; }

        /// <summary>
        /// 驾驶员身份ID
        /// </summary>
        [Description("驾驶员身份ID")]
        public string DriverId { get; set; }
    }
    public class Data0X43
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 离线标识
        /// </summary>
        [Description("离线标识")]
        public byte OfflineMark { get; set; }

        /// <summary>
        /// 驾驶员身份ID
        /// </summary>
        [Description("驾驶员身份ID")]
        public string DriverId { get; set; }
    }
    public class Data0X44
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 非正常行驶状态
        /// </summary>
        [Description("非正常行驶状态")]
        public byte AbnormalStatus { get; set; }

        /// <summary>
        /// 驾驶员身份ID
        /// </summary>
        [Description("驾驶员身份ID")]
        public string DriverId { get; set; }
    }
    public class Data0X45
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 瞬时速度
        /// </summary>
        [Description("瞬时速度")]
        public ushort InstantaneousVelocity { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        [Description("方位角")]
        public ushort Azimuth { get; set; }

        /// <summary>
        /// 车辆状态
        /// </summary>
        [Description("车辆状态")]
        public byte VehicleStatus { get; set; }

        /// <summary>
        /// 上下行标识
        /// </summary>
        [Description("上下行标识")]
        public byte DirectionMark { get; set; }

        /// <summary>
        /// 站点编号
        /// </summary>
        [Description("站点编号")]
        public byte StationNum { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        [Description("数据类型")]
        public byte DataType { get; set; }


        /// <summary>
        /// 数据
        /// </summary>
        [Description("数据")]
        public string Data { get; set; }
    }

    public class PassengerFlow
    {
        public ushort STX { get; set; }
        [Description("协议帧长度")]
        public ushort Length { get; set; }
        [Description("设备类型")]
        public byte DeviceType { get; set; }
        [Description("设备ID")]
        public byte DeviceId { get; set; }
        public byte CmdId { get; set; }
        [Description("协议状态")]
        public byte Status { get; set; }
        [Description("序列号")]
        public byte SerialId { get; set; }
        [Description("时间")]
        public string DateTime { get; set; }
        [Description("车牌号")]
        public string VehicleNum { get; set; }
        public ushort CRC16 { get; set; }
    }

    public class Data0X47
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [Description("消息ID")]
        public uint MsgId { get; set; }

        /// <summary>
        /// 返回代码
        /// </summary>
        [Description("返回代码")]
        public byte ReturnCode { get; set; }
    }

    public class Data0X48
    {
        /// <summary>
        /// 卡号
        /// </summary>
        [Description("卡号")]
        public string CardNum { get; set; }
    }

    public class Data0X49
    {
        /// <summary>
        /// 新线路名称
        /// </summary>
        [Description("新线路名称")]
        public string NewLineName { get; set; }

        /// <summary>
        /// 新线路ID
        /// </summary>
        [Description("新线路ID")]
        public uint NewLineId { get; set; }

        /// <summary>
        /// 旧线路名称
        /// </summary>
        [Description("旧线路名称")]
        public string OldLineName { get; set; }

        /// <summary>
        /// 旧线路ID
        /// </summary>
        [Description("旧线路ID")]
        public uint OldLineId { get; set; }

        /// <summary>
        /// 报站语音序号
        /// </summary>
        [Description("报站语音序号")]
        public byte Num { get; set; }
    }

    public class Data0X50
    {
        [Description("应答的命令字")]
        public string Cmd { get; set; }
        [Description("应答的序列号")]
        public string SerialNum { get; set; }
        [Description("应答返回值")]
        public string ReturnValue { get; set; }
    }

    public class Data0X65
    {
        [Description("日期")]
        public string Date { get; set; }
        [Description("时间")]
        public string Time { get; set; }
    }

    public class Data0X73
    {
        [Description("摄像头编号")]
        public string CamNum { get; set; }
        [Description("图像分辨率")]
        public string Resolution { get; set; }
        
    }
    public class Data0X76
    {
        [Description("摄像头编号")]
        public string CamNum { get; set; }
    }

    public class Data0X8E
    {
        [Description("车号")]
        public string VehicleNum { get; set; }
        [Description("完成班次数")]
        public byte Completed { get; set; }
        [Description("计划班次数")]
        public byte Plan { get; set; }
        [Description("下一班发车时间")]
        public string NextTime { get; set; }
        [Description("完成班次更新日期")]
        public string UpdateDate { get; set; }
        [Description("完成班次更新时间")]
        public string UpdateTime { get; set; }
    }

    public class Data0X8F
    {
        [Description("SIM卡ICCID号码")]
        public string ICCID { get; set; }
        [Description("SIM卡电话号码")]
        public string PhoneNum { get; set; }
    }
    public class Data0X90
    {
        [Description("指令类型")]
        public byte Type { get; set; }
        [Description("语音指令序号")]
        public string Num { get; set; }
        [Description("指令文本内容")]
        public string Content { get; set; }
        [Description("消息ID")]
        public string MsgId { get; set; }
    }
    public class Data0X91
    {
        [Description("线路名称")]
        public string LineName { get; set; }
        [Description("线路ID")]
        public uint LineId { get; set; }
        [Description("子线路编码")]
        public byte SubLineEncoding { get; set; }
        [Description("报站类型")]
        public byte ReportType { get; set; }
        [Description("上下行标识")]
        public byte DirectionMark { get; set; }
        [Description("报站掩码")]
        public string ReportMask { get; set; }
    }

    public class Data0X92
    {
        [Description("刷卡日期")]
        public string Date { get; set; }
        [Description("刷卡时间")]
        public string Time { get; set; }
        [Description("卡号")]
        public string CardNum { get; set; }
        [Description("工号")]
        public string WorkNum { get; set; }
        [Description("姓名")]
        public string Name { get; set; }
        [Description("工种")]
        public string WorkType { get; set; }

    }

    public class Data0X98
    {
        [Description("加入/退出")]
        public string Status { get; set; }
    }
}