using Microsoft.VisualBasic;
using Newtonsoft.Json;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using System.ComponentModel;
using System.Reflection;

namespace PMS.Core.Infra.CrossCutting.Utilities;

public class TypeUtility
{
    #region Change
    public static TResult ChangeType<TResult>(dynamic? obj)
    {
        TResult? result = default;
        if (obj != null)
        {
            string str = JsonConvert.SerializeObject(obj);
            result = JsonConvert.DeserializeObject<TResult>(str);
        }
        return result ?? ReflectionUtility.Instantiate<TResult>();
    }

    public static object ChangeType(dynamic? obj, Type resultType)
    {
        object? result = default;
        if (obj != null)
        {
            string str = JsonConvert.SerializeObject(obj);
            result = JsonConvert.DeserializeObject(str, resultType);
        }
        return result ?? ReflectionUtility.Instantiate(resultType);
    }
    #endregion Change

    #region Convert
    public static TResult ConvertTo<TResult>(dynamic? obj)
    {
        TResult? result = default;
        if (obj != null)
        {
            if (!ConvertTo(obj, out result))
            {
                if (ReflectionUtility.IsInterfaceType<TResult>())
                    result = ((TResult)obj);
                else
                    result = ConvertTo(obj, obj.GetType());
            }
        }
        return result ?? ReflectionUtility.Instantiate<TResult>();
    }

    public static object ConvertTo(dynamic? obj, Type resultType)
    {
        object? result = null;
        if (obj != null)
        {
            var objType = obj.GetType();
            if (IsDate(obj))
                result = ConvertToDateTime(obj);
            else if (IsNullable(obj))
            {
                if (IsNullableValueType(resultType))
                {
                    var underlyingType = Nullable.GetUnderlyingType(resultType);
                    result = ChangeType(Convert.ChangeType(obj?.ToString(), underlyingType), resultType);
                }
                else if (resultType == typeof(Guid))
                    result = Guid.Parse(obj?.ToString());
                else
                    result = ChangeType(Convert.ChangeType(obj?.ToString(), resultType), resultType);
            }
            else if (IsBoolean(obj))
                result = ConvertToBoolean(obj);
            else if (resultType.IsAssignableFrom(objType))
            {
                if (resultType == typeof(Guid))
                    result = Guid.Parse(obj?.ToString());
                else
                    result = ChangeType(Convert.ChangeType(obj?.ToString(), resultType), resultType);
            }
        }
        return result ?? ReflectionUtility.Instantiate(resultType);
    }

