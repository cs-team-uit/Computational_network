using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LollipopUI
{
	public static class Dictionary
	{
		public static ArrayList m_words1 = new ArrayList();
		public static ArrayList m_words2 = new ArrayList();
		public static ArrayList m_words3 = new ArrayList();
		public static ArrayList m_words4 = new ArrayList();

		public static void LoadWordList(string path)
		{
			var _filestream = new System.IO.FileStream(path,
										  System.IO.FileMode.Open,
										  System.IO.FileAccess.Read,
										  System.IO.FileShare.ReadWrite);
			var _file = new System.IO.StreamReader(_filestream, System.Text.Encoding.UTF8, true, 128);

			string _word = null;
			while ((_word = _file.ReadLine()) != null)
			{
				int _countSyllable = CountSyllable(_word);

				switch(_countSyllable)
				{
					case 1:
						m_words1.Add(_word);
						break;
					case 2:
						m_words2.Add(_word);
						break;
					case 3:
						m_words3.Add(_word);
						break;
					case 4:
						m_words4.Add(_word);
						break;
					default:
						m_words4.Add(_word);
						break;
				}
			}

			_file.Dispose();
			_filestream.Dispose();
		}

		public static int CountSyllable(string word)
		{
			return word.Split(' ').Length;
		}

		public static bool IsInDictionary(string word)
		{
			int _countSyllable = CountSyllable(word);

			switch (_countSyllable)
			{
				case 1:
					if (m_words1.Contains(word))
						return true;
					break;
				case 2:
					if (m_words2.Contains(word))
						return true;
					break;
				case 3:
					if (m_words3.Contains(word))
						return true;
					break;
				case 4:
					if (m_words4.Contains(word))
						return true;
					break;
				default:
					if (m_words4.Contains(word))
						return true;
					break;
			}

			return false;
		}
	}

	public class Tokenizer
	{
		public string m_title;
		public string m_tags;

		public string m_content;

		public Tokenizer(string title, string tags, string content)
		{
			m_title = title;
			m_tags = tags;
			m_content = content;
		}

		public string Tokenizing(string content)
		{
			return null;
		}
	}

	public class Indexer
	{
		public string m_title;
		public string m_tags;

		public string[] m_words;

		public Indexer(string title, string tags, string content)
		{

		}

		public string Indexing()
		{
			return null;
		}
	}
}
