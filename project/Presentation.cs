using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ComputationalNetwork
{
	public class Presentation
	{
		List<int>	m_assumptions;
		int			m_conclusion;

		public string m_requirements;
		public string m_results;

		Compute m_compute;

		public Presentation(Compute compute, List<int> assumptions, int conclusion)
		{
			m_compute = compute;
			m_assumptions = assumptions;
			m_conclusion = conclusion;

			m_requirements = "";
			m_results = "";
		}

		public void Resolve()
		{
			RepresentRequirements();
			RepresentSolutions();
		}

		private void RepresentRequirements()
		{
			m_requirements += "Bài toán Tam giác\n\n"
				+ "Giả thiết: \n";
			for (int i = 0; i < Statics.ATTRIBUTE.Length; i++)
			{
				if (m_assumptions[i] == 0)
				{
					switch (i)
					{
						case 0:
							m_requirements += "- Góc A = \t"
								+ m_compute.ListValues[i] + ".\n";
							break;
						case 1:
							m_requirements += "- Góc B = \t\t"
								+ m_compute.ListValues[i] + ".\n";
							break;
						case 2:
							m_requirements += "- Góc C = \t"
								+ m_compute.ListValues[i] + ".\n";
							break;
						case 3:
							m_requirements += "- Cạnh a = \t"
								+ m_compute.ListValues[i] + ".\n";
							break;
						case 4:
							m_requirements += "- Cạnh b = \t"
								+ m_compute.ListValues[i] + ".\n";
							break;
						case 5:
							m_requirements += "- Cạnh c = \t"
								+ m_compute.ListValues[i] + ".\n";
							break;
						case 6:
							m_requirements += "- Chiều cao ha = \t"
								+ m_compute.ListValues[i] + ".\n";
							break;
						case 7:
							m_requirements += "- Chiều cao hb = \t"
								+ m_compute.ListValues[i] + ".\n";
							break;
						case 8:
							m_requirements += "- Chiều cao hc = \t"
								+ m_compute.ListValues[i] + ".\n";
							break;
						case 9:
							m_requirements += "- Nửa chu vi p = \t"
								+ m_compute.ListValues[i] + ".\n";
							break;
						case 10:
							m_requirements += "- Diện tích S = \t"
								+ m_compute.ListValues[i] + ".\n";
							break;
					}
				}
			}

			m_requirements += "\nKết luận:\n";

			switch (m_conclusion)
			{
				case 0:
					m_requirements += "- Tính góc A?\n";
					break;
				case 1:
					m_requirements += "- Tính góc B?\n";
					break;
				case 2:
					m_requirements += "- Tính góc C?\n";
					break;
				case 3:
					m_requirements += "- Tính độ dài cạnh a?\n";
					break;
				case 4:
					m_requirements += "- Tính độ dài cạnh b?\n";
					break;
				case 5:
					m_requirements += "- Tính độ dài cạnh c?\n";
					break;
				case 6:
					m_requirements += "- Tính độ dài đường cao ha?\n";
					break;
				case 7:
					m_requirements += "- Tính độ dài đường cao hb?\n";
					break;
				case 8:
					m_requirements += "- Tính độ dài đường cao hc?\n";
					break;
				case 9:
					m_requirements += "- Tính nửa chu vi tam giác p?\n";
					break;
				case 10:
					m_requirements += "- Tính diện tích tam giác S?\n";
					break;
			}
		}

		private void RepresentSolutions()
		{
			for (int i = 0; i < m_compute.m_listRulesUsed.Count; i++)
			{
				if (m_compute.m_listRulesUsed.Count > 1)
					m_results += "* Bước " + (i + 1) + ": ";
				else
					m_results += "* ";

				for (int j = 0; j < Statics.ATTRIBUTE.Length; j++)
				{
					if (m_compute.m_listRules[m_compute.m_listRulesUsed[i]][j] == 1)
					{
						m_results += "Tính " + Statics.ATTRIBUTE_STR[j] + "\n";

						switch (j)
						{
							case 0:
								m_results += "Tính góc A\n"
									+ "- Từ công thức: A = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Ta suy ra: A = " + m_compute.ListValues[0] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy giá trị của góc A cần tìm là "
														+ m_compute.ListValues[0] + " độ.\n";
								break;
							case 1:
								m_results += "Tính góc B\n"
									+ "- Ta có: B = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Suy ra: B = " + m_compute.ListValues[1] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy giá trị của góc B cần tính là "
														+ m_compute.ListValues[1] + " độ.\n";
								break;
							case 2:
								m_results += "Tính góc C\n"
									+ "- Áp dụng công thức: C = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: C = " + m_compute.ListValues[2] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy giá trị của góc C cần tính là "
														+ m_compute.ListValues[2] + " độ.\n";
								break;
							case 3:
								m_results += "Tính độ dài cạnh a\n"
									+ "- Ta có công thức: a = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Suy ra: a = " + m_compute.ListValues[3] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy độ dài của cạnh a cần tính là "
														+ m_compute.ListValues[3] + ".\n";
								break;
							case 4:
								m_results += "Tính độ dài cạnh b\n"
									+ "- Ta có công thức: b = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Suy ra: b = " + m_compute.ListValues[4] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy độ dài của cạnh b cần tính là "
														+ m_compute.ListValues[4] + ".\n";
								break;
							case 5:
								m_results += "Tính độ dài cạnh c\n"
									+ "- Ta có: c = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Vậy: c = " + m_compute.ListValues[5] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy độ dài của cạnh c cần tính là "
														+ m_compute.ListValues[5] + ".\n";
								break;
							case 6:
								m_results += "Tính độ dài đường cao ha\n"
									+ "- Áp dụng công thức: ha = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: ha = " + m_compute.ListValues[6] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy độ dài của đường cao ha cần tính là "
														+ m_compute.ListValues[6] + ".\n";
								break;
							case 7:
								m_results += "Tính độ dài đường cao hb\n"
									+ "- Áp dụng công thức: hb = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: hb = " + m_compute.ListValues[7] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy độ dài của đường cao hb cần tính là "
														+ m_compute.ListValues[7] + ".\n";
								break;
							case 8:
								m_results += "Tính độ dài đường cao hc\n"
									+ "- Áp dụng công thức: hc = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: hc = " + m_compute.ListValues[8] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy độ dài của đường cao hc cần tính là "
														+ m_compute.ListValues[8] + ".\n";
								break;
							case 9:
								m_results += "Tính độ dài nửa chu vi p\n"
									+ "- Áp dụng công thức: p = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: p = " + m_compute.ListValues[9] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy giá trị của nửa chu vi p của tam giác cần tính là "
														+ m_compute.ListValues[9] + ".\n";
								break;
							case 10:
								m_results += "Tính diện tích S\n"
									+ "- Áp dụng công thức: S = " + getFormula(m_compute.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: S = " + m_compute.ListValues[10] + "\n";
								if (i == m_compute.m_listRulesUsed.Count - 1)
									m_results += "\nKết luận: Vậy diện tích S của tam giác cần tính là "
														+ m_compute.ListValues[10] + ".\n";
								break;
						}

						break;
					}
				}
			}

			//mainForm.RTB_Result.Text += _strForwardCharning;
		}

		//Get formula from file
		private string getFormula(int _indexExp)
		{
			string _temp_str = "";
			StreamReader sr = new StreamReader(Statics.RULES_DIRECTORY);
			for (int i = 0; i < _indexExp + 1; i++)
				_temp_str = sr.ReadLine();
			sr.Close();
			sr.Dispose();

			_temp_str = _temp_str.Substring(_temp_str.IndexOf(Statics.RULED_DELIMITER) + 1);

			return _temp_str;
		}

		//Get index of rule contain the argument
		private int getIndexOfRuleContain(int _indexArg, int _currentRule)
		{
			for (int i = m_compute.m_listRulesUsed.Count - 1; i > _currentRule; i--)
			{
				if (m_compute.m_listRules[m_compute.m_listRulesUsed[i]][_indexArg] == 0)
					return m_compute.m_listRulesUsed.Count - i;
			}
			return -1;
		}

	}
}
