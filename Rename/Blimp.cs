using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Rename {
	public class Blimp {

		static Regex fillFA, fillDA, bsty;
		static string fabust = @"(?<tag>\d{10})[\._-](?<artist>[\.\~0-9A-Za-z-]+)";
		static string puddinFA = @"^(?<pre>\d{10}\..+)*"+fabust+"_[_-]*"
							   + @"(?<title>(?:[_-]*(?!\.(?:png|jpe?g|gif|swf)$)"
							   + @"(?:[\.\(\)\[\]\{\}\p{L}0-9A-Za-z+%!,]|[^\x00-\x80]))+)";

		static string puddinDA = @"^(?<pre>)_*(?<title>(?:[_-]*[\(\)0-9A-Za-z+!])+)"
							   + @"_*_by_(?<artist>(?:[_-]*[\(\)0-9A-Za-z+!])+)"
							   + @"[_-](?<tag>[0-9A-Za-z]{7}(?![0-9A-Za-z]+)(?:-pre)?)";

		public static List<string[]> bigs;
		static string befr, aftr;
		static bool fld, dup, ext, frc;
		string folds;

		public DateTime   mod { get; }
		public string   fapth { get; }
		public string   extra { get; }
		public bool    isTaut { get; private set; }
		public bool   isThick { get; }
        public bool   hasTwin { get; }
		public bool    isTrap { get; }
		public string	  sml { get; }
		public string	  big { get; }

		public static void Swell(string before, string after,
			bool manual, bool folds, bool dups, bool exts, bool force) {
			befr = before;
			aftr = after;
			fld = folds;
			dup = dups;
			ext = exts;
			frc = force;
			if (manual)
			{	Regex rgx = new Regex(@"[\.+]");
				string search = "^" + rgx.Replace(befr, @"\$&");
				search = search.Replace("[artist]", @"(?<artist>[\.\~0-9A-Za-z-]+)");
				search = search.Replace("[title]", @"(?<title>(?:[_-]*(?!\.(?:png|jpe?g|gif|swf)$)"
									+ @"(?:[\.\(\)\[\]\{\}\p{L}0-9A-Za-z+%!,]|[^\x00-\x80]))+)");
				search = search.Replace("[tag]", @"(?<tag>\d{10})");
				fillFA = new Regex(search, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));

				search = "^" + rgx.Replace(befr, @"\$&");
				search = search.Replace("[artist]", @"(?<artist>[0-9A-Za-z-]+)");
				search = search.Replace("[title]", @"(?<title>(?:[_-]*[\(\)0-9A-Za-z+!])+)");
				search = search.Replace("[tag]", @"(?<tag>(?!fullview)[0-9A-Za-z]{7}(?:-pre)?)");
				fillDA = new Regex(search, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));   }
			else
			{	fillFA = new Regex(puddinFA, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));
				fillDA = new Regex(puddinDA, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));   }
			bsty = new Regex (fabust, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));
		}

		public Blimp (FileInfo info) {
			mod = info.LastWriteTime;
			fapth = info.Directory.FullName + @"\";
			folds = info.Directory.Name;
			extra = info.Extension;

			sml = Path.GetFileNameWithoutExtension(info.Name);
			string med = "BOOM";

			hasTwin = (Regex.IsMatch(sml, @"\([0-9]+\)$"));

			try
			{	foreach (Match figured in fillFA.Matches(sml))
					med = Full(figured);
				if (med == "BOOM")
					foreach (Match figured in fillDA.Matches(sml))
						med = Full(figured);   }
			catch (RegexMatchTimeoutException)
			{	med = "--------TIMED-OUT--------";   }

			string name = (med == "BOOM") ? sml : med;
			sml += extra;

			if (bigs.Count > 0)
			{	foreach (string[] models in bigs)
				{	if (isThick) break;
					string bbw = models[models.Length - 1];
					for (int i = 0; i < models.Length - 1; i++)
						if (name.StartsWith(models[i]))
						{	name = name.Replace(models[i], bbw);
							isThick = true; break;   }   }
				if (isThick) med = name;   }

			if (fld)
			{	if (folds == "@")
				med = folds + name;
				else med = folds + "_" + name;   }

			string head = "";
			if (frc)
			{	head = GetHead();
				if (extra != head)
				{	extra = head;
					isTrap = true;
					med = name;   }   }

			if (med != "BOOM")
			{	if (ext && !frc)
				{	head = GetHead();
					if (extra != head)
					{	extra = head;
						isTrap = true;   }   }
				if (File.Exists(fapth + med + extra))
					isTaut = !((ext || frc) && isTrap &&
									info.Extension.ToLower() == extra.ToLower());
				if (dup || !isTaut)
				{	if (isTaut)
					{	int groan = 0;
						do groan++;
						while (File.Exists(fapth + med + "("+groan+")" + extra));
						big = med + "("+groan+")" + extra;   }
					else big = med + extra;   }   }
		}

		static string Full(Match figured) {
			string pre = figured.Groups["pre"].ToString(),
				  tits = figured.Groups["tag"].ToString(),
				   gut = figured.Groups["title"].ToString(),
				  butt = figured.Groups["artist"].ToString(),
				  zaft = "";

			gut = Regex.Replace(gut, "_(?<ltr>(s|t|re|m))_", "'${ltr}_");
			gut = Regex.Replace(gut, "_{2,}", "_");
			butt = butt.Replace("_", "-");

			if (pre != "")
			{	MatchCollection jizz = bsty.Matches(pre);
				for (int i=jizz.Count-1; i>=0; i--)
				{	Match cum = jizz[i];
					string also = cum.Groups["artist"].ToString();
					butt += "_" + also;   }   }

			zaft = aftr;
			zaft = zaft.Replace("[tag]", tits);
			zaft = zaft.Replace("[title]", gut);
			zaft = zaft.Replace("[artist]", butt);

			return zaft;
		}

		string GetHead() {
			try
			{	string full = fapth + sml;
				using (BinaryReader br = new BinaryReader(File.Open(full, FileMode.Open)))
				{	UInt16 soi = br.ReadUInt16();  // Start of Image (SOI) marker (FFD8)
					UInt16 marker = br.ReadUInt16(); // JFIF marker (FFE0) or EXIF marker(FF01)
					if (soi == 0xd8ff && (marker & 0xe0ff) == 0xe0ff) return ".jpg";
					else if (soi == 0x5089 && marker == 0x474e) return ".png";
					else return extra;   }   }
			catch { return extra; }
		}

		public void Boom() {
			try { File.Move(fapth + sml, fapth + big); } catch {}
		}
	}
}
