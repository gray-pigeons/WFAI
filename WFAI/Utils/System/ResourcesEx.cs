using System;

using WFAI.Properties;

namespace WFAI.Utils.System
{
    internal class ResourcesEx
    {
        /// <summary>
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static Bitmap? GetBitmap(string name)
        {
            try
            {
                object? obj = Resources.ResourceManager.GetObject(name, Resources.Culture);
                if (obj == null)
                {
                    return default;
                }
                return (Bitmap)obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"读取异常:{ex}");
                return default;
            }
            
        }
    }
}
