using System.Collections.Generic;

namespace Privesc3.Check
{
    public class ArgumentParserResult
    {
        public bool ParsedOk { get; }
        public Dictionary<string, string> Arguments { get; }

        private ArgumentParserResult(bool parsedOk, Dictionary<string, string> arguments)
        {
            ParsedOk = parsedOk;
            Arguments = arguments;
        }

        public static ArgumentParserResult Success(Dictionary<string, string> arguments)
            => new ArgumentParserResult(true, arguments);

        public static ArgumentParserResult Failure()
            => new ArgumentParserResult(false, null);

    }
}