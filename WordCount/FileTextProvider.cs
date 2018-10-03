using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordCount
{
    class FileTextProvider : ITextProvider
    {
        private readonly string _fileName;

        public FileTextProvider(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<string> GetText()
        {
            return File.ReadLines(_fileName);
        }
    }
}
