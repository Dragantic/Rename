using Rename.Properties;
using ExtensionMethods;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System;
using System.Text.RegularExpressions;

namespace Rename {
	public partial class frmNames : Form {
		public frmNames() {
			InitializeComponent();
		}

		BindingList<NameSwap> bList;
		string pimp = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
					+ @"\.rename";

		private void frmNames_Load(object sender, System.EventArgs e) {
			Location = Settings.Default.NameLocation;
			bList = new BindingList<NameSwap>();

			if (File.Exists(pimp))
			{ using (StreamReader sr = new StreamReader(pimp))
			  { string line;
				bool begin=false;
				while ((line = sr.ReadLine()) != null)
				{	if (!begin)
					{	if (Regex.IsMatch(line, "-{3,}")) begin=true;
						continue;   }
					string[] names = line.Split(',');
					string[] before = names.SubArray(0, names.Length-1);
					if (names.Length>1) bList.Add( new NameSwap
					{	Before = string.Join(",", before),
						 After = names[names.Length-1]   });   } } }
			var src = new BindingSource(bList, null);
			grdNames.DataSource = src;
		}

		private void frmNames_FormClosing(object sender, FormClosingEventArgs e) {
			Settings.Default.NameLocation = Location;
			Settings.Default.Save();
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void btnSave_Click(object sender, System.EventArgs e) {
			//DialogResult result = MessageBox.Show
			//	("	    Save Changes?", "Confirm", MessageBoxButtons.OKCancel);
			//if (result.Equals(DialogResult.OK))
			//{	StringCollection names = new StringCollection();
			//	foreach (NameSwap item in bList)
			//	{	item.Before = Regex.Replace(item.Before, @"[ \t]", "");
			//		item.After = Regex.Replace(item.After, @"[ \t]", "");
			//		if (item.Before!=null && item.After!=null)
			//			names.Add(item.Before + "," + item.After);   }   }
		}
	}

	class NameSwap {
		public string Before { get; set; }
		public string  After { get; set; }
	}
}

namespace ExtensionMethods {
	public static class MyExtensions {
		public static T[] SubArray<T>(this T[] data, int index, int length) {
			T[] result = new T[length];
			System.Array.Copy(data, index, result, 0, length);
			return result;
		}
	}
}