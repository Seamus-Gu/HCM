using Framework.Core;
using Microsoft.Extensions.Localization;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;

namespace System
{
    public static class EnumExtension
    {
        private static readonly ConcurrentDictionary<(Type EnumType, string Name), EnumMetadata> _enumMetadataCache = new();

        #region 枚举成员
        /// <summary>
        /// 获取枚举的 int 值
        /// </summary>
        public static int ToInt(this Enum value) => Convert.ToInt32(value);

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T value) where T : Enum
        {
            return GetEnumMetadata(value).Description;
        }

        /// <summary>
        /// 获取枚举属性名
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetName(this Enum value)
        {
            return GetEnumMetadata(value).Name;
        }


        /// <summary>
        /// 抛出异常
        /// </summary>
        /// <param name="enumValue"></param>
        /// <param name="localizer"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static CodeException ToCodeException(this Enum enumValue, IStringLocalizer localizer, params object?[] args)
        {
            var code = enumValue.ToInt();
            var msg = string.Format(localizer[enumValue.GetName()], args);

            return new CodeException(code, msg);
        }

        #endregion

        #region 枚举类型

        /// <summary>
        /// 获取指定枚举类型中每个枚举值的整数值及其对应的描述文本。
        /// </summary>
        /// <remarks>描述文本通过枚举值的 GetDescription 方法获取，通常来自 Description 特性。如果枚举值未定义描述，则使用枚举名称。</remarks>
        /// <param name="enumType">要获取描述和值的枚举类型。必须为枚举类型，且不能为空。</param>
        /// <returns>一个字典，其中键为枚举值的描述文本，值为对应的整数值。</returns>
        public static Dictionary<int, string> GetValueAndDescription(this Type enumType)
        {
            return Enum.GetValues(enumType).Cast<object>().ToDictionary(e => (int)e, e => ((Enum)e).GetDescription());
        }

        /// <summary>
        /// 获取指定枚举类型中每个枚举值的整数值及其对应的描述文本。
        /// </summary>
        /// <remarks>描述文本通过枚举值的 GetDescription 方法获取，通常来自 Description 特性。如果枚举值未定义描述，则使用枚举名称。</remarks>
        /// <param name="enumType">要获取描述和值的枚举类型。必须为枚举类型，且不能为空。</param>
        /// <returns>一个字典，其中键为枚举值的描述文本，值为对应的整数值。</returns>
        public static Dictionary<T, string> GetEnumAndDescription<T>(this Type enumType) where T : struct, Enum
        {
            return Enum.GetValues(enumType).Cast<object>().ToDictionary(e => (T)e, e => ((Enum)e).GetDescription());
        }

        /// <summary>
        /// 获取指定枚举类型中每个枚举值的整数值及其对应的描述文本。
        /// </summary>
        /// <remarks>描述文本通过枚举值的 GetDescription 方法获取，通常来自 Description 特性。如果枚举值未定义描述，则使用枚举名称。</remarks>
        /// <param name="enumType">要获取描述和值的枚举类型。必须为枚举类型，且不能为空。</param>
        /// <returns>一个字典，其中键为枚举值的描述文本，值为对应的整数值。</returns>
        public static Dictionary<string, T> GetDescriptionAndEnum<T>(this Type enumType) where T : struct, Enum
        {
            return Enum.GetValues(enumType).Cast<object>().ToDictionary(e => ((Enum)e).GetDescription(), e => (T)e);
        }

        #endregion

        private sealed record EnumMetadata(string Name, string Description);

        private static EnumMetadata GetEnumMetadata(Enum value)
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value) ?? value.ToString();

            return _enumMetadataCache.GetOrAdd((enumType, name), static key =>
            {
                var field = key.EnumType.GetField(key.Name, BindingFlags.Public | BindingFlags.Static);
                var description = field?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? key.Name;
                return new EnumMetadata(key.Name, description);
            });
        }
    }
}
