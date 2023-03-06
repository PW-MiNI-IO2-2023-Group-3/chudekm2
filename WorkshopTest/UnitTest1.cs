using Workshop;

namespace WorkshopTest
{
	public class UnitTest1
	{
		[Fact]
		public void EmptyStringReturnsZero()
		{
			int result = StringCalculator.sumString("");
			Assert.Equal(0, result);
		}

		[Theory]
		[InlineData("12", 12)]
		[InlineData("123", 123)]
		[InlineData("1", 1)]
		public void SingleNumberReturnValue(string str, int expectedValue)
		{
			int result = StringCalculator.sumString(str);
			Assert.Equal(expectedValue, result);
		}

		[Theory]
		[InlineData("12,12", 24)]
		[InlineData("1,3", 4)]
		[InlineData("3,5", 8)]
		public void StringSumComa(string str, int expectedValue)
		{
			int result = StringCalculator.sumString(str);
			Assert.Equal(expectedValue, result);
		}

		[Theory]
		[InlineData("12\n12", 24)]
		[InlineData("1\n3", 4)]
		[InlineData("3\n5", 8)]
		public void StringSumLineFeed(string str, int expectedValue)
		{
			int result = StringCalculator.sumString(str);
			Assert.Equal(expectedValue, result);
		}

		[Theory]
		[InlineData("12\n12,1", 25)]
		[InlineData("1,2\n3", 6)]
		[InlineData("3\n5\n2", 10)]
		[InlineData("3,5,2", 10)]
		public void MultilineSeparatedValues(string str, int expectedValue)
		{
			int result = StringCalculator.sumString(str);
			Assert.Equal(expectedValue, result);
		}

		[Theory]
		[InlineData("-1")]
		[InlineData("-12\n12,1")]
		[InlineData("1,2\n-3")]
		[InlineData("3\n-5\n2")]
		[InlineData("3,-5,2")]
		public void NegativeNumberThrowsArgumentException(string str)
		{
			Assert.Throws<ArgumentException>(() => StringCalculator.sumString(str));
		}

		[Theory]
		[InlineData("1000", 1000)]
		[InlineData("1001", 0)]
		[InlineData("12\n12,1,1001", 25)]
		[InlineData("1,2\n3\n1000", 1006)]
		[InlineData("1001,3\n5\n2", 10)]
		[InlineData("1001\n3,5,2", 10)]
		public void NumbersGreaterThan1000AreIgnored(string str, int expectedValue)
		{
			int result = StringCalculator.sumString(str);
			Assert.Equal(expectedValue, result);
		}

		[Theory]
		[InlineData("//#\n1000#1", 1001)]
		[InlineData("//$\n1001$2", 2)]
		[InlineData("12\n12,1,1001", 25)]
		[InlineData("1,2\n3\n1000", 1006)]
		[InlineData("1001,3\n5\n2", 10)]
		[InlineData("1001\n3,5,2", 10)]
		public void CustomSeparator(string str, int expectedValue)
		{
			int result = StringCalculator.sumString(str);
			Assert.Equal(expectedValue, result);
		}
	}
}