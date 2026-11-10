using System.Collections.Generic;
using System.Linq;
using CodeCube.Core.Expressions;
using Xunit;

namespace CodeCube.Core.Tests
{
    public class PredicateBuilderTests
    {
        [Fact]
        public void True_MatchesEverything()
        {
            Assert.True(PredicateBuilder.True<int>().Compile()(1));
        }

        [Fact]
        public void False_MatchesNothing()
        {
            Assert.False(PredicateBuilder.False<int>().Compile()(1));
        }

        [Theory]
        [InlineData(5, true)]
        [InlineData(15, false)]
        [InlineData(-1, false)]
        public void And_RequiresBothConditions(int value, bool expected)
        {
            var predicate = PredicateBuilder.True<int>()
                .And(x => x > 0)
                .And(x => x < 10);

            Assert.Equal(expected, predicate.Compile()(value));
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(100, true)]
        [InlineData(50, false)]
        public void Or_RequiresEitherCondition(int value, bool expected)
        {
            var predicate = PredicateBuilder.False<int>()
                .Or(x => x < 10)
                .Or(x => x > 90);

            Assert.Equal(expected, predicate.Compile()(value));
        }

        [Fact]
        public void Predicate_CanBeUsedAsQueryableFilter()
        {
            var source = new List<int> { 1, 5, 10, 50, 100 }.AsQueryable();
            var predicate = PredicateBuilder.False<int>().Or(x => x == 5).Or(x => x == 50);

            Assert.Equal(new[] { 5, 50 }, source.Where(predicate.Compile()).ToArray());
        }
    }
}
