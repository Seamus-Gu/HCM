using Framework.Core;
using System.Reflection;

namespace Framework.DI
{
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// 初始化Autofac,注入Repository 和 Service
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblyName">程序集</param>
        public static void InitAutofac(this ContainerBuilder builder)
        {
            var asm = Assembly.GetEntryAssembly()!;

            var assemblyList = AppDomain.CurrentDomain.GetAssemblies()
                .Where(t => t.FullName != null && t.FullName.Contains(FrameworkConstant.FRAMEWORK_PREFIX));

            builder.RegisterAssemblyTypes(assemblyList.ToArray())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => t.IsAssignableTo<IRepository>())
                .AsSelf().AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(assemblyList.ToArray())
              .Where(t => t.IsClass && !t.IsAbstract)
              .Where(t => t.Name.EndsWith(FrameworkConstant.SERVICE))
              .AsSelf().AsImplementedInterfaces()
              .InstancePerDependency();

            // 注册Job所有接口
            builder.RegisterAssemblyTypes(assemblyList.ToArray())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => t.IsAssignableTo<IJobService>())
                //.Where(t => t.GetInterfaces().Contains(typeof(IJobService)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}