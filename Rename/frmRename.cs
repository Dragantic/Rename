﻿using Rename.Properties;
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
					+ @"\.rename";
		DirectoryInfo bitchz = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
		List<FileInfo> hoez;
		List<FileRename> fatties;
		List<string[]> gainers;
		frmNames fNames;

		private void frmRename_Load(object sender, EventArgs e) {
			Location = Settings.Default.Location;
			fNames = new frmNames();
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
					if (done.IsMatch(line)) break;   } } }
		}

		private void frmRename_FormClosing(object sender, FormClosingEventArgs e) {
			Settings.Default.Location = Location;
			Settings.Default.Save();
		}

		private void chkSearch_CheckedChanged(object sender, EventArgs e) {
			txtBefore.Enabled = chkSearch.Checked;
		}

		private void btnCommit_Click(object sender, EventArgs e) {
			DialogResult result = MessageBox.Show
				("	Rename " + fatties.Count + " file"
				+ (fatties.Count == 1 ? "" : "s") + "?",
				"Rename", MessageBoxButtons.OKCancel);
			if (result.Equals(DialogResult.OK))
			{	foreach (FileRename creak in fatties) creak.Boom();
				Application.Exit();   }
		}

		private void btnRemove_Click(object sender, EventArgs e) {
			foreach (ListViewItem tightClothes in lsvBlimps.SelectedItems)
			{	fatties.Remove(fatties.Find
					(body => body.newSize == tightClothes.SubItems[2].Text));
				lsvBlimps.Items.Remove(tightClothes);   }
			lblMates.Text = nMates();
			if (fatties.Count == 0) btnCommit.Enabled = false;
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			foreach (ListViewItem thin in lsvBlimps.SelectedItems)
			{	FileRename skinny = fatties.Find
					(body => body.newSize == thin.SubItems[2].Text);
				try
				{	FileSystem.DeleteFile(skinny.fapth + skinny.oldSize,
						UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);   }
				catch {}
				fatties.Remove(skinny);
				lsvBlimps.Items.Remove(thin);   }
			lblMates.Text = nMates();
			if (fatties.Count == 0) btnCommit.Enabled = false;
		}

		private void PressEnter(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char)Keys.Return) { Fill(); e.Handled=true; }
		}

		private void Rescan(object sender, EventArgs e) {
			Fill();
		}

		Regex fillFA, fillDA;
		string puddinFA = @"^(?:\d{10}\..+)*(?<tag>\d{10})[\._-]"
						+ @"(?<artist>[\.\~a-zA-Z0-9-]+)_[_-]*"
						+ @"(?<title>([\._-]*(?!png$|jp(e)?g$|gif$|swf$)"
						+ @"([\(\)\[\]\{\}a-zA-Z0-9+!,]|[^\x00-\x80]))+)";

		string puddinDA = @"^_*(?<title>([_-]*[\(\)a-zA-Z0-9+!])+)"
						+ @"_*_by_(?<artist>([_-]*[\(\)a-zA-Z0-9+!])+)"
						+ @"-(?<tag>[a-zA-Z0-9]{7})";

		public void Ogle() {
			if (chkSearch.Checked)
			{	Regex rgx = new Regex("[\\.+]");
				string search = "^" + rgx.Replace(txtBefore.Text, "\\$&");
				search = search.Replace("[artist]", @"(?<artist>(-*[\~a-zA-Z0-9])+)");
				search = search.Replace("[title]", @"(?<title>([\._-]*(?!png|jp(e)?g|gif|swf)"
												 + @"([\(\)\[\]\{\}a-zA-Z0-9+!]|[^\x00-\x80]))+)");
				search = search.Replace("[tag]", @"(?<tag>\d{10})");
				fillFA = new Regex(search, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));

				search = "^" + rgx.Replace(txtBefore.Text, "\\$&");
				search = search.Replace("[artist]", @"(?<artist>[a-zA-Z0-9-]+)");
				search = search.Replace("[title]", @"(?<title>([_-]*[\(\)a-zA-Z0-9+!])+)");
				search = search.Replace("[tag]", @"(?<tag>[a-zA-Z0-9]{7})");
				fillDA = new Regex(search, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));   }
			else
			{	fillFA = new Regex(puddinFA, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));
				fillDA = new Regex(puddinDA, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));   }

			if (chkNameSwap.Checked && File.Exists(pimp))
			{ using (StreamReader sr = new StreamReader(pimp))
			  { string line;
				bool begin=false;
				gainers = new List<string[]>();
				while ((line = sr.ReadLine()) != null)
				{	if (!begin)
					{	if (Regex.IsMatch(line, "-{3,}")) begin=true;
						continue;   }
					string[] names = line.Split(',');
					if (names.Length>1) gainers.Add(names);   } } }

			pbar.Value = 0;
			btnRescan.Enabled = (btnRemove.Enabled = (btnDelete.Enabled = false));
			lsvBlimps.Items.Clear();
			hoez = bitchz.GetFiles().ToList();
			if (chkSubFolders.Checked)
			{	List<DirectoryInfo> moar = bitchz.GetDirectories().ToList();
				foreach (DirectoryInfo bigger in moar)
					hoez.AddRange(bigger.GetFiles().ToList());   }
			pbar.Maximum = hoez.Count;
		}

		public void Fill() {
			Ogle();
			fatties = Bloated(hoez);
			foreach (FileRename mate in fatties)
			{	ListViewItem mass = new ListViewItem(mate.mod.ToString());
				mass.SubItems.AddRange(new string[]
				{	mate.oldSize, mate.newSize, mate.isTaut.ToString(),
					mate.isThick.ToString(), mate.hasTwin.ToString()   });
				lsvBlimps.Items.Add(mass);   }

			if (fatties.Count > 0)
				colRename.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			
			foreach (ListViewItem mass in lsvBlimps.Items)
			{	mass.SubItems[1].Text += "\n" + mass.SubItems[2].Text;
				if (mass.SubItems[3].Text == "True")
				{	mass.SubItems[1].Text += "\nDUPLICATE";
					mass.BackColor = Color.LightSalmon;   }

				if (mass.SubItems[4].Text == "True")
					mass.BackColor = Color.LightYellow;

				if (mass.SubItems[5].Text == "True")
					mass.BackColor = Color.Lavender;   }

			lsvBlimps.Sorting = SortOrder.Ascending;
			datAss = 00;
			ShakeDat();
			btnRescan.Enabled = true;
			btnCommit.Enabled = (fatties.Count > 0);
			lblMates.Text = nMates();
			lsvBlimps.Focus();
		}

		int datAss;
		public void ShakeDat() {
			lsvBlimps.ListViewItemSorter = new ListViewItemComparer(datAss, lsvBlimps.Sorting);
			lsvBlimps.Sort();
		}

		public string nMates() {
			return (fatties.Count > 0 ? fatties.Count.ToString() : "no")
				 + " match" + (fatties.Count == 1 ? "" : "es");
		}

		public List<FileRename> Bloated(List<FileInfo> ass) {
			List<FileRename> blimps = new List<FileRename>();
			foreach (FileInfo pump in ass)
			{	FileRename blimp = new FileRename(pump);
				string oldSize = Path.GetFileNameWithoutExtension(pump.Name);
				string newSize = "BOOM";

				blimp.hasTwin = (Regex.IsMatch(oldSize, @"\([0-9]+\)$"));

				try
				{	foreach (Match figured in fillFA.Matches(oldSize))
						newSize = Full(figured);
					if (newSize == "BOOM")
						foreach (Match figured in fillDA.Matches(oldSize))
							newSize = Full(figured);   }
				catch (RegexMatchTimeoutException)
				{	blimp.newSize = "--------TIMED-OUT--------";   }

				string name = (newSize == "BOOM") ? oldSize : newSize;

				if (chkNameSwap.Checked)
				{	foreach (string[] models in gainers)
					{	if (blimp.isThick) break;
						string bbw = models[models.Length - 1];
						for (int i = 0; i < models.Length - 1; i++)
							if (name.StartsWith(models[i]))
							{	name = name.Replace(models[i], bbw);
								blimp.isThick = true; break;   }   }
					if (blimp.isThick) newSize = name;   }

				if (chkFolderName.Checked)
				{	if (blimp.folds == "@")
						newSize = blimp.folds + name;
					else newSize = blimp.folds + "_" + name;   }

				if (newSize != "BOOM" && oldSize != "Rename")
				{	blimp.newSize = newSize;
					if (chkDuplicates.Checked || !blimp.isTaut) blimps.Add(blimp);   }
				pbar.PerformStep();   }
			return blimps;
		}

		public string Full(Match figured) {
			string tits = figured.Groups["tag"].ToString(),
				    gut = figured.Groups["title"].ToString(),
				   butt = figured.Groups["artist"].ToString(),
				   zaft = "";

			gut = Regex.Replace(gut, "_(?<ltr>(s|t|re))_", "'${ltr}_");
			gut = Regex.Replace(gut, "_{2,}", "_");
			butt = butt.Replace("_", "-");

			zaft = txtAfter.Text;
			zaft = zaft.Replace("[tag]", tits);
			zaft = zaft.Replace("[title]", gut);
			zaft = zaft.Replace("[artist]", butt);

			return zaft;
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
				if (bitch.SubItems[3].Text == "False" && bitch.SubItems[5].Text == "False")
				{	canRemove = false; break;   }
			btnDelete.Enabled = canRemove;
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
			{	FileRename pig = fatties.Find
					(body => body.newSize == lsvBlimps.SelectedItems[0].SubItems[2].Text);
				if (File.Exists(pig.fapth + pig.oldSize))
					OpenFolderAndSelectFile(pig.fapth + pig.oldSize);   }
		}

		private void btnNames_Click(object sender, EventArgs e) {
			if (!fNames.IsDisposed)
			{	fNames.Show();
				fNames.Focus();   }
			else
			{	fNames = new frmNames();
				fNames.Show();   }
		}

		private void chkNameSwap_CheckedChanged(object sender, EventArgs e) {
			btnNames.Enabled = chkNameSwap.Checked;
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