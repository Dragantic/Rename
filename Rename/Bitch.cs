using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rename {
	class Bitch {
		DirectoryInfo face;
		List<FileInfo> goods;
		List<Bitch> kids = new List<Bitch>();
		Bitch parent;

		static List<FileInfo> _fam;
		public List<FileInfo> fam { get { return _fam; } }

		public Bitch(DirectoryInfo cute) {
			init(cute);
		}

		public Bitch(DirectoryInfo cute, Bitch breeder) {
			parent = breeder;
			init(cute);
		}

		public static void Burst() {
			_fam = new List<FileInfo>();
		}

		void init(DirectoryInfo cute) {
			face = cute;
			var belly = cute.GetDirectories().OrderBy(x =>
				Regex.Replace(x.Name.Replace(",", "").Replace("-", " - "),
					@"\d+", d => d.Value.PadLeft(8, '0'))).ToList();

			foreach (var kid in belly) kids.Add(new Bitch(kid, this));

			goods = cute.GetFiles().ToList();
			if (goods.Count > 0) _fam.AddRange(goods);
		}
	}
}
