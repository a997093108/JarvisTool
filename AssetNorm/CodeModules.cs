using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetNorm
{
    public static class CodeModules
    {
        #region _classBody
        private const string _classBody = @"using System.IO;
using LitJson;
using System;
public static class {ClassName}
{
    /**
     *  本代码文件由:
     *              拯救贾维斯 - 火星最强小组开发日常小工具Beat1.0 小工具  生成
     *              创建时间: {CreateTime}
     *              
     *  * 请开发者按照如下标号注意再行使用 (可复制以下几点Ctrl + F搜索查看)
     *              1:  (1) 请在Bootstrap中调用此方法
     *              2:  (2) 每个JSON对象的方法, 可设置和获取JSON对象的数据
     *                      参数1: 指定对象的索引 0开始
     *                      参数2: 在调用的时候,如果为空. 则是只获取数据不设置. 否则为设置参数并返回数据
     */


    private static JsonData _json;
    private static string _jsonPath = """";


    // (1) 请在Bootstrap中调用此方法 , 参数path代表JSON文件路径
    public static bool Init(string path)
    {
        //本方法如果返回失败, 则说明读取JSON文件失败.

        string str = File.ReadAllText(path);
        if (string.IsNullOrEmpty(str)) return false;

        _json = JsonMapper.ToObject(str);
        if (_json == null) return false;

        _jsonPath = path;
        return true;
    }

    /// <summary>
    /// 获取JSON数量
    /// </summary>
    public static int Count
    {
        get { return _json.Count; }
    }


    //=========================以下都是更改和获取JSON数据的方法==========================
    //[Method body}
}";
        #endregion

        #region _methodString
        private const string _methodString = @"
    /// <summary>
    /// 更改或者获取 SubItem 的数据
    /// </summary>
    /// <param name=""index"">JSON的索引</param>
    /// <param name=""val"">填写则设置, 不填写则只获取</param>
    public static string MethodName(int index, string val = null)
    {
        string old = _json[""Data""][index][""SubItem""].ToString();
        if (string.IsNullOrEmpty(val))
        {
            return old;
        }

        _json[""Data""][index][""SubItem""] = val;

        File.WriteAllText(_jsonPath, _json.ToJson());

        return _json[""Data""][index][""SubItem""].ToString();
    }";
        #endregion

        #region _methodInt
        private const string _methodInt = @"
    /// <summary>
    /// 更改或者获取 SubItem 的数据
    /// </summary>
    /// <param name=""index"">JSON的索引</param>
    /// <param name=""val"">填写则设置, 不填写则只获取</param>
    public static int MethodName(int index, int val = -1024)
    {
        string old = _json[""Data""][index][""SubItem""].ToString();
        int ret = -1;
        if (val == -1024)
        {
            try
            {
                ret = Convert.ToInt32(old);
            }
            catch (Exception)
            {

                ret = -1;
            }

            return ret;
        }
        else
        {
            _json[""Data""][index][""SubItem""] = val;

            File.WriteAllText(_jsonPath, _json.ToJson());

            try
            {
                ret = Convert.ToInt32(val);
            }
            catch (Exception)
            {

                ret = -1;
            }

            return ret;
        }
    }";
        #endregion

        #region _methodFloat
        private const string _methodFloat = @"
    /// <summary>
    /// 更改或者获取 SubItem 的数据
    /// </summary>
    /// <param name=""index"">JSON的索引</param>
    /// <param name=""val"">填写则设置, 不填写则只获取</param>
    public static float MethodName(int index, float val = -1024f)
    {
        string old = _json[""Data""][index][""SubItem""].ToString();
        float ret = -1;
        if (val == -1024f)
        {
            try
            {
                ret = Convert.ToSingle(old);
            }
            catch (Exception)
            {

                ret = -1;
            }

            return ret;
        }
        else
        {
            _json[""Data""][index][""SubItem""] = val;

            File.WriteAllText(_jsonPath, _json.ToJson());

            try
            {
                ret = Convert.ToSingle(val);
            }
            catch (Exception)
            {

                ret = -1;
            }

            return ret;
        }
    }";
        #endregion

        #region _methodBoolNotValue
        private const string _methodBoolNotValue = @"
    /// <summary>
    /// 获取 SubItem 的数据
    /// </summary>
    /// <param name=""index"">JSON的索引</param>
    public static bool MethodName(int index)
    {
        string old = _json[""Data""][index][""SubItem""].ToString();

        bool ret = false;
        try
        {
            ret = Convert.ToBoolean(old);
        }
        catch (Exception)
        {

            ret = false;
        }

        return ret;
    }";
        #endregion

        #region _methodBoolValue
        private const string _methodBoolValue = @"
    /// <summary>
    /// 更改和获取 SubItem 的数据
    /// </summary>
    /// <param name=""index"">JSON的索引</param>
    /// <param name=""val"">设置的bool值</param>
    public static bool MethodName(int index,bool val)
    {

        _json[""Data""][index][""SubItem""] = val;

        File.WriteAllText(_jsonPath, _json.ToJson());

        return val;
    }"; 
        #endregion

        public static string ClassBody => _classBody;

        public static string MethodString => _methodString;

        public static string MethodInt => _methodInt;

        public static string MethodFloat => _methodFloat;

        public static string MethodBoolNotValue => _methodBoolNotValue;

        public static string MethodBoolValue => _methodBoolValue;

        //MethodName
        public static String GetUpperName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                //随机取出几个英文字母和数字
                Random r = new Random();
                string letter = "";
                for (int i = 0; i < 10; i++)
                {
                    letter += ((char)r.Next(97, 123)).ToString();
                }
                return "NotDefined_" + letter;
            }

            if (name.Length>=2)
            {
                return name[0].ToString().ToUpper() + name.Substring(1);
            }
            else
            {
                return name.ToUpper();
            }  
        }

    }
}
