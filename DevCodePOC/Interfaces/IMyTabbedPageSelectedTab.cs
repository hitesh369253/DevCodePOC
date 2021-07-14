using System;
using System.Collections.Generic;
using System.Text;

namespace DevCodePOC.Interfaces
{
    public interface IMyTabbedPageSelectedTab
    {
        int SelectedTab { get; set; }

        void SetSelectedTab(int tabIndex);
    }
}
