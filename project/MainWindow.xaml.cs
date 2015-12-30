using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ComputationalNetwork
{
    public partial class MainWindow : Window
    {
		public List<int>	m_listRulesUsed = new List<int>();


		// Assumptions and conclusion info
		List<Attribute>		m_attributesInfo = new List<Attribute>();

		// Assumptions
		List<int>			m_assumptions;
		public List<int>	Assumptions
		{
			get { return m_assumptions; }
			set { m_assumptions = value; }
		}

		// Conclusion
		int			m_conclusion;
		public int	Conclusion
		{
			get { return m_conclusion; }
			set { m_conclusion = value; }
		}


		// Store all Rules in text file
		List<List<int>>			m_rulesList;
		public List<List<int>>	RulesList
		{
			get { return m_rulesList; }
			set { m_rulesList = value; }
		}


		// Computing and presenting
		Presentation	m_presentation;
		Compute			m_compute;

		public MainWindow()
        {
            InitializeComponent();
			m_rulesList = FileHelper.LoadRules(Statics.RULES_DIRECTORY);

			m_assumptions = new List<int>();

			for (int i = 0; i < Statics.ATTRIBUTE.Length; i++)
			{
				Attribute _attribute = new Attribute();
				_attribute.Init(i, null);

				m_attributesInfo.Add(_attribute);
			}

			m_attributesInfo[0].m_value = "90";
			m_attributesInfo[4].m_value = "3";
			m_attributesInfo[5].m_value = "4";

			m_attributesInfo[3].m_value = "?";

			UpdateRequirements();
        }

		private void UpdateRequirements()
		{
			m_assumptions.Clear();

			for (int i = 0; i < Statics.ATTRIBUTE.Length; i++)
			{
				if (m_attributesInfo[i].m_value != null && m_attributesInfo[i].m_value != "?")
				{
					m_assumptions.Add(Statics.IN_ASSUMPTIONS);
				}
				else
				{
					m_assumptions.Add(Statics.NOT_RELATE);
					if (m_attributesInfo[i].m_value == "?")
					{
						m_conclusion = i;
					}
				}
			}
		}


		private void AddAttribute_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void Go_Click(object sender, RoutedEventArgs e)
		{
			m_listRulesUsed.Clear();
			List<int> _knownList = new List<int>(m_assumptions);

			if (m_conclusion != -1)
			{
				m_listRulesUsed = Compute.ForwardChaining(m_rulesList, _knownList, m_conclusion);
			}

			if (m_listRulesUsed.Count > 0)
			{
				m_compute = new Compute(m_attributesInfo, RulesList, m_listRulesUsed);
				m_compute.ProcessCaculate();

				m_presentation = new Presentation(m_compute, Assumptions, Conclusion);
				m_presentation.SolveProblem();

				Requirements.Text = m_presentation._problemPresentation;
				Results.Text = m_presentation._strForwardCharning;
			}
			else
			{
				MessageBox.Show("Thiếu giả thiết. \n Hãy đưa thêm giả thiết cho bài toán!",
						"ERROR");
			}
		}
	}
}
