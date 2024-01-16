using IOCFrameWork.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOCFrameWork.Core
{
    static public class IocContainer
    {
        static Dictionary<Type, Dictionary<string, INodeType>> _dic = new Dictionary<Type, Dictionary<string, INodeType>>(16);

        static Dictionary<Type, Type> _IocDic = new Dictionary<Type, Type>(16);

        public static void Register<InterfaceType, InterfaceClass>()
        {
            if (_IocDic.ContainsKey(typeof(InterfaceType)))
            {
                throw new Exception();
            }
            else
            {
                _IocDic.Add(typeof(InterfaceType), typeof(InterfaceClass));
            }
        }

        public static T Reslove<T>()
        {
            return (T)Reslove(typeof(T));
        }
        public static object Reslove(Type interfaceType)
        {
            if (!_IocDic.ContainsKey(interfaceType))
            {
                throw new Exception();
            }
            Type interfaceClass = _IocDic[interfaceType];
            ConstructorInfo constructorInfo = interfaceClass.GetConstructors().First();
            List<ParameterInfo> parameterInfos = constructorInfo.GetParameters().ToList();
            List<object> interfaceClassParameters = new List<object>();
            foreach (ParameterInfo parameter in parameterInfos)
            {
                if (parameter.GetCustomAttribute(typeof(AutoAttribute)) != null)
                {
                }
                if (parameter.GetCustomAttribute(typeof(URLAttribute)) != null)
                {
                }
                Type temp = parameter.ParameterType;
                object result = Reslove(temp);
                interfaceClassParameters.Add(result);
            }
            object resultObj = constructorInfo?.Invoke(interfaceClassParameters.ToArray());
            return resultObj;
        }

        public static void Register<T, V>(string name, INodeType nodeType) where V : class, T, new()
        {

        }






        /// <summary>
        /// 一般节点类型
        /// </summary>
        public interface INodeType
        {
        }
        public class NormalType<T> : INodeType
        {
            private Type _type;
            public NormalType(T type)
            {

            }
        }
        public class SingletonType
        {
            private Type _type;
            private object _obj;

            public SingletonType()
            {

            }

        }
    }
}
