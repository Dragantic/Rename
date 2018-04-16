using Rename.Properties;
using ExtensionMethods;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Rename {
	public partial class frmNames : Form {
		public frmNames() {
			InitializeComponent();
		}

		BindingList<NameSwap> bList;

		private void frmNames_Load(object sender, System.EventArgs e) {
			Location = Settings.Default.NameLocation;
			Size = Settings.Default.NameSize;
			bList = new BindingList<NameSwap>();

			foreach (var jugs in Blimp.bigs)
			{	string[] before = jugs.SubArray(0, jugs.Length-1);
				if (jugs.Length>1) bList.Add( new NameSwap
				{	Before = string.Join(",", before),
					 After = jugs[jugs.Length-1]   });   }
			var src = new BindingSource(bList, null);
			grdNames.DataSource = src;
		}

		private void frmNames_FormClosing(object sender, FormClosingEventArgs e) {
			Settings.Default.NameLocation = Location;
			Settings.Default.NameSize = Size;
			Settings.Default.Save();
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void btnSave_Click(object sender, System.EventArgs e) {
			Blimp.bigs = new List<string[]>();
			foreach (NameSwap item in bList)
			{	item.Before = Regex.Replace(item.Before, @"[ \t]", "");
				item.After = Regex.Replace(item.After, @"[ \t]", "");
				if (item.Before!=null && item.After!=null)
				{	Blimp.bigs.Add((item.Before + "," + item.After).Split(','));   }   }
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