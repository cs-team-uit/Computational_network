using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationalNetwork
{
	public class PresentSolution
	{
		Compute problemCaculate;
		List<int> listKnownInit;
		int indexResult;

		const int num_arg = 11;


		public PresentSolution(Compute _cal, List<int> ListKnownInit, int IndexResult)
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
			string _problemPresentation = "";
			_problemPresentation += "\t\t-------------------- BÀI TOÁN TAM GIÁC -------------------- \n\n\n"
				+ "Giả thiết: \n";
			for (int i = 0; i < num_arg; i++)
			{
				if (listKnownInit[i] == 0)
				{
					switch (i)
					{
						case 0:
							_problemPresentation += "- Góc A: "
								+ problemCaculate.ListValue[i] + ".\n";
							break;
						case 1:
							_problemPresentation += "- Góc B: "
								+ problemCaculate.ListValue[i] + ".\n";
							break;
						case 2:
							_problemPresentation += "- Góc C: "
								+ problemCaculate.ListValue[i] + ".\n";
							break;
						case 3:
							_problemPresentation += "- Cạnh a: "
								+ problemCaculate.ListValue[i] + ".\n";
							break;
						case 4:
							_problemPresentation += "- Cạnh b: "
								+ problemCaculate.ListValue[i] + ".\n";
							break;
						case 5:
							_problemPresentation += "- Cạnh c: "
								+ problemCaculate.ListValue[i] + ".\n";
							break;
						case 6:
							_problemPresentation += "- Chiều cao ha: "
								+ problemCaculate.ListValue[i] + ".\n";
							break;
						case 7:
							_problemPresentation += "- Chiều cao hb: "
								+ problemCaculate.ListValue[i] + ".\n";
							break;
						case 8:
							_problemPresentation += "- Chiều cao hc: "
								+ problemCaculate.ListValue[i] + ".\n";
							break;
						case 9:
							_problemPresentation += "- Nửa chu vi p: "
								+ problemCaculate.ListValue[i] + ".\n";
							break;
						case 10:
							_problemPresentation += "- Diện tích S: "
								+ problemCaculate.ListValue[i] + ".\n";
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
			string _strForwardCharning = "";
			for (int i = 0; i < problemCaculate.listRulesUsed.Count; i++)
			{
				if (problemCaculate.listRulesUsed.Count > 1)
					_strForwardCharning += "* Bước " + (i + 1) + ": ";
				else
					_strForwardCharning += "* ";
				for (int j = 0; j < num_arg; j++)
				{
					if (problemCaculate.listRules[problemCaculate.listRulesUsed[i]][j] == 1)
					{
						switch (j)
						{
							case 0:
								_strForwardCharning += "Tính góc A\n"
									+ "- Áp dụng công thức: A = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: A = " + problemCaculate.ListValue[0] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy giá trị của góc A cần tìm là "
														+ problemCaculate.ListValue[0] + " độ.\n";
								break;
							case 1:
								_strForwardCharning += "Tính góc B\n"
									+ "- Áp dụng công thức: B = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: B = " + problemCaculate.ListValue[1] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy giá trị của góc B cần tính là "
														+ problemCaculate.ListValue[1] + " độ.\n";
								break;
							case 2:
								_strForwardCharning += "Tính góc C\n"
									+ "- Áp dụng công thức: C = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: C = " + problemCaculate.ListValue[2] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy giá trị của góc C cần tính là "
														+ problemCaculate.ListValue[2] + " độ.\n";
								break;
							case 3:
								_strForwardCharning += "Tính độ dài cạnh a\n"
									+ "- Áp dụng công thức: a = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: a = " + problemCaculate.ListValue[3] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của cạnh a cần tính là "
														+ problemCaculate.ListValue[3] + ".\n";
								break;
							case 4:
								_strForwardCharning += "Tính độ dài cạnh b\n"
									+ "- Áp dụng công thức: b = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: b = " + problemCaculate.ListValue[4] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của cạnh b cần tính là "
														+ problemCaculate.ListValue[4] + ".\n";
								break;
							case 5:
								_strForwardCharning += "Tính độ dài cạnh c\n"
									+ "- Áp dụng công thức: c = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: c = " + problemCaculate.ListValue[5] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của cạnh c cần tính là "
														+ problemCaculate.ListValue[5] + ".\n";
								break;
							case 6:
								_strForwardCharning += "Tính độ dài đường cao ha\n"
									+ "- Áp dụng công thức: ha = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: ha = " + problemCaculate.ListValue[6] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của đường cao ha cần tính là "
														+ problemCaculate.ListValue[6] + ".\n";
								break;
							case 7:
								_strForwardCharning += "Tính độ dài đường cao hb\n"
									+ "- Áp dụng công thức: hb = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: hb = " + problemCaculate.ListValue[7] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của đường cao hb cần tính là "
														+ problemCaculate.ListValue[7] + ".\n";
								break;
							case 8:
								_strForwardCharning += "Tính độ dài đường cao hc\n"
									+ "- Áp dụng công thức: hc = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: hc = " + problemCaculate.ListValue[8] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy độ dài của đường cao hc cần tính là "
														+ problemCaculate.ListValue[8] + ".\n";
								break;
							case 9:
								_strForwardCharning += "Tính độ dài nửa chu vi p\n"
									+ "- Áp dụng công thức: p = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: p = " + problemCaculate.ListValue[9] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy giá trị của nửa chu vi tam giác p cần tính là "
														+ problemCaculate.ListValue[9] + ".\n";
								break;
							case 10:
								_strForwardCharning += "Tính diện tích S\n"
									+ "- Áp dụng công thức: S = " + getFormula(problemCaculate.listRulesUsed[i]) + "\n"
									+ "   Ta tính được: S = " + problemCaculate.ListValue[10] + "\n";
								if (i == problemCaculate.listRulesUsed.Count - 1)
									_strForwardCharning += "\nKết luận: Vậy diện tích S của tam giác cần tính là "
														+ problemCaculate.ListValue[10] + ".\n";
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
			StreamReader sr = new StreamReader("Rules.txt");
			for (int i = 0; i < _indexExp + 1; i++)
				_temp_str = sr.ReadLine();
			sr.Close();
			sr.Dispose();

			_temp_str = _temp_str.Substring(_temp_str.IndexOf('.') + 1);

			return _temp_str;
		}

		//Get index of rule contain the argument
		private int getIndexOfRuleContain(int _indexArg, int _currentRule)
		{
			for (int i = problemCaculate.listRulesUsed.Count - 1; i > _currentRule; i--)
			{
				if (problemCaculate.listRules[problemCaculate.listRulesUsed[i]][_indexArg] == 0)
					return problemCaculate.listRulesUsed.Count - i;
			}
			return -1;
		}

	}
}
