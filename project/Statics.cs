using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationalNetwork
{
	public class Attribute
	{
		public int m_attribute;
		public string m_value;

		public void Init(int id, string value)
		{
			m_attribute = id;
			m_value = value;
		}
	}

	public static class Statics
	{
		public static readonly string RULES_DIRECTORY = @"..\..\data\Rules.cs";
		public static readonly Char RULED_DELIMITER = '.';
		public static readonly string EMPTY_STR = "";

		public static readonly string[] ATTRIBUTE =
		{
			"A",
			"B",
			"C",
			"a",
			"b",
			"c",
			"ha",
			"hb",
			"hc",
			"p",
			"S"
		};

		public static readonly string[] ATTRIBUTE_STR =
		{
			"Góc A",
			"Góc B",
			"Góc C",
			"Cạnh a",
			"Cạnh b",
			"Cạnh c",
			"Chiều cao ha",
			"Chiều cao hb",
			"Chiều cao hc",
			"Nửa chu vi p",
			"Diện tích S"
		};

		public static readonly int NOT_RELATE = -1;
		public static readonly int IN_ASSUMPTIONS = 0;
		public static readonly int IN_CONCLUSION = 1;

		public static readonly int NOT_USED_YET = -1;
		public static readonly int USED = 0;
	}
}
