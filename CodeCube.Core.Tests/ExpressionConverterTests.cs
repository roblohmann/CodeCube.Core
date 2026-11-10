using System;
using System.Linq.Expressions;
using CodeCube.Core.Expressions;
using Xunit;

namespace CodeCube.Core.Tests
{
    public class ExpressionConverterTests
    {
        private class Entity
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
        }

        private class Dto
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
        }

        [Fact]
        public void Convert_RebindsMemberAccessToNewType()
        {
            Expression<Func<Dto, bool>> dtoFilter = d => d.Age > 18 && d.Name == "Rob";

            var entityFilter = ExpressionConverter<Entity>.Convert(dtoFilter).Compile();

            Assert.True(entityFilter(new Entity { Name = "Rob", Age = 30 }));
            Assert.False(entityFilter(new Entity { Name = "Rob", Age = 10 }));
            Assert.False(entityFilter(new Entity { Name = "Other", Age = 30 }));
        }

        [Fact]
        public void Convert_ProducesExpressionForNewParameterType()
        {
            Expression<Func<Dto, int>> select = d => d.Age;

            var converted = ExpressionConverter<Entity>.Convert(select);

            Assert.Equal(typeof(Entity), converted.Parameters[0].Type);
            Assert.Equal(7, converted.Compile()(new Entity { Age = 7 }));
        }
    }
}
