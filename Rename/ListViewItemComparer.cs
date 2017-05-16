using System;
using System.Collections;
using System.Windows.Forms;

namespace Rename {
	class ListViewItemComparer : IComparer {
		private int col;
		private SortOrder order;

		public ListViewItemComparer() {
			col = 0;
			order = SortOrder.Ascending;
		}

		public ListViewItemComparer(int column, SortOrder order) {
			col = column;
			this.order = order;
		}

		public int Compare(object x, object y) {
			int returnVal = 0;
			if (col == 0)
			{	DateTime firstDate = DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
				DateTime secondDate = DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
				returnVal = DateTime.Compare(firstDate, secondDate);   }
			else
			{	returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
										   ((ListViewItem)y).SubItems[col].Text);   }
			if (order == SortOrder.Descending) returnVal *= -1;
			return returnVal;
		}
	}
}
