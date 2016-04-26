using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace LKSapi
{
    public class DependencyResolver:IDependencyResolver
    {
        protected IUnityContainer container;

        public DependencyResolver(IUnityContainer container)
        {
            if(container==null)
            {
                throw new ArgumentNullException("UnityContainer");
            }
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            IUnityContainer child = container.CreateChildContainer();
            return new DependencyResolver(child);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch(ResolutionFailedException ex)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch(ResolutionFailedException ex)
            {
                return new List<Object>();
            }
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}