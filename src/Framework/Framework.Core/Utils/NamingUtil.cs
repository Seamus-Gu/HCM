using System.Globalization;
using System.Text;

namespace Framework.Core
{
    /// <summary>
    /// Provides utility methods for converting strings between common naming conventions such as snake_case, camelCase,
    /// PascalCase, and kebab-case.
    /// </summary>
    /// <remarks>Use this class to standardize string identifiers across different naming styles required by
    /// various systems, such as databases, programming languages, or web technologies. All methods handle null or
    /// whitespace input by returning an empty string. Culture-specific casing rules are applied where appropriate. This
    /// class is static and cannot be instantiated.</remarks>
    public class NamingUtil
    {
        /// <summary>
        /// Converts a string from snake_case format to camelCase format.
        /// </summary>
        /// <remarks>The first word is converted to lowercase, and subsequent words are capitalized.
        /// Delimiters are defined by DelimitersConstant.UNDERSCORE.</remarks>
        /// <param name="snakeCase">The input string in snake_case format to convert. Cannot be null or whitespace.</param>
        /// <returns>A string converted to camelCase format. Returns an empty string if the input is null or whitespace.</returns>
        public static string SnakeCaseToCamelCase(string snakeCase)
        {
            if (string.IsNullOrWhiteSpace(snakeCase))
            {
                return string.Empty;
            }

            var words = snakeCase.Split(DelimitersConstant.UNDERSCORE);
            words[0] = words[0].ToLower();

            for (int i = 1; i < words.Length; i++)
            {
                words[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i].ToLower());
            }

            return string.Concat(words);
        }

        /// <summary>
        /// Converts a string from snake_case format to PascalCase format.
        /// </summary>
        /// <remarks>Each word separated by underscores in the input is capitalized and concatenated
        /// without delimiters. Culture-specific casing rules are applied based on the current culture.</remarks>
        /// <param name="snakeCase">The input string in snake_case format to convert. Cannot be null or whitespace.</param>
        /// <returns>A string converted to PascalCase. Returns an empty string if the input is null, empty, or consists only of
        /// whitespace.</returns>
        public static string SnakeCaseToPascal(string snakeCase)
        {
            if (string.IsNullOrWhiteSpace(snakeCase))
            {
                return string.Empty;
            }

            var words = snakeCase.Split(DelimitersConstant.UNDERSCORE, StringSplitOptions.RemoveEmptyEntries);
            var stringBuilder = new StringBuilder();

            foreach (var word in words)
            {
                if (word.Length == 0)
                {
                    continue;
                }

                var lowerWord = word.ToLower(CultureInfo.CurrentCulture);
                var pascalWord = char.ToUpper(lowerWord[0], CultureInfo.CurrentCulture)
                    + (lowerWord.Length > 1 ? lowerWord[1..] : string.Empty);

                stringBuilder.Append(pascalWord);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts a string from snake_case format to kebab-case format.
        /// </summary>
        /// <param name="snakeCase">The input string in snake_case format to convert. Can be null or empty.</param>
        /// <returns>A string converted to kebab-case format. Returns an empty string if the input is null, empty, or consists
        /// only of white-space characters.</returns>
        public static string SnakeCaseToKebabCase(string snakeCase)
        {
            if (string.IsNullOrWhiteSpace(snakeCase))
            {
                return string.Empty;
            }

            return snakeCase.ToLower().Replace(DelimitersConstant.UNDERSCORE.First(), DelimitersConstant.DASH.First());
        }

        /// <summary>
        /// Converts a string from camelCase format to snake_case format.
        /// </summary>
        /// <remarks>This method inserts underscores before uppercase letters (except the first character)
        /// and converts all characters to lowercase. Use this method to generate identifiers compatible with systems
        /// that require snake_case naming.</remarks>
        /// <param name="camelCase">The camelCase string to convert. Cannot be null or whitespace.</param>
        /// <returns>A string in snake_case format representing the input. Returns an empty string if the input is null or
        /// whitespace.</returns>
        public static string CamelCaseToSnakeCase(string camelCase)
        {
            if (string.IsNullOrWhiteSpace(camelCase))
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < camelCase.Length; i++)
            {
                if (char.IsUpper(camelCase[i]) && i > 0)
                {
                    stringBuilder.Append(DelimitersConstant.UNDERSCORE);
                }
                stringBuilder.Append(char.ToLower(camelCase[i]));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts a camelCase string to kebab-case format.
        /// </summary>
        /// <remarks>This method inserts a hyphen before each uppercase letter (except the first
        /// character) and converts all characters to lowercase. Useful for formatting identifiers for URLs or CSS class
        /// names.</remarks>
        /// <param name="camelCase">The input string in camelCase format to convert. Cannot be null or whitespace.</param>
        /// <returns>A kebab-case representation of the input string. Returns an empty string if the input is null or whitespace.</returns>
        public static string CamelCaseToKebabCase(string camelCase)
        {
            if (string.IsNullOrWhiteSpace(camelCase))
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < camelCase.Length; i++)
            {
                if (char.IsUpper(camelCase[i]) && i > 0)
                {
                    stringBuilder.Append('-');
                }
                stringBuilder.Append(char.ToLower(camelCase[i]));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts a string from kebab-case to snake_case format.
        /// </summary>
        /// <param name="kebabCase">The input string in kebab-case format to convert. Can be null or empty.</param>
        /// <returns>A string converted to snake_case format. Returns an empty string if the input is null, empty, or consists
        /// only of white-space characters.</returns>
        public static string KebabCaseToSnakeCase(string kebabCase)
        {
            if (string.IsNullOrWhiteSpace(kebabCase))
            {
                return string.Empty;
            }

            return kebabCase.ToLower().Replace(DelimitersConstant.DASH.First(), DelimitersConstant.UNDERSCORE.First());
        }
    }
}
