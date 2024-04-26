using System.Text;
using System.Runtime.InteropServices;

namespace XClassINI
{
    public class XClassINI
    {
        public int _nSize { get; set; }
        public string _szSection { get; set; }
        public string _szKey { get; set; }
        public string _szValue { get; set; }
        public string _szDefault { get; set; }
        public string _szFilePath { get; set; }
        
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public void Setting(string szSection, string szKey, string szFilePath)
        {
            _szSection = szSection;
            _szKey = szKey;
            _szFilePath = szFilePath;

            if(_szDefault == null)
                _szDefault = "";

            if (_nSize == 0)
                _nSize = 255;
        }

        public void Write(string szData)
        {
            WritePrivateProfileString(_szSection, _szKey, szData, _szFilePath);
        }

        public string Read(string szKey)
        {
            _szKey = szKey;

            StringBuilder stringBuilder = new StringBuilder(_nSize);

            GetPrivateProfileString(_szSection, _szKey, _szDefault, stringBuilder, _nSize, _szFilePath);

            return stringBuilder.ToString();
        }
    }
}