    public static bool ConvertTo<T>(object convertingObject, out T value)
    {
        T? result = GetDefaultValueOfType<T>();
        bool converted = false;
        if (convertingObject != null)
        {
            try
            {
                if ((convertingObject is T) || Type.Equals(convertingObject.GetType(), typeof(T)))
                {
                    result = (T)convertingObject;
                    converted = true;
                }
                else
                {
                    if (IsEnumType<T>())
                    {
                        object? objResult;
                        Enum.TryParse(typeof(T), convertingObject?.ToString(), out objResult);
                        result = (objResult != null) ? (T?)objResult : GetDefaultValueOfType<T>();
                        converted = true;
                    }
                    else
                    {
                        TypeConverter converter = GetTypeConverter(convertingObject.GetType());
                        if (converter != null)
                        {
                            Type convertingType = convertingObject.GetType();
                            if (converter.CanConvertFrom(convertingType))
                            {
                                bool isBooleanConverter = Type.Equals(converter.GetType(), typeof(BooleanConverter));
                                if (isBooleanConverter && Type.Equals(convertingType, typeof(string)) && IsNumeric(convertingObject))
                                    result = ConvertTo<T>(Convert.ToBoolean(Convert.ToInt32(convertingObject)));
                                else
                                    result = ((T)(converter.ConvertFrom(convertingObject) ?? new { }));
                                converted = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        value = result ?? ReflectionUtility.Instantiate<T>();
        return converted;
    }

    public static bool ConvertToBoolean(object? expression)
    {
        bool value = false;
        if (expression != null)
        {
            if (Information.IsNumeric(expression))
            {
                int convertedValue = ConvertToInteger(expression);
                if (convertedValue.IsBetween(0, 1))
                    value = Convert.ToBoolean(convertedValue);
            }
            else
                bool.TryParse(expression.ToString(), out value);
        }
        return value;
    }

    public static DateTime ConvertToDateTime(object? expression)
    {
        DateTime d;
        DateTime.TryParse((expression ?? string.Empty).ToString(), out d);
        return d;
    }

    public static decimal ConvertToDecimal(object? expression)
    {
        decimal d;
        decimal.TryParse((expression ?? string.Empty).ToString(), out d);
        return d;
    }

    public static int ConvertToInteger(object? expression)
    {
        int value = default;
        if (expression != null)
        {
            if (expression is Enum)
                value = ((int)expression);
            else if (Information.IsNumeric(expression))
                int.TryParse(expression?.ToString() ?? string.Empty, out value);
            else if (IsBoolean(expression))
                value = Convert.ToBoolean(expression) ? 1 : 0;
            else
            {
                string str = expression?.ToString() ?? string.Empty;
                bool parsed = int.TryParse(str, out value);
                if (!parsed)
                {
                    string strHex = str.Replace(TextUtility.HexBeginning, string.Empty).Trim();
                    if (ValidationUtility.ValidateHexadecimal(strHex))
                        value = int.Parse(strHex, System.Globalization.NumberStyles.HexNumber);
                }
            }
        }
        return value;
    }

    public static int? ConvertToNullableOfInteger(string? str)
    {
        int? nullable;
        if (!string.IsNullOrWhiteSpace(str))
        {
            int value;
            int.TryParse(str.Trim(), out value);
            nullable = value;
        }
        else
            nullable = null;
        return nullable;
    }

    public static string? ConvertToString(object obj)
    {
        return obj?.ToString();
    }
    #endregion Convert

    #region Get
    public static Type? GetCollectionElementType(Type type)
    {
        if (type != null)
        {
            var typeInterfaces = type.GetInterfaces();

            var eType = typeof(IEnumerable<>);
            foreach (var currentInterface in typeInterfaces)
            {
                if (currentInterface.IsGenericType && (currentInterface.GetGenericTypeDefinition() == eType))
                    return currentInterface.GetGenericArguments()[0];
            }

            if (typeof(System.Collections.IDictionary).IsAssignableFrom(type))
                return typeof(System.Collections.DictionaryEntry);

            var objectType = typeof(object);
            var typeProperties = type.GetProperties();
            if (typeof(System.Collections.IList).IsAssignableFrom(type))
            {
                string itemDescription = "Item";
                var integerType = typeof(int);
                foreach (var currentProperty in typeProperties)
                {
                    if ((currentProperty.Name == itemDescription) && (currentProperty.PropertyType != objectType))
                    {
                        var indexParameters = currentProperty.GetIndexParameters();
                        if ((indexParameters.Length == 1) && (indexParameters[0].ParameterType == integerType))
                            return currentProperty.PropertyType;
                    }
                }
            }

            if (typeof(System.Collections.ICollection).IsAssignableFrom(type))
            {
                string addMethodName = "Add";
                var typeMethods = type.GetMethods();
                foreach (var currentMethod in typeMethods)
                {
                    if (currentMethod.Name == addMethodName)
                    {
                        var currentMethodParameters = currentMethod.GetParameters();
                        if ((currentMethodParameters.Length == 1) && (currentMethodParameters[0].ParameterType != objectType))
                            return currentMethodParameters[0].ParameterType;
                    }
                }
            }

            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
                return objectType;
        }
        return null;
    }

    public static T? GetDefaultValueOfType<T>()
    {
        return default(T);
    }

    public static object? GetDefaultValueOfType(Type valuingType)
    {
        if ((valuingType != null) && valuingType.IsValueType)
            return ReflectionUtility.Instantiate(valuingType);
        else
            return null;
    }

    public static TypeConverter GetTypeConverter<T>()
    {
        return GetTypeConverter(typeof(T));
    }

    public static TypeConverter GetTypeConverter(Type converterOwner)
    {
        return TypeDescriptor.GetConverter(converterOwner);
    }
    #endregion Get

    #region Is
    public static bool IsBoolean(object? obj)
    {
        string[] possibleStringValues = new string[] { true.ToString().ToLower(), false.ToString().ToLower(), 0.ToString(), 1.ToString() };
        bool isBoolean = (obj != null) && (!string.IsNullOrWhiteSpace(obj.ToString()));
        isBoolean = isBoolean && ((obj is bool) || (!IsNumeric(obj)) || ConvertToDecimal(obj).IsBetween(0, 1) || possibleStringValues.Contains(obj?.ToString()?.Trim().ToLower() ?? string.Empty));
        return isBoolean;
    }

    public static bool IsCollectionType<T>()
    {
        return IsCollectionType(typeof(T));
    }

    public static bool IsCollectionType(Type type)
    {
        if (type != null)
        {
            if (typeof(System.Collections.ICollection).IsAssignableFrom(type))
                return true;
            foreach (var i in type.GetInterfaces())
            {
                if (i.IsGenericType && typeof(ICollection<>) == i.GetGenericTypeDefinition())
                    return true;
            }
        }
        return false;
    }

    public static bool IsDate(object obj)
    {
        return Information.IsDate(obj);
    }

    public static bool IsEnumerableType<T>()
    {
        return IsEnumerableType(typeof(T));
    }

    public static bool IsEnumerableType(Type type)
    {
        if (type != null)
        {
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
                return true;
            foreach (var i in type.GetInterfaces())
            {
                if (i.IsGenericType && typeof(IEnumerable<>) == i.GetGenericTypeDefinition())
                    return true;
            }
        }
        return false;
    }

    public static bool IsEnumType<T>()
    {
        return typeof(T).IsEnum;
    }

    public static bool IsListType<T>()
    {
        return IsListType(typeof(T));
    }

    public static bool IsListType(Type type)
    {
        if (type != null)
        {
            if (typeof(System.Collections.IList).IsAssignableFrom(type))
                return true;
            foreach (var i in type.GetInterfaces())
            {
                if (i.IsGenericType && typeof(IList<>) == i.GetGenericTypeDefinition())
                    return true;
            }
        }
        return false;
    }

    public static bool IsNullable(object obj)
    {
        if (obj != null)
            return IsNullableType(obj.GetType());
        else
            return true;
    }

    public static bool IsNullableType(Type nullableType)
    {
        return ((nullableType != null) && nullableType.IsGenericType && Type.Equals(nullableType.GetGenericTypeDefinition(), typeof(Nullable<>)));
    }

    public static bool IsNullableValueType<TNullable>()
    {
        return IsNullableValueType(typeof(TNullable));
    }

    public static bool IsNullableValueType(Type nullableType)
    {
        return (IsNullableType(nullableType) && nullableType.IsValueType && (Nullable.GetUnderlyingType(nullableType) != null));
    }

    public static bool IsNumeric(object? obj)
    {
        return Information.IsNumeric(obj);
    }

    public static bool IsSetByDefault<T>(T obj)
    {
        return object.Equals(obj, default(T));
    }
    #endregion Is
}
