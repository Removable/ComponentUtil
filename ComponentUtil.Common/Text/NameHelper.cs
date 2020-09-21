using System.Text;
using System.Threading;

namespace ComponentUtil.Common.Text
{
    public static class NameHelper
    {
        /// <summary>
        ///     将驼峰形式的命名转为下划线形式(ForExample to for_example)
        /// </summary>
        /// <param name="name">要转换格式的名字</param>
        /// <returns></returns>
        public static string CamelToUnderscore(string name)
        {
            var result = new StringBuilder();
            if (string.IsNullOrWhiteSpace(name)) return result.ToString();

            foreach (var c in name)
                if (char.IsUpper(c)) //大写字母
                    result.Append($"_{c.ToString().ToLower()}");
                else //其他字符直接放入
                    result.Append(c);

            return result.ToString().Trim('_');
        }

        /// <summary>
        ///     将下划线形式的命名转为驼峰形式(for_example to ForExample)
        /// </summary>
        /// <param name="name">要转换格式的名字</param>
        /// <returns></returns>
        public static string UnderscoreToCamel(string name)
        {
            var result = new StringBuilder();
            if (string.IsNullOrWhiteSpace(name)) return result.ToString();

            var wordArray = name.Split('_');
            foreach (var word in wordArray)
            {
                var cultureInfo = Thread.CurrentThread.CurrentCulture;
                var text = cultureInfo.TextInfo;
                var newWord = text.ToLower(word);
                newWord = text.ToTitleCase(newWord);
                result.Append(newWord);
            }

            return result.ToString();
        }
    }
}