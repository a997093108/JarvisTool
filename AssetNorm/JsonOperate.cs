using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LitJson;
using System.Text.RegularExpressions;

using System.Diagnostics;

namespace AssetNorm
{
    public static class JsonOperate
    {
        public static List<JsonModule> JsonModules = new List<JsonModule>();
        private static JsonData _currentOpenJson = null;

        public static JsonData CurrentOpenJson { get => _currentOpenJson; set => _currentOpenJson = value; }

        public struct JsonModule
        {
            public string type;
            public string name;
            public string comment;
            public JsonModule(string type, string name, string comment)
            {
                this.type = type;
                this.name = name;
                this.comment = comment;
            }
        }

        public static bool ConvertToList(string str, out string info)
        {
            if (string.IsNullOrEmpty(str))
            {
                info = "未填写代码";
                JsonModules = null;
                return false;
            }

            //将传进来的模板转换
            JsonModules = new List<JsonModule>();
            foreach (Match match in Regex.Matches(str, @"([\w]+)[\s]*?([\w]+) *(//.*)*"))
            {
                if (match.Groups.Count < 3)
                {
                    info = "有变量未设置名称";
                    JsonModules = null;
                    return false;
                }

                if (match.Groups.Count == 3)//不带注释的
                {
                    JsonModules.Add(new JsonModule(match.Groups[1].Value, match.Groups[2].Value, ""));
                }
                else if (match.Groups.Count == 4)//带注释的
                {
                    JsonModules.Add(new JsonModule(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value));
                }
            }
            info = "";
            return true;
        }

        public static string GenerateCode(string className, string jsonName)
        {
            if (JsonModules == null)
            {
                return "";
            }



            //增加方法
            string methodCode = "\r\n";
            foreach (var item in JsonModules)
            {
                string temp = "";

                switch (item.type)
                {
                    case "string":
                        temp = CodeModules.MethodString.Replace("SubItem", item.name);
                        break;
                    case "int":
                        temp = CodeModules.MethodInt.Replace("SubItem", item.name);
                        break;
                    case "float":
                        temp = CodeModules.MethodFloat.Replace("SubItem", item.name);

                        break;
                    case "bool":
                        temp = CodeModules.MethodBoolNotValue.Replace("SubItem", item.name)+"\r\n\r\n";
                        temp += CodeModules.MethodBoolValue.Replace("SubItem", item.name);
                        break;
                }
                temp = temp.Replace("MethodName", CodeModules.GetUpperName(item.name) + "_JsonData");

                methodCode += temp + "\r\n\r\n";
            }

            string result = "";

            //将方法加入到类中
            result = CodeModules.ClassBody.Replace("//[Method body}", methodCode);

            //修改类名
            result = result.Replace("{ClassName}", className);

            //修改创建时间
            result = result.Replace("{CreateTime}", DateTime.Now.ToLocalTime().ToString());
            return result;

        }




    }
}
