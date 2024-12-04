using System.Collections;
using System.Reflection;

namespace PMS.Core.Infra.CrossCutting.Utilities;

public class ReflectionUtility
{
    #region Constants
    const string BeginnningOfSystemNamespace = "System.";
    #endregion Constants

    #region Methods

    #region Copy
    public static void CopyData<TFrom, TTo>(TFrom from, TTo to)
    {
        if ((from != null) && (to != null))
        {
            var fromProperties = from.GetType().GetProperties();
            var toProperties = to.GetType().GetProperties();
            foreach (var currentFromProperty in fromProperties )
            {
                if (!IsCollectionProperty(currentFromProperty))
                {
                    var currentToProperty = toProperties.FirstOrDefault(p => p.Name == currentFromProperty.Name);
                    if (( currentToProperty != null) && currentToProperty.CanWrite && IsPropertyTypeNative(currentToProperty.PropertyType))
                    {
                        var valueFrom = currentFromProperty.GetValue(from);
                        var valueTo = currentToProperty.GetValue(to);
                        if (!object.Equals(valueFrom, valueTo))
                            currentToProperty.SetValue(to, valueFrom);
                    }
                }
            }
        }
    }

    public static void CopyTo<T>(T from, T to)
    {
        if ((from != null) && (to != null))
        {
            var properties = from.GetType().GetProperties();
            foreach (var currentProperty in properties)
            {
                if (currentProperty.CanWrite && IsPropertyTypeNative(currentProperty.PropertyType) && (!IsCollectionProperty(currentProperty)))
                {
                    var valueFrom = currentProperty.GetValue(from);
                    var valueTo = currentProperty.GetValue(to);
                    if (!object.Equals(valueFrom, valueTo))
                        currentProperty.SetValue(to, valueFrom);
                }
            }
        }
    }
    #endregion Copy

    #region Get
    public static PropertyInfo[] GetCollectionProperties<T>()
    {
        var properties = GetProperties<T>();
        var collectionProperties = new List<PropertyInfo>(properties.Length);
        foreach (var currentProperty in properties)
        {
            if (IsCollectionProperty(currentProperty))
                collectionProperties.Add(currentProperty);        
        }
        return collectionProperties.ToArray();
    }

    public static FieldInfo? GetConstant<T>(string name)
    {
        return GetConstant(typeof(T), name);
    }

    public static object? GetConstantValue<T>(string name)
    {
        var constant = GetConstant(typeof(T), name);
        return constant?.GetValue(null);
    }

    public static FieldInfo? GetConstant(Type type, string name)
    {
        string strName = (name ?? string.Empty).Trim().ToLower();
        FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        return fieldInfos.FirstOrDefault(fi => fi.IsLiteral && (!fi.IsInitOnly) && fi.Name.ToLower() == strName);
    }

    public static FieldInfo[] GetConstants(Type type)
    {
        ArrayList constants = new ArrayList();
        FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        foreach (FieldInfo fi in fieldInfos)
        {
            if (fi.IsLiteral && (!fi.IsInitOnly))
                constants.Add(fi);
        }
        return (FieldInfo[])constants.ToArray(typeof(FieldInfo));
    }

    public static FieldInfo? GetField<T>(string fieldName)
    {
        var type = typeof(T);
        return GetField(type, fieldName);
    }

    public static FieldInfo? GetField(Type type, string fieldName)
    {
        if ((type != null) && (!string.IsNullOrWhiteSpace(fieldName)))
            return type.GetField(fieldName);
        else
            return null;
    }

    public static PropertyInfo[] GetProperties<T>()
    {
        Type type = typeof(T);
        return type.GetProperties();
    }

    public static PropertyInfo GetProperty<T>(string? propertyName)
    {
        var type = typeof(T);
        return GetProperty(type, propertyName);
    }

    public static PropertyInfo? GetProperty(object? obj, string propertyName)
    {
        Type objType = obj?.GetType() ?? typeof(object);
        return GetProperty(objType, propertyName);
    }

    public static PropertyInfo GetProperty(Type type, string? propertyName)
    {
        if ((type != null) && (!string.IsNullOrWhiteSpace(propertyName)))
        {
            var propName = propertyName.Trim();
            var property = type.GetProperty(propName) ?? type.GetRuntimeProperty(propName);
            if (property == null)
            {
                IEnumerable<PropertyInfo> properties = type.GetRuntimeProperties();
                foreach (PropertyInfo currentProperty in properties)
                {
                    if (currentProperty.Name == propName)
                    {
                        property = currentProperty;
                        break;
                    }
                }
            }
#pragma warning disable CS8603 // Possible null reference return.
            return property;
#pragma warning restore CS8603 // Possible null reference return.
        }
        else
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
    }
    #endregion Get

