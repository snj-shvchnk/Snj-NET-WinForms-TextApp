using SnjTextLib;
using SnjTextLib.Abstract;
using SnjTextLib.Base;
using System.ComponentModel;

namespace SnjTextLibTests
{
    [TestFixture]
    public class SnjTextProcessor
    {
        string? sample_1;
        string? filename_1;
        Dictionary<string, int> expect_1;

        string? sample_2;
        string? filename_2;
        Dictionary<string, int> expect_2;

        int replications_3;
        string? filename_3;
        Dictionary<string, int> expect_3;

        [SetUp]
        public void Setup()
        {
            sample_1 = @"Go do that thing that you do so well 333-222-11";
            sample_2 = @"Go do that Snj7/snj you thing do-do that you'r you do-do so well";

            filename_1 = Path.GetTempFileName();
            filename_2 = Path.GetTempFileName();
            filename_3 = Path.GetTempFileName();

            expect_1 = new Dictionary<string, int>() {
                { "Go", 1 },
                { "do", 2 },
                { "that", 2 },
                { "thing", 1 },
                { "you", 1 },
                { "so", 1 },
                { "well", 1 },
                { "333-222-11", 1 }
            };
            
            expect_2 = new Dictionary<string, int>() {
                { "Go", 1 },
                { "do", 1 },
                { "do-do", 2 },
                { "Snj7/snj", 1 },
                { "that", 2 },
                { "thing", 1 },
                { "you", 2 },
                { "you'r", 1 },
                { "so", 1 },
                { "well", 1 }
            };

            File.WriteAllText(filename_1, sample_1);
            File.WriteAllText(filename_2, sample_2);

            filename_3 = Path.GetTempFileName();
            replications_3 = 1000000;
            List<string> lines = new();

            expect_3 =
                new Dictionary<string, int>(
                    expect_2.ToDictionary(k => k.Key, v => 0)
                );

            while (replications_3-- > 0)
            {
                lines.Add(sample_2);
                foreach (var item in expect_3)
                    expect_3[item.Key] += expect_2[item.Key];
            }
            File.WriteAllLines(filename_3, lines);
        }

        [Test]
        public void ProcessText()
        {
            var p = SnjText.TextProcessor();
            Assert.IsNotNull(p);

            var s = p.Process(sample_1);
            Assert.That(s, Is.EqualTo(expect_1));
        }

        [Test]
        public void GetConfig()
        {
            var c = SnjText.Config;
            Assert.That(c, Is.Not.Null);
        }

        [Test]
        public void CreateProcessor()
        {
            var p = SnjText.TextProcessor();
            Assert.That(p, Is.Not.Null);
        }

        [Test]
        public void FileTest_LettersAndNumbers()
        {
            var p = SnjText.FileProcessor(
                new ProcessorConfig()
                {
                    AllowNumbers = true,
                    AcceptableChars = "-'".ToArray(),
                });

            var f = p.Process(filename_1);

            Assert.That(f, Is.Not.Null);
            Assert.That(f, Is.EqualTo(expect_1));
        }

        [Test]
        public void FileTest_LettersAnjSpecSymbols()
        {
            var f = SnjText.FileProcessor(
                new ProcessorConfig()
                {
                    AllowNumbers = true,
                    AcceptableChars = "-'/".ToArray(),
                })
                .Process(filename_2);

            Assert.That(f, Is.Not.Null);
            Assert.That(f, Is.EquivalentTo(expect_2));
        }

        [Test]
        public void FileTest_LooongFileParsing()
        {
            var f = SnjText.FileProcessor(
                new ProcessorConfig()
                {
                    AllowNumbers = true,
                    AcceptableChars = "-'/".ToArray(),
                })
                .Process(filename_3);

            Assert.That(f, Is.Not.Null);
            Assert.That(f, Is.EquivalentTo(expect_3));
        }
    }
}