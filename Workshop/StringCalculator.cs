using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
	public class StringCalculator
	{
		public static int sumString(string str)
		{
			if (str == String.Empty)
			{
				return 0;
			}

			int result = 0;
			if (Int32.TryParse(str, out result))
			{
				if (result < 0)
				{
					throw new ArgumentException();
				}
				if (result > 1000)
				{
					return 0;
				}

				return result;
			}

			char separator;
			string[] numbers;
			if (str.Substring(0, 2) == "//")
			{
				separator = str[2];
				numbers = str.Substring(4).Split(',', '\n', separator);
			}
			else
			{
				numbers = str.Split(',', '\n');
			}

			foreach (var number in numbers)
			{
				int numberValue = Int32.Parse(number);

				if (numberValue < 0)
				{
					throw new ArgumentException();
				}

				if (numberValue > 1000)
				{
					numberValue = 0;
				}

				result += numberValue;

			}


			return result;

		}
	}
}
