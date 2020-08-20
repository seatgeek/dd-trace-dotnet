using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using Datadog.Trace.Logging;

namespace Datadog.Trace.ClrProfiler.CallTarget.DuckTyping
{
    /// <summary>
    /// Duck Type
    /// </summary>
    public partial class DuckType
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly Vendors.Serilog.ILogger Log = DatadogLogging.GetLogger(typeof(DuckType));
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly object _locker = new object();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly Type[] DefaultInterfaceTypes = new[] { typeof(IDuckType) };
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly Dictionary<VTuple<Type, Type>, Type> DuckTypeCache = new Dictionary<VTuple<Type, Type>, Type>();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ConcurrentBag<DynamicMethod> DynamicMethods = new ConcurrentBag<DynamicMethod>();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ConcurrentDictionary<VTuple<string, TypeBuilder>, FieldInfo> DynamicFields = new ConcurrentDictionary<VTuple<string, TypeBuilder>, FieldInfo>();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly MethodInfo DuckTypeCreateMethodInfo = typeof(DuckType).GetMethod(nameof(DuckType.Create), BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(Type), typeof(object) }, null);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly MethodInfo GetInnerDuckTypeMethodInfo = typeof(DuckType).GetMethod(nameof(GetInnerDuckType), BindingFlags.Static | BindingFlags.Public);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly MethodInfo SetInnerDuckTypeMethodInfo = typeof(DuckType).GetMethod(nameof(SetInnerDuckType), BindingFlags.Static | BindingFlags.Public);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static ModuleBuilder _moduleBuilder = null;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static Func<DynamicMethod, RuntimeMethodHandle> _dynamicGetMethodDescriptor;

        private static RuntimeMethodHandle GetRuntimeHandle(DynamicMethod dynamicMethod)
        {
            _dynamicGetMethodDescriptor ??= (Func<DynamicMethod, RuntimeMethodHandle>)typeof(DynamicMethod)
                .GetMethod("GetMethodDescriptor", BindingFlags.NonPublic | BindingFlags.Instance)
                .CreateDelegate(typeof(Func<DynamicMethod, RuntimeMethodHandle>));
            return _dynamicGetMethodDescriptor(dynamicMethod);
        }
    }
}
