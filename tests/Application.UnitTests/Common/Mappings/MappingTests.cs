using AutoMapper;
using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Mappings;
using Clean_Architecture_Asp_Net_Core_Starter.Application.TodoLists.Queries.GetTodos;
using Clean_Architecture_Asp_Net_Core_Starter.Domain.Entities;
using NUnit.Framework;
using System;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        
        [Test]
        [TestCase(typeof(TodoList), typeof(TodoListDto))]
        [TestCase(typeof(TodoItem), typeof(TodoItemDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
