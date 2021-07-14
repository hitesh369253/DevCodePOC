using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
namespace DevCodePOC.UITest
{
    public class TabChildSlidePage : TestFixtureBase
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="platform"></param>
        public TabChildSlidePage(Platform platform) : base(platform) { }
        #endregion

        #region Test - VerifyTextDisplaySaveInNewCommodity
        /// <summary>
        /// VerifyTextDisplaySaveInNewCommodity is verify the Save label text in new client commodity pop-up page
        /// </summary>
        [Test]
        public void VerifyTextDisplaySaveInNewCommodity()
        {
            App.WaitForElement(c => c.Marked("entryAutomationId"));
            App.Query(x => x.Marked("entryAutomationId").Text("a"));
            App.Screenshot("Items View initial");
        }
        #endregion
    }
   
}
