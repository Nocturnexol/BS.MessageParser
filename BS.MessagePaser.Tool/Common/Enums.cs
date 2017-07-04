using System.ComponentModel;

namespace Bs.MessageParser.Tool.Common
{
    public enum CommandCode
    {
        [Description("应答监控中心的指令")]
        _0X10 = 0x10,
        [Description("GPRS连接后的第一次握手")]
        _0X11=0x11,
        [Description("传送周期位置信息")]
        _0X14 = 0x14,
        [Description("传送WiFi热点信息")]
        _0X17 = 0x17,
        [Description("传送外设自检状态")]
        _0X18 = 0x18,
        [Description("传送行驶记录数据")]
        _0X1A = 0x1a,
        [Description("终端防盗报警信息")]
        _0X20 = 0x20,
        [Description("终端检测到汽车点火")]
        _0X25 = 0x25,
        [Description("终端检测到汽车熄火")]
        _0X26 = 0x26,
        [Description("终端检测到电源被切断")]
        _0X27 = 0x27,
        [Description("传送车载机的按键信息")]
        _0X33 = 0x33,
        [Description("传送图片数据(2G)")]
        _0X3A = 0x3a,
        [Description("传送图像模块状态指令")]
        _0X3B = 0x3b,
        [Description("车辆到达站点")]
        _0X40 = 0x40,
        [Description("车辆离开站点")]
        _0X41 = 0x41,
        [Description("车辆超速报告")]
        _0X42 = 0x42,
        [Description("车辆偏离线路报告")]
        _0X43 = 0x43,
        [Description("车辆非正常行驶报告")]
        _0X44 = 0x44,
        [Description("车辆客流计/POS数据报告/DVR状态报告/CAN数据报告")]
        _0X45 = 0x45,
        [Description("司机阅读消息确认报告")]
        _0X47 = 0x47,
        [Description("员工卡刷卡信息")]
        _0X48 = 0x48,
        [Description("上传手动切换线路号")]
        _0X49 = 0x49,
        [Description("应答车载机的指令")]
        _0X50 = 0x50,
        [Description("提取车载机的行驶记录")]
        _0X65 = 0x65,
        [Description("发送拍照命令")]
        _0X73 = 0x73,
        [Description("设定报警默认摄像头编号")]
        _0X76 = 0x76,
        [Description("发送公交班次信息")]
        _0X8E = 0x8e,
        [Description("发送SIM卡号码")]
        _0X8F = 0x8f,
        [Description("发送公交文本信息")]
        _0X90 = 0x90,
        [Description("设置公交车线路号")]
        _0X91 = 0x91,
        [Description("员工刷卡确认")]
        _0X92 = 0x92,
        [Description("设置加入营运/退出营运")]
        _0X98 = 0x98
    }

    public enum DataType0X45
    {
        PassengerFlow,
        POS,
        DVR,
        COIN = 5,
        DoubleTram = 7,
        CAN = 8
    }
}
