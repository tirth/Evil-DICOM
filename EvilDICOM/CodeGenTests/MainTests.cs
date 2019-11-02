using System.Threading.Tasks;
using EvilDICOM.CodeGenerator;
using Xunit;
using Xunit.Abstractions;

namespace EvilDICOM.CodeGeneratorTests
{
    public class MainTest
    {
        private const string OutputDir = @"C:\Users\Tirth\Downloads\dicom_nema\EvilOutput";

        private readonly ITestOutputHelper _output;

        public MainTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestStuff()
        {

        }

        [Fact]
        public async Task TestDownloadDefinitions()
        {
            await DicomDefinitionLoader.DownloadCurrentDefinitions();
        }

        [Fact]
        public void TestSopClassBuilder()
        {
            SopClassUidBuilder.BuildSopClassUids(OutputDir);
        }

        [Fact]
        public void TestSopEnumBuilder()
        {
            SopClassUidBuilder.BuildSopClassEnum(OutputDir);
        }

        [Fact]
        public void TestSopClassDictionaryBuilder()
        {
            SopClassUidBuilder.BuildSopClassDictionary(OutputDir);
        }

        [Fact]
        public void TestElementBuilder()
        {
            CodeGen.GenerateStuff(OutputDir);
        }

        [Fact]
        public void TestAnonStuff()
        {
            CodeGen.GenerateAnonStuff();
        }
    }
}
