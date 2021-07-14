using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace DevCodePOC.UITest
{
    //[TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public abstract class TestFixtureBase
    {
        protected IApp App => AppInitializer.App;
        protected bool OnAndroid => AppInitializer.Platform == Platform.Android;
        protected bool OniOS => AppInitializer.Platform == Platform.iOS;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="platform"></param>        
        protected TestFixtureBase(Platform platform)
        {
            AppInitializer.Platform = platform;
        }
        #endregion

        #region OneTimeSetUp
        /// <summary>
        /// OneTimeSetUp is called before all TestFixtures
        /// </summary>
        [OneTimeSetUp]
        protected virtual async Task BeforeTestSession()
            => await Task.CompletedTask;
        #endregion

        #region SetUp
        /// <summary>
        /// SetUp is used for the current TestFixture
        /// </summary>        
        [SetUp]
        protected virtual async Task BeforeEachTest()
        {
            AppInitializer.StartApp();
            await Task.CompletedTask;
        }
        #endregion

    }   
}
