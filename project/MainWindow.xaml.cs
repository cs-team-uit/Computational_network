using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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

			AddAttribute.IsEnabled = true;
			Go.IsEnabled = true;

			cmb_attribute.IsEnabled = true;
			txtbox_value.IsEnabled = true;
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

		private void AddNewAttribute()
		{
			float n;
			bool isNumeric = float.TryParse(txtbox_value.Text, out n);
			if (txtbox_value.Text != "" && (isNumeric == true || txtbox_value.Text == "?"))
			{
				m_attributesInfo[cmb_attribute.SelectedIndex].m_value = txtbox_value.Text;

				ComboBoxItem _selectedItem = (ComboBoxItem)(cmb_attribute.SelectedValue);
				string _item = _selectedItem.Content.ToString() + " = " + txtbox_value.Text;

				if (txtbox_value.Text == "?")
					lstview_conclusions.Items.Add(_item);
				else
					lstview_assumptions.Items.Add(_item);

				txtbox_value.Text = "";
			}
			else if (!isNumeric)
			{
				MessageBox.Show("Value must be number!");
			}
		}


		private void AddAttribute_Click(object sender, RoutedEventArgs e)
		{
			AddNewAttribute();
		}

		private void Go_Click(object sender, RoutedEventArgs e)
		{
			UpdateRequirements();

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
				m_presentation.Resolve();

				Requirements.Text = m_presentation.m_requirements;
				Results.Text = m_presentation.m_results;

				AddAttribute.IsEnabled = false;
				Go.IsEnabled = false;

				cmb_attribute.IsEnabled = false;
				txtbox_value.IsEnabled = false;
			}
			else
			{
				MessageBox.Show("Dữ liệu đầu vào không đủ, vui lòng cung cấp thêm để thực hiện bài toán!", "Warning");
			}
		}

		private void Clear_Click(object sender, RoutedEventArgs e)
		{
			AddAttribute.IsEnabled = true;
			Go.IsEnabled = true;

			cmb_attribute.IsEnabled = true;
			txtbox_value.IsEnabled = true;

			lstview_assumptions.Items.Clear();
			lstview_conclusions.Items.Clear();
		}

		private void cmb_attribute_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}

		private void txtbox_value_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if(e.Key == System.Windows.Input.Key.Enter)
			{
				AddNewAttribute();
			}
		}
	}
}
