using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFAI.Utils.Net.HttpEx;

namespace WFAI.Utils.Tools.IniEx
{


    public class IniConfigData
    {
        public required string Section { get; set; }

        public required string KeyParameter { get; set; }

        public required string KeyVal { get; set; }

    }

    public class IniConfigConst
    {
        public const string DifyServerSection = "DifyServerSection";
        public const string DifyServerAddr = "ServerAddr";
        public const string DifyUser = "DifyUser";
        public const string DifyQwenServerApiKey = "QwenServerApiKey";
        public const string DifyGeminiApiKey = "GeminiApiKey";

    }

    internal class IniEx
    {

        static IniFileEx _fileExni;
        static string fileNamePath;

        public static void Init()
        {
            if (_fileExni == null)
            {
                fileNamePath = $"{Application.StartupPath}/WFAI.ini";
                _fileExni = new IniFileEx(fileNamePath);
            }
        }

        private IniEx()
        {
            //_ini = new IniFile(DirEx. + "Setup.ini");
           
        }

        public static (bool isOk, IniDifyChatConfigData data) GetDifyIniConfigData(IniDifyChatConfigData iniConfigData)
        {
            if (iniConfigData == null)
            {
                throw new ArgumentNullException("未获取到相关参数数据");
            }
            if (string.IsNullOrEmpty(iniConfigData.Section) || !_fileExni.HasSection(iniConfigData.Section))
            {
                return (false, iniConfigData);
            }

            iniConfigData.KeyVal = _fileExni.Read(iniConfigData.Section, iniConfigData.KeyParameter, iniConfigData.KeyVal);
            iniConfigData.APIKeyValue = _fileExni.Read(iniConfigData.Section, iniConfigData.APIKeyParameter, iniConfigData.APIKeyValue);
            iniConfigData.UserValue = _fileExni.Read(iniConfigData.Section, iniConfigData.UserParams, iniConfigData.UserValue);
            return (true, iniConfigData);
        }

        public static void SetDifyIniConfigData(IniDifyChatConfigData iniConfigData)
        {
            if (iniConfigData == null|| string.IsNullOrEmpty(iniConfigData.Section))
            {
                throw new ArgumentNullException("未获取到相关参数数据");
            }

           _fileExni.Write(iniConfigData.Section, iniConfigData.KeyParameter, iniConfigData.KeyVal);
           _fileExni.Write(iniConfigData.Section, iniConfigData.APIKeyParameter, iniConfigData.APIKeyValue);
        }

        public static (bool isOk, IniConfigData data) GetDifyIniConfigData(IniConfigData iniConfigData)
        {
            if (iniConfigData == null)
            {
                throw new ArgumentNullException("未获取到相关参数数据");
            }
            if (!_fileExni.HasSection(iniConfigData.Section))
            {
                return (false, iniConfigData);
            }

            iniConfigData.KeyVal = _fileExni.Read(iniConfigData.Section, iniConfigData.KeyParameter, iniConfigData.KeyVal);
            return (true, iniConfigData);
        }


    }
}
