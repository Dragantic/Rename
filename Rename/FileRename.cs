using System;
using System.IO;

namespace Rename {
    public class FileRename {
		private string _newSize;

		public DateTime   mod { get; set; }
		public string   fapth { get; set; }
		public string   folds { get; set; }
		public string   extra { get; set; }
		public bool    isTaut { get; set; }
		public bool   isThick { get; set; }
        public bool   hasTwin { get; set; }
		public bool    isTrap { get; set; }
		public string oldSize { get; set; }
		public string newSize {
			get { return _newSize; }
			set
			{	if ((isTaut = (File.Exists(fapth + value + extra))))
				{	int groan = 0;
					do groan++;
					while (File.Exists(fapth + value + "(" + groan + ")" + extra));
					_newSize = value + "(" + groan + ")";   }
				else _newSize = value;   }
		}

		public FileRename (FileInfo info) {
				mod = info.LastWriteTime;
			oldSize = info.Name;
			  fapth = info.Directory.FullName + @"\";
			  folds = info.Directory.Name;
			  extra = info.Extension;
		}

		public void Boom() {
			try { File.Move(fapth + oldSize, fapth + _newSize + extra); } catch {}
		}
	}
}
