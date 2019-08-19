using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;


namespace GraphTraverse
{
    public static class ContainerConfig
    {

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //register types for dependency injection
            builder.RegisterType<Node>().As<INode>();
            builder.RegisterType<GraphGenerator>().As<IGraphGeneratorFromFile>();

            return builder.Build();
        }
    }
}
