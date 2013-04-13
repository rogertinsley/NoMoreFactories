using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using NoMoreFactories.ViewModels;

namespace NoMoreFactories.Controllers
{
    public class HomeController : Controller
    {
        private readonly Func<string, ICar> carFactory;

        public HomeController(Func<string, ICar> carFactory)
        {
            this.carFactory = carFactory;
        }

        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }

        public ActionResult Create(IndexViewModel indexViewModel)
        {
            ICar car = carFactory.Invoke(indexViewModel.SelectedId);

            return new ContentResult
                {
                    Content = car.CarName,
                };
        }
    }

    public interface ICarFactory
    {
        ICar Create(string carName);
    }

    public class CarFactory : ICarFactory
    {
        private readonly IUnityContainer unityContainer;

        public CarFactory(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        public ICar Create(string carName)
        {
            if (carName == "Ford") return unityContainer.Resolve<ICar>("Ford");
            if (carName == "Volkswagon") return unityContainer.Resolve<ICar>("Volkswagon");
            if (carName == "Peugeot") return unityContainer.Resolve<ICar>("Peugeot");

            throw new NotSupportedException();
        }
    }

    public interface ICar
    {
        string CarName { get; }
    }

    public class Ford : ICar
    {
        public string CarName
        {
            get { return "Ford"; }
        }
    }

    public class Volkswagon : ICar
    {
        public string CarName
        {
            get { return "Volkswagon"; }
        }
    }

    public class Peugeot : ICar
    {
        public string CarName
        {
            get { return "Peugeot"; }
        }
    }
}
