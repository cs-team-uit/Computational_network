using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		//save used rules
		public List<int> list_used_rule = new List<int>();

		public List<int> ListRulesUsed
		{
			get { return list_used_rule; }
		}

		//the hypothesis
		List<int> listKnownInit;
		public List<int> ListKnownInit
		{
			get { return listKnownInit; }
			set { listKnownInit = value; }
		}

		//storage rules in list
		//in each rule, arguments is sorted in order: A, B, C, a, b, c, ha, hb, hc, p, S
		List<List<int>> list_rule;
		public List<List<int>> ListRules
		{
			get { return list_rule; }
			set { list_rule = value; }
		}

		//number argument
		const int num_arg = 11;


		//the result 
		int index_result;
		public int IndexResult
		{
			get { return index_result; }
			set { index_result = value; }
		}

		List<int> list_known;
		public List<int> ListKnown
		{
			get { return list_known; }
			set { list_known = value; }
		}

		PresentSolution myPresent;
		public ComputationalNetwork.PresentSolution MyPresent
		{
			get { return myPresent; }
			set { myPresent = value; }
		}


		List<Attribute> m_attributesInfo = new List<Attribute>();
		Compute m_calculate;



		public MainWindow()
        {
            InitializeComponent();
			Init();

			for (int i = 0; i < num_arg; i++)
			{
				Attribute _attribute = new Attribute();
				_attribute.Init(i, "");
				m_attributesInfo.Add(_attribute);
			}

			m_attributesInfo[0].m_value = "90";
			m_attributesInfo[4].m_value = "3";
			m_attributesInfo[5].m_value = "4";

			m_attributesInfo[3].m_value = "?";
		}

		//initialize
		private void Init()
		{
			list_rule = new List<List<int>>();

			LoadFile();

			listKnownInit = new List<int>();
		}

		//Load rules from file
		private void LoadFile()
		{
			StreamReader sr = new StreamReader(@"..\..\Rules.txt");
			string _line;
			//read each line
			while ((_line = sr.ReadLine()) != null)
			{
				addRule(_line);
			}
			sr.Dispose();
		}

		//read and add rules
		private void addRule(string _rule)
		{
			List<int> _list_rule = new List<int>(num_arg);

			//init list, set default is -1
			for (int i = 0; i < num_arg; i++)
				_list_rule.Add(-1);

			int _pos = 0, //postion of current char
				_len_arg = 0; //length of argument

			int _mark_rule = 0;

			while (_rule[_pos == 0 ? _pos : _pos - 1] != '.')
			{
				if (_rule[_pos] >= 'A' && _rule[_pos] <= 'z')
					_len_arg++;
				else
				{
					if (_pos > 1)
						if (_rule[_pos - 1] == '-' && _rule[_pos] == '>')
						{
							_mark_rule = 1; //pass the "IF" clause and mark "THEN" clause is 1
						}

					if (_len_arg != 0)
					{
						string _temp_str_arg = _rule.Substring(_pos - _len_arg, _len_arg);
						switch (_temp_str_arg)
						{
							case "A":
								_list_rule[0] = _mark_rule;
								break;
							case "B":
								_list_rule[1] = _mark_rule;
								break;
							case "C":
								_list_rule[2] = _mark_rule;
								break;
							case "a":
								_list_rule[3] = _mark_rule;
								break;
							case "b":
								_list_rule[4] = _mark_rule;
								break;
							case "c":
								_list_rule[5] = _mark_rule;
								break;
							case "ha":
								_list_rule[6] = _mark_rule;
								break;
							case "hb":
								_list_rule[7] = _mark_rule;
								break;
							case "hc":
								_list_rule[8] = _mark_rule;
								break;
							case "p":
								_list_rule[9] = _mark_rule;
								break;
							case "S":
								_list_rule[10] = _mark_rule;
								break;
						}

						_len_arg = 0; //set length of argument is 0
					}
				}

				_pos++;
			}

			//Add to list rules
			list_rule.Add(_list_rule);
		}




		private void AddAttribute_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void Go_Click(object sender, RoutedEventArgs e)
		{
			list_used_rule.Clear();

			bool _isSolve = true;

			if (CheckState())
			{
				list_known = new List<int>(ListKnownInit);

				if (index_result != -1)
				{
					_isSolve = ForwardCharning();
				}

				if (_isSolve)
				{
					m_calculate = new Compute(m_attributesInfo, ListRules, list_used_rule);
					m_calculate.ProcessCaculate();

					myPresent = new PresentSolution(m_calculate, ListKnownInit, IndexResult);
					myPresent.SolveProblem();
				}
			}
		}

		private bool CheckState()
		{
			ListKnownInit.Clear();

			for (int i = 0; i < num_arg; i++)
			{
				if (m_attributesInfo[i].m_value != "" && m_attributesInfo[i].m_value != "?")
				{
					ListKnownInit.Add(0);
				}
				else
				{
					ListKnownInit.Add(-1);
					if (m_attributesInfo[i].m_value == "?")
					{
						index_result = i;
					}
				}
			}

			return true;
		}

		private bool ForwardCharning()
		{
			//Check state of all rules
			//Set default rule state is -1 
			List<int> _list_state_rule = new List<int>();



			for (int i = 0; i < list_rule.Count; i++)
			{
				_list_state_rule.Add(-1);
			}


			bool _isImplementRule = false;

			while (list_known[index_result] == -1)
			{
				_isImplementRule = false;
				for (int i = 0; i < list_rule.Count; i++)
				{
					if (_list_state_rule[i] == -1)
					{
						bool is_avail = true;
						for (int j = 0; j < num_arg; j++)
						{
							//if argument in hypothesis not found in know
							if ((list_rule[i][j] == 0 && list_known[j] != 0)
								// if argument in conclude is in know
								|| (list_rule[i][j] == 1 && list_known[j] == 0))
							{
								is_avail = false;
								break;
							}
						}

						if (is_avail)
						{
							for (int j = 0; j < num_arg; j++)
							{
								if (list_rule[i][j] == 1)
								{
									list_known[j] = 0;
									break;
								}
							}

							list_used_rule.Add(i);
							_isImplementRule = true;

							//check if result is found
							if (list_known[index_result] == 0)
								break;

							_list_state_rule[i] = 0;
						}
					}
				}

				if (!_isImplementRule)
				{
					MessageBox.Show("Thiếu giả thiết. \n Hãy đưa thêm giả thiết cho bài toán!",
						"ERROR");
					return false;
				}
			}

			if (_isImplementRule)
			{
				list_used_rule = reduce_List(list_used_rule);
				//for (int i = 0; i < list_used_rule.Count; i++)
				//rTB_Result.Text += (getRule(list_used_rule[i] + 1) + "\n");
			}

			return true;
		}

		//Reduce list and delete all not used rules
		private List<int> reduce_List(List<int> _list_full)
		{
			List<int> _list_temp = new List<int>();

			//position of last rule in _list_full
			int _pos_last_rule = _list_full.Count - 1;

			_list_temp.Add(_list_full[_pos_last_rule]);

			for (int i = _list_full.Count - 2; i >= 0; i--)
			{
				//check whether the result of the rule before last is in the "IF" clause of last rule
				for (int j = 0; j < num_arg; j++)
					if (list_rule[_list_full[i]][j] == 1)
					{
						//check whether a before rule contain this 
						bool _isContain = false;
						for (int k = i + 1; k < _list_full.Count; k++)
							if (list_rule[_list_full[k]][j] == 0)
							{
								_isContain = true;
								break;
							}

						if (_isContain)
						{
							_pos_last_rule = i;
							_list_temp.Add(_list_full[_pos_last_rule]);
							break;
						}
					}
			}

			_list_temp.Reverse();
			return _list_temp;
		}
	}
}
