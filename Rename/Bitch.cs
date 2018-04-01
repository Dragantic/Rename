using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rename {
	class Bitch {
		DirectoryInfo face;
		List<FileInfo> goods;
		List<Bitch> kids;
		Bitch parent;

		static int _total=0;
		public int total { get { return _total; } }

		static List<List<FileInfo>> _fam = new List<List<FileInfo>>();
		public List<List<FileInfo>> fam { get { return _fam; } }

		public Bitch(DirectoryInfo cute) {
			init(cute);
		}

		public Bitch(DirectoryInfo cute, Bitch breeder) {
			parent = breeder;
			init(cute);
		}

		void init(DirectoryInfo cute) {
			face = cute;
			var belly = cute.GetDirectories().OrderBy(x =>
				Regex.Replace(x.Name.Replace(",", "").Replace("-", " - "),
					@"\d+", d => d.Value.PadLeft(8, '0'))).ToList();

			kids = new List<Bitch>();
			foreach (var kid in belly) kids.Add(new Bitch(kid, this));

			goods = cute.GetFiles().ToList();
			_total += goods.Count;
			if (goods.Count > 0) _fam.Add(goods);
		}
	}
}
