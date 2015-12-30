using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationalNetwork
{
	public class Presentation
	{
		Compute problemCaculate;
		List<int> listKnownInit;
		int indexResult;

		public string _problemPresentation = "";
		public string _strForwardCharning = "";


		public Presentation(Compute _cal, List<int> ListKnownInit, int IndexResult)
		{
			problemCaculate = _cal;
			listKnownInit = ListKnownInit;
			indexResult = IndexResult;
        }

		public void SolveProblem()
		{
			presentProblem();
			presentForwardCharningSolution();
		}

		//Present Problem
		private void presentProblem()
		{
			_problemPresentation += "\t\t-------------------- BÀI TOÁN TAM GIÁC -------------------- \n\n\n"
				+ "Giả thiết: \n";
			for (int i = 0; i < Statics.ATTRIBUTE.Length; i++)
			{
				if (listKnownInit[i] == 0)
				{
					switch (i)
					{
						case 0:
							_problemPresentation += "- Góc A: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
						case 1:
							_problemPresentation += "- Góc B: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
						case 2:
							_problemPresentation += "- Góc C: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
						case 3:
							_problemPresentation += "- Cạnh a: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
						case 4:
							_problemPresentation += "- Cạnh b: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
						case 5:
							_problemPresentation += "- Cạnh c: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
						case 6:
							_problemPresentation += "- Chiều cao ha: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
						case 7:
							_problemPresentation += "- Chiều cao hb: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
						case 8:
							_problemPresentation += "- Chiều cao hc: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
						case 9:
							_problemPresentation += "- Nửa chu vi p: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
						case 10:
							_problemPresentation += "- Diện tích S: "
								+ problemCaculate.ListValues[i] + ".\n";
							break;
					}
				}
			}

			_problemPresentation += "\nKết luận:\n";

			switch (indexResult)
			{
				case 0:
					_problemPresentation += "- Tính góc A ?\n";
					break;
				case 1:
					_problemPresentation += "- Tính góc B ?\n";
					break;
				case 2:
					_problemPresentation += "- Tính góc C ?\n";
					break;
				case 3:
					_problemPresentation += "- Tính độ dài cạnh a ?\n";
					break;
				case 4:
					_problemPresentation += "- Tính độ dài cạnh b ?\n";
					break;
				case 5:
					_problemPresentation += "- Tính độ dài cạnh c ?\n";
					break;
				case 6:
					_problemPresentation += "- Tính độ dài đường cao ha ?\n";
					break;
				case 7:
					_problemPresentation += "- Tính độ dài đường cao hb ?\n";
					break;
				case 8:
					_problemPresentation += "- Tính độ dài đường cao hc ?\n";
					break;
				case 9:
					_problemPresentation += "- Tính nửa chu vi tam giác p ?\n";
					break;
				case 10:
					_problemPresentation += "- Tính diện tích tam giác S ?\n";
					break;
			}

			_problemPresentation += "\n\t Bài làm:\n\n";

			//mainForm.RTB_Result.Text += _problemPresentation;
		}

		//Present Solution
		//Forward Charning
		private void presentForwardCharningSolution()
		{
			for (int i = 0; i < problemCaculate.m_listRulesUsed.Count; i++)
			{
				if (problemCaculate.m_listRulesUsed.Count > 1)
					_strForwardCharning += "* Bước " + (i + 1) + ": ";
				else
					_strForwardCharning += "* ";
				for (int j = 0; j < Statics.ATTRIBUTE.Length; j++)
				{
					if (problemCaculate.m_listRules[problemCaculate.m_listRulesUsed[i]][j] == 1)
					{
						switch (j)
						{
							case 0:
								_strForwardCharning += "Tính góc A\n"
									+ "- Áp dụng công thức: A = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: A = " + problemCaculate.ListValues[0] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy giá trị của góc A cần tìm là "
														+ problemCaculate.ListValues[0] + " độ.\n";
								break;
							case 1:
								_strForwardCharning += "Tính góc B\n"
									+ "- Áp dụng công thức: B = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: B = " + problemCaculate.ListValues[1] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy giá trị của góc B cần tính là "
														+ problemCaculate.ListValues[1] + " độ.\n";
								break;
							case 2:
								_strForwardCharning += "Tính góc C\n"
									+ "- Áp dụng công thức: C = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: C = " + problemCaculate.ListValues[2] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy giá trị của góc C cần tính là "
														+ problemCaculate.ListValues[2] + " độ.\n";
								break;
							case 3:
								_strForwardCharning += "Tính độ dài cạnh a\n"
									+ "- Áp dụng công thức: a = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: a = " + problemCaculate.ListValues[3] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của cạnh a cần tính là "
														+ problemCaculate.ListValues[3] + ".\n";
								break;
							case 4:
								_strForwardCharning += "Tính độ dài cạnh b\n"
									+ "- Áp dụng công thức: b = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: b = " + problemCaculate.ListValues[4] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của cạnh b cần tính là "
														+ problemCaculate.ListValues[4] + ".\n";
								break;
							case 5:
								_strForwardCharning += "Tính độ dài cạnh c\n"
									+ "- Áp dụng công thức: c = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: c = " + problemCaculate.ListValues[5] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của cạnh c cần tính là "
														+ problemCaculate.ListValues[5] + ".\n";
								break;
							case 6:
								_strForwardCharning += "Tính độ dài đường cao ha\n"
									+ "- Áp dụng công thức: ha = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: ha = " + problemCaculate.ListValues[6] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của đường cao ha cần tính là "
														+ problemCaculate.ListValues[6] + ".\n";
								break;
							case 7:
								_strForwardCharning += "Tính độ dài đường cao hb\n"
									+ "- Áp dụng công thức: hb = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: hb = " + problemCaculate.ListValues[7] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của đường cao hb cần tính là "
														+ problemCaculate.ListValues[7] + ".\n";
								break;
							case 8:
								_strForwardCharning += "Tính độ dài đường cao hc\n"
									+ "- Áp dụng công thức: hc = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: hc = " + problemCaculate.ListValues[8] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của đường cao hc cần tính là "
														+ problemCaculate.ListValues[8] + ".\n";
								break;
							case 9:
								_strForwardCharning += "Tính độ dài nửa chu vi p\n"
									+ "- Áp dụng công thức: p = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: p = " + problemCaculate.ListValues[9] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy giá trị của nửa chu vi tam giác p cần tính là "
														+ problemCaculate.ListValues[9] + ".\n";
								break;
							case 10:
								_strForwardCharning += "Tính diện tích S\n"
									+ "- Áp dụng công thức: S = " + getFormula(problemCaculate.m_listRulesUsed[i]) + "\n"
									+ "   Ta tính được: S = " + problemCaculate.ListValues[10] + "\n";
								if (i == problemCaculate.m_listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy diện tích S của tam giác cần tính là "
														+ problemCaculate.ListValues[10] + ".\n";
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
			for (int i = problemCaculate.m_listRulesUsed.Count - 1; i > _currentRule; i--)
			{
				if (problemCaculate.m_listRules[problemCaculate.m_listRulesUsed[i]][_indexArg] == 0)
					return problemCaculate.m_listRulesUsed.Count - i;
			}
			return -1;
		}

	}
}
