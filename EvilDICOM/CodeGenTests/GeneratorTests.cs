using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.CodeGenerator;
using Xunit;
using Xunit.Abstractions;
using static EvilDICOM.CodeGenerator.GeneratorInstance;

namespace EvilDICOM.CodeGeneratorTests
{
    public class GeneratorTests
    {
        private ITestOutputHelper _output;

        public GeneratorTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestTagDictionary()
        {
            var dictEntries = DicomDefinitionLoader.LoadCurrentDictionary()
                .Where(d => !string.IsNullOrEmpty(d.Keyword))
                .Take(5)
                .ToList();

            
        }
    }
}
