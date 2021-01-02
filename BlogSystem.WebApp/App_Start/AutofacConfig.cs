using Autofac;
using Autofac.Integration.Mvc;
using BlogSystem.BLL;
using BlogSystem.DAL;
using BlogSystem.IBLL;
using BlogSystem.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.WebApp.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            //配置autofac的基本信息
            //(1)创建容器
            var builder = new ContainerBuilder();
            //(2)进行依赖注入的注册
            builder.RegisterType<RolesDal>().As<IRolesDal>();
            builder.RegisterType<RolesBLL>().As<IRolesBll>();
            //(3)注册控制器
            builder.RegisterControllers(typeof(AutofacConfig).Assembly);
            //(4)构建
            var container = builder.Build();
            //(5)实现
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}