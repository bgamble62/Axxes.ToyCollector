﻿using System.Threading.Tasks;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Axxes.ToyCollector.Core.Contracts.Repositories;
using Axxes.ToyCollector.Core.Contracts.Services;
using Axxes.ToyCollector.Core.Models;

namespace Axxes.ToyCollector.Core.Logic.Services
{
    public class ToyCreator : IToyCreator
    {
        private readonly IToyRepository _repository;
        private readonly IScopedServiceLocator _serviceLocator;

        public ToyCreator(IToyRepository repository, IScopedServiceLocator serviceLocator)
        {
            _repository = repository;
            _serviceLocator = serviceLocator;
        }

        public async Task CreateToy(Toy toy)
        {
            await _repository.Create(toy);

            if (toy.GetType() != typeof(Toy))
            {
                RunCustomLogic(toy);
            }
        }

        private void RunCustomLogic(Toy toy)
        {
            var toyType = toy.GetType();

            var creatorInterfaceType = typeof(IToyCreatorCustomLogic<>);
            var genericInterfaceType = creatorInterfaceType.MakeGenericType(toyType);

            var creator = (IToyCreatorCustomLogic)_serviceLocator.Resolve(genericInterfaceType);

            creator.Execute(toy);
        }
    }
}
