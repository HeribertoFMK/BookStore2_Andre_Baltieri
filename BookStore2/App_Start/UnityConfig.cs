using BookStore2.Content;
using BookStore2.Repository;
using BookStore2.Repository.Contracts;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BookStore2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<BookStoreDataContext, BookStoreDataContext>();
            container.RegisterType<IAuthorsRepository, AuthorRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}