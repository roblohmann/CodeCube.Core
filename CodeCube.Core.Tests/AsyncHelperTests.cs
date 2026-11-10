using System;
using System.Threading.Tasks;
using CodeCube.Core.Helpers;
using Xunit;

namespace CodeCube.Core.Tests
{
    public class AsyncHelperTests
    {
        [Fact]
        public void RunSync_ReturnsResultOfAsyncFunction()
        {
            var result = AsyncHelper.RunSync(async () =>
            {
                await Task.Delay(10);
                return 42;
            });

            Assert.Equal(42, result);
        }

        [Fact]
        public void RunSync_WithoutResult_AwaitsCompletion()
        {
            var done = false;

            AsyncHelper.RunSync(async () =>
            {
                await Task.Delay(10);
                done = true;
            });

            Assert.True(done);
        }

        [Fact]
        public void RunSync_PropagatesOriginalException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                AsyncHelper.RunSync<int>(() => throw new InvalidOperationException("boom")));
        }
    }
}
