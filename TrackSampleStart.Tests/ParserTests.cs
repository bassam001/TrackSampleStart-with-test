using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackSampleStart.Parsers;

namespace TrackSampleStart.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void TimeParserTest()
        {
            const string data = "Ioc getting started 60min";

            var parser = new TalkParser();
            var result = parser.Time(data);

            Assert.IsTrue(parser.Success);
            Assert.AreEqual(60, result.TotalMinutes);
        }


        [TestMethod]
        public void StringMatchesGetMinutesParseTest()
        {
            const string data = "Writing Fast Tests Against Enterprise Rails 45min";

            var exp = new MinuteParser();
            var result = exp.Time(data);

            var wrongparser = new LightningParser();
            var wrongResult = wrongparser.Time(data);

            Assert.IsFalse(wrongparser.Success);
            Assert.AreEqual(0, wrongResult.TotalMinutes);

            Assert.IsTrue(exp.Success);
            Assert.AreEqual(45, result.TotalMinutes);
        }

        [TestMethod]
        public void StringMatchesLightningParserTest()
        {
            const string data = "Rails for Python Developers lightning";

            var exp = new LightningParser();
            var result = exp.Time(data);

            var wrongparser = new MinuteParser();
            var wrongResult = wrongparser.Time(data);

            Assert.IsFalse(wrongparser.Success);
            Assert.AreEqual(0, wrongResult.TotalMinutes);

            Assert.IsTrue(exp.Success);
            Assert.AreEqual(5, result.TotalMinutes);
        }
    }
}