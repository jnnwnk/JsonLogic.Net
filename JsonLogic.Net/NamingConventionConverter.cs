using System;
using System.Collections.Generic;
using System.Text;

namespace JsonLogic.Net
{
    public class NamingConventionConverter : INamingConventionConverter
    {
        private readonly NamingConventionEnum sourceNamingConvention;
        private readonly NamingConventionEnum targetNamingConvention;

        public NamingConventionConverter(NamingConventionEnum sourceNamingConvention, NamingConventionEnum targetNamingConvention)
        {
            this.sourceNamingConvention = sourceNamingConvention;
            this.targetNamingConvention = targetNamingConvention;
        }

        public string Convert(string input)
        {
            if (sourceNamingConvention == NamingConventionEnum.CamelCase && targetNamingConvention == NamingConventionEnum.PascalCase)
            {
                return ConvertCamelCaseToPascalCase(input);
            }
            if (sourceNamingConvention == NamingConventionEnum.PascalCase && targetNamingConvention == NamingConventionEnum.CamelCase)
            {
                return ConvertPascalCaseToCamel(input);
            }

            return input;
        }

        private string ConvertCamelCaseToPascalCase(string input)
        {
            if (input == null)
            {
                return input;
            }
            if (input.Length == 1)
            {
                return input.ToUpper();
            }

            return input.Substring(0, 1).ToUpper() + input.Substring(1);
        }

        private string ConvertPascalCaseToCamel(string input)
        {
            if (input == null)
            {
                return input;
            }
            if (input.Length == 1)
            {
                return input.ToLower();
            }

            return input.Substring(0, 1).ToLower() + input.Substring(1);
        }
    }
}
