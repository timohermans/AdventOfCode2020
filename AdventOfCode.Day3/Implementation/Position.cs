using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3.Implementation
{
    public record Position
    {
        private readonly char _positionCharacter;

        public bool IsOpen => _positionCharacter == '.';
        public bool IsTree => _positionCharacter == '#';

        public Position(char positionCharacter)
        {
            _positionCharacter = positionCharacter;
        }


    }
}
