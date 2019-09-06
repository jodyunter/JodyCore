using System;
using System.Collections.Generic;
using System.Text;

namespace Jody.Test.Unit.Utility
{
    //use this to get predicatable responses
    public class NotRandom:Random
    {
        private int _counter = 0;
        private readonly List<int> _numberList;

        public NotRandom(List<int> numberList)
        {
            _numberList = numberList;
        }
        public override int Next(int maxValue)
        {
            if (_counter > _numberList.Count)
            {
                _counter = 0;
            }

            return _numberList[_counter];
        }
    }
}
