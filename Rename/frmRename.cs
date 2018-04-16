using Rename.Properties;
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace Rename {
    public partial class frmRename : Form {
		public frmRename() {
			InitializeComponent();
		}

		string pimp = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
					+ @"\Documents\.rename";
		DirectoryInfo bitchz = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
		frmNames fNames = new frmNames();
		FolderSelectDialog fsd = new FolderSelectDialog();
		List<Blimp> fatties;
		
		private void frmRename_Load(object sender, EventArgs e) {
			txtPath.Text = fsd.InitialDirectory = bitchz.FullName;
			Location = Settings.Default.Location;
			Size = Settings.Default.Size;

			if (File.Exists(pimp))
			{ using (StreamReader sr = new StreamReader(pimp))
			  { string line, toggle;
				while ((line = sr.ReadLine()) != null)
				{	Match mate;
					Regex before = new Regex("before *: *(?<pref>.+)", RegexOptions.IgnoreCase);
					Regex after = new Regex("after *: *(?<pref>.+)", RegexOptions.IgnoreCase);
					Regex taut = new Regex("duplicates *: *(?<pref>.+)", RegexOptions.IgnoreCase);
					Regex moar = new Regex("subfolders *: *(?<pref>.+)", RegexOptions.IgnoreCase);
					Regex fldr = new Regex("foldername *: *(?<pref>.+)", RegexOptions.IgnoreCase);
					Regex swap = new Regex("nameswappr *: *(?<pref>.+)", RegexOptions.IgnoreCase);
					Regex echk = new Regex("extchecker *: *(?<pref>.+)", RegexOptions.IgnoreCase);
					Regex auto = new Regex("auto-close *: *(?<pref>.+)", RegexOptions.IgnoreCase);
					Regex done = new Regex("-{3,}");
					
					if (before.IsMatch(line))
					{	chkSearch.Checked = true;
						mate = before.Match(line);
						txtBefore.Text = mate.Groups["pref"].ToString().Trim();
						continue;   }
					if (after.IsMatch(line))
					{	mate = after.Match(line);
						txtAfter.Text = mate.Groups["pref"].ToString().Trim();
						continue;   }
					if (taut.IsMatch(line))
					{	mate = taut.Match(line);
						toggle = mate.Groups["pref"].ToString().Trim().ToLower();
						chkDuplicates.Checked = toggle.In("on", "yes");
						continue;   }
					if (moar.IsMatch(line))
					{	mate = moar.Match(line);
						toggle = mate.Groups["pref"].ToString().Trim().ToLower();
						chkSubFolders.Checked = toggle.In("on", "yes");
						continue;   }
					if (fldr.IsMatch(line))
					{	mate = fldr.Match(line);
						toggle = mate.Groups["pref"].ToString().Trim().ToLower();
						chkFolderName.Checked = toggle.In("on", "yes");
						continue;   }
					if (swap.IsMatch(line))
					{	mate = swap.Match(line);
						toggle = mate.Groups["pref"].ToString().Trim().ToLower();
						chkNameSwap.Checked = toggle.In("on", "yes");
						continue;   }
					if (echk.IsMatch(line))
					{	mate = echk.Match(line);
						toggle = mate.Groups["pref"].ToString().Trim().ToLower();
						chkExtChecker.Checked = toggle.In("on", "yes");
						continue;   }
					if (auto.IsMatch(line))
					{	mate = auto.Match(line);
						toggle = mate.Groups["pref"].ToString().Trim().ToLower();
						isAuto = toggle.In("on", "yes");
						continue;   }
					if (done.IsMatch(line)) break;   } } }
		}

		private void frmRename_Shown(object sender, EventArgs e) {
			Fill();
		}

		private void btnRescan_Click(object sender, EventArgs e) {
			Fill();
		}

		private void PressEnter(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char)Keys.Return) { Fill(); e.Handled=true; }
		}

		private void frmRename_FormClosing(object sender, FormClosingEventArgs e) {
			Settings.Default.Location = Location;
			Settings.Default.Size = Size;
			Settings.Default.Save();
		}

		List<Blimp> Bloated(List<FileInfo> gut) {
			List<Blimp> blimps = new List<Blimp>();
			foreach (FileInfo swell in gut)
			{	Blimp blimp = new Blimp(swell);
				if (blimp.big != null) blimps.Add(blimp);
				pbar.PerformStep();   }
			return blimps;
		}

		void Fill() {
			Blimp.Swell(txtBefore.Text, txtAfter.Text,
				chkSearch.Checked, chkFolderName.Checked,
				chkDuplicates.Checked, chkExtChecker.Checked, chkForce.Checked);
			List<string[]> pigs = new List<string[]>();
			if (chkNameSwap.Checked && File.Exists(pimp))
			{ using (StreamReader sr = new StreamReader(pimp))
			  { string line;
				bool begin=false;
				while ((line = sr.ReadLine()) != null)
				{	if (!begin)
					{	if (Regex.IsMatch(line, "-{3,}")) begin=true;
						continue;   }
					string[] names = line.Split(',');
					if (names.Length>1) pigs.Add(names);   } } }
			Blimp.bigs = pigs;

			pbar.Value = 0;
			btnRescan.Enabled = btnRemove.Enabled = btnRecycle.Enabled = false;
			lsvBlimps.Items.Clear();

			if (chkSubFolders.Checked)
			{	Bitch.Burst();
				Bitch moar = new Bitch(bitchz);
				pbar.Maximum = moar.fam.Count;
				fatties = Bloated(moar.fam);   }
			else
			{	List<FileInfo> hoez = bitchz.GetFiles().ToList();
				pbar.Maximum = hoez.Count;
				fatties = Bloated(hoez);   }

			foreach (Blimp mate in fatties)
			{	ListViewItem mass = new ListViewItem(mate.mod.ToString());
				mass.SubItems.AddRange(new string[]
				{   mate.sml, mate.big, mate.isTaut.ToString(), mate.hasTwin.ToString()   });

				if (mate.hasTwin) // has a (1) in the name
					mass.BackColor = Color.LightSkyBlue;

				else if (mate.isTaut) // newSize already exists
					mass.BackColor = Color.LightSalmon;

				else if (mate.isThick) // artist name changed
					mass.BackColor = Color.GreenYellow;

				else if (mate.isTrap) // extension changed
					mass.BackColor = Color.Gold;

				lsvBlimps.Items.Add(mass);   }

			if (fatties.Count > 0)
			{	colRename.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				colRename.Width += 20;   }
			
			foreach (ListViewItem mass in lsvBlimps.Items)
				mass.SubItems[1].Text += "\n" + mass.SubItems[2].Text;

			lsvBlimps.Sorting = SortOrder.Ascending;
			datAss = 00;
			ShakeDat();
			btnRescan.Enabled = true;
			btnCommit.Enabled = (fatties.Count > 0);
			lblMates.Text = nMates();
			lsvBlimps.Focus();
		}

		int datAss;
		void ShakeDat() {
			lsvBlimps.ListViewItemSorter = new ListViewItemComparer(datAss, lsvBlimps.Sorting);
			lsvBlimps.Sort();
		}

		string nMates() {
			return (fatties.Count > 0 ? fatties.Count.ToString() : "no")
				 + " match" + (fatties.Count == 1 ? "" : "es");
		}

		bool isAuto;
		private void btnCommit_Click(object sender, EventArgs e) {
			DialogResult result = MessageBox.Show
				("	Rename " + fatties.Count + " file"
				+ (fatties.Count == 1 ? "" : "s") + "?",
				"Rename", MessageBoxButtons.OKCancel);
			if (result.Equals(DialogResult.OK))
			{	foreach (Blimp creak in fatties) creak.Boom();
				if (isAuto)
					Application.Exit();
				else
				{	btnCommit.Enabled = btnRemove.Enabled = btnRecycle.Enabled = false;
					lsvBlimps.Items.Clear();   }   }
		}

		private void btnRemove_Click(object sender, EventArgs e) {
			foreach (ListViewItem tightClothes in lsvBlimps.SelectedItems)
			{	fatties.Remove(fatties.Find(body =>
					body.big == tightClothes.SubItems[2].Text));
				lsvBlimps.Items.Remove(tightClothes);   }
			lblMates.Text = nMates();
			if (fatties.Count == 0) btnCommit.Enabled = false;
		}

		private void btnRecycle_Click(object sender, EventArgs e) {
			foreach (ListViewItem thin in lsvBlimps.SelectedItems)
			{	Blimp skinny = fatties.Find(body =>
					body.big == thin.SubItems[2].Text);
				try
				{	FileSystem.DeleteFile(skinny.fapth + skinny.sml,
						UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);   }
				catch {}
				fatties.Remove(skinny);
				lsvBlimps.Items.Remove(thin);   }
			lblMates.Text = nMates();
			if (fatties.Count == 0) btnCommit.Enabled = false;
		}

		private void btnNames_Click(object sender, EventArgs e) {
			if (!fNames.IsDisposed)
			{	fNames.Show();
				fNames.Focus();   }
			else
			{	fNames = new frmNames();
				fNames.Show();   }
		}

		private void btnPath_Click(object sender, EventArgs e) {
			if (fsd.ShowDialog(IntPtr.Zero))
			{	txtPath.Text = fsd.FileName + @"\";
				bitchz = new DirectoryInfo(txtPath.Text);
				fsd.InitialDirectory = bitchz.Parent.FullName;
				Fill();   }
		}

		private void chkNameSwap_CheckedChanged(object sender, EventArgs e) {
			btnNames.Enabled = chkNameSwap.Checked;
		}

		private void chkSearch_CheckedChanged(object sender, EventArgs e) {
			txtBefore.Enabled = chkSearch.Checked;
		}

		bool handled;
		private void lsvBlimps_SelectedIndexChanged(object sender, EventArgs e) {
			if (!handled)
			{	handled = true;
				Application.Idle += SelectionChangeDone;   }
		}

		private void SelectionChangeDone(object sender, EventArgs e) {
			Application.Idle -= SelectionChangeDone;
			handled = false;

			bool canRemove = (lsvBlimps.SelectedItems.Count > 0);
			btnRemove.Enabled = canRemove;
			foreach (ListViewItem bitch in lsvBlimps.SelectedItems)
				if (bitch.SubItems[3].Text == "False" && bitch.SubItems[4].Text == "False")
				{	canRemove = false; break;   }
			btnRecycle.Enabled = canRemove;
		}

		private void lsvBlimps_ColumnClick(object sender, ColumnClickEventArgs e) {
			SortOrder top = SortOrder.Ascending; SortOrder bottom = SortOrder.Descending;
			int fat = (e.Column == 1) ? 2 : e.Column;
			if (datAss!=fat) { datAss=fat; lsvBlimps.Sorting = top; }
			else lsvBlimps.Sorting = (lsvBlimps.Sorting==top) ? bottom:top;
			ShakeDat();
		}

		private void lsvBlimps_DoubleClick(object sender, EventArgs e) {
			if (lsvBlimps.SelectedItems.Count == 1)
			{	Blimp pig = fatties.Find (body =>
					body.big == lsvBlimps.SelectedItems[0].SubItems[2].Text);
				if (File.Exists(pig.fapth + pig.sml))
					try { OpenFolderAndSelectFile(pig.fapth + pig.sml); } catch {}   }
		}

		public void OpenFolderAndSelectFile(string filePath) {
			if (filePath == null) throw new ArgumentNullException("filePath");
			IntPtr pidl = ILCreateFromPathW(filePath);
			SHOpenFolderAndSelectItems(pidl, 0, IntPtr.Zero, 0);
			ILFree(pidl);
		}

		[DllImport("shell32.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr ILCreateFromPathW(string pszPath);

		[DllImport("shell32.dll")]
		private static extern int SHOpenFolderAndSelectItems
			(IntPtr pidlFolder, int cild, IntPtr apidl, int dwFlags);

		[DllImport("shell32.dll")]
		private static extern void ILFree(IntPtr pidl);
	}
}