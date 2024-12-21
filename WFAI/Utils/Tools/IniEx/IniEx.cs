using CSharpUtils.DifyAI;
using Sunny.UI;
using System;


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


        public const string OllamaServerSection = "OllamaServerSection";
        public const string OllamaBaseServerAddr = "OllamaBaseServerAddr";
        public const string OllamaModel = "OllamaModel";
        public const string OllamaUser = "OllamaUser";

    }

    public class IniDifyChatConfigData : IniConfigData
    {
        public required string UserParams { get; set; }
        public required string UserValue { get; set; }
        public required string APIKeyParameter { get; set; }

        public required string APIKeyValue { get; set; }
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
          if (_fileExni == null)
            {
                throw new NullReferenceException("未读取到配置文件");
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

        //public static (bool isOk, LocalOllamaChatConfigData data) GetDifyIniConfigData(LocalOllamaChatConfigData iniConfigData)
        //{
        //    if (iniConfigData == null)
        //    {
        //        throw new ArgumentNullException("未获取到相关参数数据");
        //    }
        //    if (string.IsNullOrEmpty(iniConfigData.Section) || !_fileExni.HasSection(iniConfigData.Section))
        //    {
        //        return (false, iniConfigData);
        //    }

        //    iniConfigData.KeyVal = _fileExni.Read(iniConfigData.Section, iniConfigData.KeyParameter, iniConfigData.KeyVal);
        //    iniConfigData.ModelValue = _fileExni.Read(iniConfigData.Section, iniConfigData.ModelParams, iniConfigData.ModelValue);
        //    iniConfigData.UserValue = _fileExni.Read(iniConfigData.Section, iniConfigData.UserParameter, iniConfigData.UserValue);
        //    return (true, iniConfigData);
        //}

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
