using Phonebook.DAL;
using Phonebook.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Phonebook
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IRepository<HandbookRecord>, HandbookRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}