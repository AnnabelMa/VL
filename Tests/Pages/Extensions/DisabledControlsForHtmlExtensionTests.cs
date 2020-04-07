using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Facade.Quantity;
using VL1.Pages.Extensions;

namespace VL1.Tests.Pages.Extensions
{
    [TestClass]
    public class DisabledControlsForHtmlExtensionTests : BaseTests
    {
        [TestInitialize] public virtual void TestInitialize() => type = typeof(DisabledControlsForHtmlExtension);

        [TestMethod]
        public void DisabledControlsForTest()
        {
            //extension meetod:
            var obj = new htmlHelperMock<UnitView>().DisabledControlsFor(x => x.MeasureId);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> { "<div", "<fieldset disabled>", "LabelFor",
                "EditorFor", "ValidationMessageFor", "</fieldset>","</div>" };
            var actual = DisabledControlsForHtmlExtension.htmlStrings
                (new htmlHelperMock<MeasureView>(), x => x.Name);
            TestHtml.Strings(actual, expected);
        }
    }
}
