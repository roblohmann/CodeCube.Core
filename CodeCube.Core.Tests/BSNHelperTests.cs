using System;
using System.Collections.Generic;
using System.Text;
using CodeCube.Core.Helpers;
using Xunit;

namespace CodeCube.Core.Tests
{
    public class BSNHelperTests
    {
        [Fact]
        public void TestValidDutchSocialSecurityNumber_Length9()
        {
            //Setup
            const string bsn = "169062582"; //BSN Generated on testnummers.nl

            //Act
            bool isValidBsn = BSNHelper.Elfproef(bsn);

            //Assert
            Assert.True(isValidBsn);
        }

        [Fact]
        public void TestValidDutchSocialSecurityNumber_Length9_WithLeadingZero()
        {
            //Setup
            const string bsn = "019729212"; //BSN Generated on testnummers.nl

            //Act
            bool isValidBsn = BSNHelper.Elfproef(bsn);

            //Assert
            Assert.True(isValidBsn);
        }

        [Fact]
        public void TestValidDutchSocialSecurityNumber_Length8()
        {
            //Setup
            const string bsn = "74639201"; //BSN Generated on testnummers.nl

            //Act
            bool isValidBsn = BSNHelper.Elfproef(bsn);

            //Assert
            Assert.True(isValidBsn);
        }

        [Fact]
        public void TestInValidDutchSocialSecurityNumber_EmptyString()
        {
            //Setup
            const string bsn = ""; //BSN Generated on testnummers.nl

            //Act
            bool isValidBsn = BSNHelper.Elfproef(bsn);

            //Assert
            Assert.False(isValidBsn);
        }

        [Fact]
        public void TestInValidDutchSocialSecurityNumber_SpaceOnly()
        {
            //Setup
            const string bsn = " "; //BSN Generated on testnummers.nl

            //Act
            bool isValidBsn = BSNHelper.Elfproef(bsn);

            //Assert
            Assert.False(isValidBsn);
        }

        [Fact]
        public void TestInValidDutchSocialSecurityNumber()
        {
            //Setup
            const string bsn = "12345678"; //BSN Generated on testnummers.nl

            //Act
            bool isValidBsn = BSNHelper.Elfproef(bsn);

            //Assert
            Assert.False(isValidBsn);
        }

        [Fact]
        public void TestInValidDutchSocialSecurityNumber_WithSpace()
        {
            //Setup
            const string bsn = "1234 678"; //BSN Generated on testnummers.nl

            //Act
            bool isValidBsn = BSNHelper.Elfproef(bsn);

            //Assert
            Assert.False(isValidBsn);
        }
    }
}
