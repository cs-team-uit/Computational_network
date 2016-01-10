using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LollipopUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

			Dictionary.LoadWordList("wordlist.txt");
        }

		private void browse_folder_TextChanged(object sender, EventArgs e)
		{
			string directory = browse_folder.Text;

			try
			{
				DirectoryInfo _directInfo = new DirectoryInfo(directory);
				FileInfo[] files = _directInfo.GetFiles();

				txtbox_input.Text = "";

				foreach (FileInfo file in files)
				{
					txtbox_input.Text += file.FullName + Environment.NewLine;
				}
			}
			catch
			{
				MessageBox.Show("Please select a folder to tokenize");
			}
		}

		private void btn_tokenize_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog _dialog = new FolderBrowserDialog();
			string _outputDirectory = null;

			if (_dialog.ShowDialog() != DialogResult.OK)
				return;

			_outputDirectory = _dialog.SelectedPath.Replace("\r", String.Empty);
			string[] _lines = txtbox_input.Lines;

			try
			{
				foreach(string _line in _lines)
				{
					try
					{
						string _inputPath = _line.Replace("\r", String.Empty);
						var _filestream = new System.IO.FileStream(_inputPath,
										  System.IO.FileMode.Open,
										  System.IO.FileAccess.Read,
										  System.IO.FileShare.ReadWrite);
						var _reader = new System.IO.StreamReader(_filestream, System.Text.Encoding.UTF8, true, 128);

						string _outputName = _reader.ReadLine();
						string _title = _reader.ReadLine();
						string _tags = _reader.ReadLine();
						string _content = _reader.ReadToEnd();
						
						Tokenizer _tokenizer = new Tokenizer(_title, _tags, _content);
						string _result = _tokenizer.Tokenizing(_tokenizer.m_content);

						_reader.Dispose();
						_filestream.Dispose();


						string _outputPath = _outputDirectory + "\\" + _outputName + ".tok";
						var _writetream = new System.IO.FileStream(_outputPath,
										  System.IO.FileMode.Create,
										  System.IO.FileAccess.Write,
										  System.IO.FileShare.ReadWrite);
						var _writer = new System.IO.StreamWriter(_writetream, System.Text.Encoding.UTF8, 128);
						_writer.Write(_tokenizer.m_title + "\n" + _tokenizer.m_tags + "\n" + _result);

						_writer.Dispose();
						_writetream.Dispose();

						txtbox_tokenized.Text += _outputPath + Environment.NewLine;
					}
					catch (Exception ex)
					{

					}
				}
			}
			catch
			{
				MessageBox.Show("No file to tokenize. Process failed...");
			}
		}

		private void btn_indexing_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog _dialog = new FolderBrowserDialog();
			string _outputDirectory = null;

			if (_dialog.ShowDialog() != DialogResult.OK)
				return;

			_outputDirectory = _dialog.SelectedPath.Replace("\r", String.Empty);
			string[] _lines = txtbox_tokenized.Lines;

			try
			{
				foreach (string _line in _lines)
				{
					try
					{
						
					}
					catch (Exception ex)
					{

					}
				}
			}
			catch
			{
				MessageBox.Show("No file to tokenize. Process failed...");
			}
		}
	}
}
