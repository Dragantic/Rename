using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Rename {
	public class Blimp {

		static Regex fillFA, fillDA;
		static string puddinFA = @"^(?:\d{10}\..+)*(?<tag>\d{10})[\._-]"
							   + @"(?<artist>[\.\~a-zA-Z0-9-]+)_[_-]*"
							   + @"(?<title>([\._-]*(?!(png|jp(e)?g|gif|swf)$)"
							   + @"([\(\)\[\]\{\}a-zA-Z0-9+%!,]|[^\x00-\x80]))+)";

		static string puddinDA = @"^_*(?<title>([_-]*[\(\)a-zA-Z0-9+!])+)"
							   + @"_*_by_(?<artist>([_-]*[\(\)a-zA-Z0-9+!])+)"
							   + @"-(?<tag>[a-zA-Z0-9]{7})$";
		static List<string[]> gainers;
		static string befr, aftr;
		static bool fld, dup, ext;
		string folds;

		public DateTime   mod { get; }
		public string   fapth { get; }
		public string   extra { get; }
		public bool    isTaut { get; private set; }
		public bool   isThick { get; }
        public bool   hasTwin { get; }
		public bool    isTrap { get; }
		public string	  sml { get; }

		string _big;
		public string big {
			get { return _big; }
			set
			{	if ((isTaut = (File.Exists(fapth + value + extra))))
				{	int groan = 0;
					do groan++;
					while (File.Exists(fapth + value + "("+groan+")" + extra));
					_big = value + "("+groan+")";   }
				else _big = value;   }
		}

		public static void Swell(string before, string after,
			bool manual, bool folds, bool dups, bool exts) {
			befr = before;
			aftr = after;
			fld = folds;
			dup = dups;
			ext = exts;
			if (manual)
			{	Regex rgx = new Regex(@"[\.+]");
				string search = "^" + rgx.Replace(befr, @"\$&");
				search = search.Replace("[artist]", @"(?<artist>[\.\~a-zA-Z0-9-]+)");
				search = search.Replace("[title]", @"(?<title>([\._-]*(?!(png|jp(e)?g|gif|swf)$)"
											+ @"([\(\)\[\]\{\}a-zA-Z0-9+%!,]|[^\x00-\x80]))+)");
				search = search.Replace("[tag]", @"(?<tag>\d{10})");
				fillFA = new Regex(search, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));

				search = "^" + rgx.Replace(befr, @"\$&");
				search = search.Replace("[artist]", @"(?<artist>[a-zA-Z0-9-]+)");
				search = search.Replace("[title]", @"(?<title>([_-]*[\(\)a-zA-Z0-9+!])+)");
				search = search.Replace("[tag]", @"(?<tag>[a-zA-Z0-9]{7})");
				fillDA = new Regex(search, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));   }
			else
			{	fillFA = new Regex(puddinFA, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));
				fillDA = new Regex(puddinDA, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));   }
		}

		public static void Feed(List<string[]> fed) {
			gainers = fed;
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

			if (gainers.Count > 0)
			{	foreach (string[] models in gainers)
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

			if (med != "BOOM" && sml != "Rename")
			{	if (dup || !isTaut)
				{	sml += extra;
					if (ext)
					{	string head = GetHeader();
						if (extra != head)
						{	extra = head;
							isTrap = true;   }   }
					big = med;   }   }
		}

		static string Full(Match figured) {
			string tits = figured.Groups["tag"].ToString(),
					gut = figured.Groups["title"].ToString(),
				   butt = figured.Groups["artist"].ToString(),
				   zaft = "";

			gut = Regex.Replace(gut, "_(?<ltr>(s|t|re|m))_", "'${ltr}_");
			gut = Regex.Replace(gut, "_{2,}", "_");
			butt = butt.Replace("_", "-");

			zaft = aftr;
			zaft = zaft.Replace("[tag]", tits);
			zaft = zaft.Replace("[title]", gut);
			zaft = zaft.Replace("[artist]", butt);

			return zaft;
		}

		string GetHeader() {
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
			try { File.Move(fapth + sml, fapth + big + extra); } catch {}
		}
	}
}