    #region Has
    public static bool HasAttribute<TType, TAttribute>()
        where TAttribute : Attribute
    {
        Type type = typeof(TType);
        return HasAttribute<TAttribute>(type);
    }

    public static bool HasAttribute<TAttribute>(Type type)
        where TAttribute : Attribute
    {
        return (type.GetCustomAttribute<TAttribute>() != null);
    }
    #endregion Has

    #region Inherits
    public static bool InheritsFrom<T>(object obj)
    {
        bool inherits = false;
        if (obj != null)
            inherits = obj.GetType().IsSubclassOf(typeof(T));
        return inherits;
    }
    #endregion Inherits

    #region Instantiate
    public static T Instantiate<T>()
    {
        return Activator.CreateInstance<T>();
    }

    public static object Instantiate(Type type)
    {
        return Activator.CreateInstance(type ?? typeof(object)) ?? new { };
    }

    public static T InstantiateWithParameters<T>(params object[] args)
    {
        var instance = (T?)Activator.CreateInstance(type: typeof(T), args: args);
        return (instance ?? Instantiate<T>());
    }
    #endregion Instantiate

    #region Is
    public static bool IsCollection(object instance)
    {
        if (instance != null)
            return IsCollectionType(instance.GetType());
        else
            return false;
    }

    public static bool IsCollectionProperty(PropertyInfo property)
    {
        return IsListType(property.PropertyType) || IsEnumerableType(property.PropertyType) || IsCollectionType(property.PropertyType);
    }

    public static bool IsCollectionType<T>()
    {
        return IsCollectionType(typeof(T));
    }

    public static bool IsCollectionType(Type type)
    {
        var typeOfCollection = typeof(ICollection<>);
        bool isCollection;
        if (type != null)
            isCollection = (typeOfCollection.IsAssignableFrom(type) || typeOfCollection.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == type));
        else
            isCollection = false;
        return isCollection;
    }

    public static bool IsEnumerableType<T>()
    {
        return IsEnumerableType(typeof(T));
    }

    public static bool IsEnumerableType(Type type)
    {
        var typeOfEnumerable = typeof(IEnumerable<>);
        bool isEnumerable;
        if (type != null)
            isEnumerable = (typeOfEnumerable.IsAssignableFrom(type) || typeOfEnumerable.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == type));
        else
            isEnumerable = false;
        return isEnumerable;
    }

    public static bool IsInterfaceType<T>()
    {
        return IsInterfaceType(typeof(T));
    }

    public static bool IsInterfaceType(Type abstractionType)
    {
        return (abstractionType != null) && abstractionType.IsInterface;
    }

    public static bool IsListType<T>()
    {
        return IsListType(typeof(T));
    }

    public static bool IsListType(Type type)
    {
        var typeOfList = typeof(IList);
        if (type != null)
            return (typeOfList.IsAssignableFrom(type) || typeOfList.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == type));
        else
            return false;
    }

    public static bool IsNativeType(Type type)
    {
        return ((type != null) && (type.IsEnum || type.IsValueType || (type.IsClass && (type.FullName?.StartsWith(BeginnningOfSystemNamespace) ?? false))));
    }

    public static bool IsPropertyTypeNative(Type propertyType)
    {
        return ((propertyType != null) &&
                (propertyType.IsEnum || propertyType.IsValueType ||
                    (propertyType.IsClass && (propertyType.FullName?.StartsWith(BeginnningOfSystemNamespace) ?? false))));
    }
    #endregion Is

    #region Set
    public static void SetPropertyValue(PropertyInfo? property, object instance, object? value)
    {
        if ((property != null) && property.CanWrite && (instance != null) && property.PropertyType.IsAssignableFrom(value?.GetType() ?? typeof(object)))
            property.SetValue(instance, value);
    }

    public static void SetPropertyValueIfExists(string propertyName, object instance, object? value)
    {
        if ((instance != null) && (!string.IsNullOrWhiteSpace(propertyName)))
        {
            PropertyInfo? property = GetProperty(instance, propertyName);
            if (property != null)
                SetPropertyValue(property, instance, value);
        }
    }
    #endregion Set

    #endregion Methods
}
