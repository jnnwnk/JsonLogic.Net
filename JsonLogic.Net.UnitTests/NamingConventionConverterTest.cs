using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonLogic.Net.UnitTests
{
    public class NamingConventionConverterTest
    {
        [Fact]
        public void Convert_CamelCaseToPascalCase()
        {
            var input = "camelCase";

            var converter = new NamingConventionConverter(NamingConventionEnum.CamelCase, NamingConventionEnum.PascalCase);

            var expected = "CamelCase";
            var actual = converter.Convert(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Convert_PascalCaseToCamelCase()
        {
            var input = "PascalCase";

            var converter = new NamingConventionConverter(NamingConventionEnum.PascalCase, NamingConventionEnum.CamelCase);

            var expected = "pascalCase";
            var actual = converter.Convert(input);

            Assert.Equal(expected, actual);
        }
    }
}
