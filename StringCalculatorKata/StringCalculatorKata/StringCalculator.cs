using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private List<String> defaultDelimiters = new List<String>() { ",", "\n" };
        private const Int32 DelimiterNotationOffset = 3;
        private const Int32 StringPrefixLength = 2;
        private const Int32 SingleDelimiterIndex = 2;
        private const Int32 MaxNumberAllowed = 1000;

        public Int32 Add(String numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                return 0;

            var delimiters = new List<String>();
            var extractedDelimiterInputFormat = "";
            
            if (CustomDelimiterIsUsed(numbers))
            {
                var delimitersLength = 0;
                extractedDelimiterInputFormat = numbers.Split(new String[] { "\n" }, StringSplitOptions.None)[0];

                if (MultipleDelimiter(numbers))
                {
                    delimiters = ParseCustomDelimitersToList(numbers);
                    foreach (var delimiterString in delimiters)
                        delimitersLength += delimiterString.Length + StringPrefixLength;
                }
                else
                {
                    defaultDelimiters.Add(extractedDelimiterInputFormat.Substring(2, extractedDelimiterInputFormat.Length - StringPrefixLength));
                    delimitersLength += defaultDelimiters.ElementAt(SingleDelimiterIndex).Length;
                }

                var beginningOfNumbersList = DelimiterNotationOffset + delimitersLength;
                var lengthOfNumbersList = numbers.Length - (DelimiterNotationOffset + (delimitersLength));
                numbers = numbers.Substring(beginningOfNumbersList, lengthOfNumbersList);
            }

            var splitNumbers = SplitInputWithDelimiters(numbers, delimiters);

            var parsedNumbers = splitNumbers.Select(s => Int32.Parse(s));
            var negativeExists = parsedNumbers.Where(s => s < 0);

            if (negativeExists.Any())
                ThrowNegativesNotAllowedException(parsedNumbers.Where(n => n < 0));

            var validNumbersToSum = parsedNumbers.Where(n => n < MaxNumberAllowed);
            return validNumbersToSum.Sum();
        }

        private String[] SplitInputWithDelimiters(String numbers, List<String> delimiters)
        {
            if (delimiters.Count > 0)
                return numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            
            return numbers.Split(defaultDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private static void ThrowNegativesNotAllowedException(IEnumerable<Int32> negativeNumbers)
        {
            var exceptionMessage = "negatives not allowed: ";

            foreach (var negative in negativeNumbers)
                exceptionMessage += negative + " ";

            throw new NegativesNotAllowedException(exceptionMessage);
        }

        private List<String> ParseCustomDelimitersToList(String stringInput)
        {
            var delimiterNotation = stringInput.Split(new String[] { "\n" }, StringSplitOptions.None)[0];
            var delimiterList = new List<String>();

            var begin = DelimiterNotationOffset;
            var end = DelimiterNotationOffset;
            for (var i = 3; i < delimiterNotation.Length; i++, end++)
            {
                if (CloseAndOpenBracketOrEndIsFound(delimiterNotation, i))
                {
                    if (i == delimiterNotation.Length)
                        delimiterList.Add(delimiterNotation.Substring(begin, end - begin - 1));
                    else
                        delimiterList.Add(delimiterNotation.Substring(begin, end - begin));

                    end = i + 1;
                    begin = i + 2;
                    i++;
                }
            }

            return delimiterList;
        }

        private static bool CloseAndOpenBracketOrEndIsFound(String stringInput, int i)
        {
            return (stringInput.ElementAt(i).Equals(']') && i < stringInput.Length - 2 && stringInput.ElementAt(i + 1).Equals('[')) ||
                (stringInput.ElementAt(i).Equals(']') && i == stringInput.Length - 1);
        }

        private Boolean MultipleDelimiter(String numbers)
        {
            return numbers.Split(new String[] {"]["}, StringSplitOptions.None).Count() > 1;
        }

        private Boolean CustomDelimiterIsUsed(String numbers)
        {
            return numbers.Count() > 1 && numbers[0].Equals('/') && numbers[1].Equals('/');
        }

        public class NegativesNotAllowedException : Exception
        {
            public NegativesNotAllowedException(String message)
                : base(message)
            { }
        }
    }
}
