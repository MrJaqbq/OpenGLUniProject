﻿using System.Collections.Generic;
using ObjParserNet.Core;
using ObjParserNet.Parser.File;
using ObjParserNet.Parser.Parsing;

namespace ObjParserNet.Parser
{
    public class Parser
    {
        private readonly IFileLoader _fileLoader;
        private readonly IParsingService _parsingService;

        public Parser()
        {
            _fileLoader = new FileLoader();
            _parsingService = new ParsingService();
        }

        internal Parser(IFileLoader fileLoader, IParsingService parsingService)
        {
            _fileLoader = fileLoader;
            _parsingService = parsingService;
        }

        public Mesh LoadMesh(string path)
        {
            var mesh = new Mesh();

            IEnumerable<string> lines = _fileLoader.LoadFile(path);

            foreach (string line in lines)
            {
                _parsingService.ProcessLine(line, mesh);
            }

            return mesh;
        }
    }
}