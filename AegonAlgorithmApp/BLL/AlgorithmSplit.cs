using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AegonAlgorithmApp
{
    public class AlgorithmSplit
    {
        private string _word;
        private string _formattedInputPhrase;
        private string _substringBeforeFirstSpecialChar;
        private string _inputPhrase;
        private char _previousChar;
        private char _currentChar;
        private List<SpecialCharacters> _specialCharactersList;
        private List<string> _outputStringList;
        public AlgorithmSplit()
        {
            _word = string.Empty;
            _formattedInputPhrase = string.Empty;
            _substringBeforeFirstSpecialChar = string.Empty;
            _inputPhrase = string.Empty;
            _previousChar = new char();
            _currentChar = new char();
            _specialCharactersList = new List<SpecialCharacters>();
            _outputStringList = new List<string>();
        }

        public List<string> SplitCustomString(string inputPhrase)
        {
            _inputPhrase = inputPhrase;
            ObtainListOfSpecialCharactersFromString();
            ObtainSubstringBeforeFirstSpecialCharacter();
            RegexReplaceMultipleSpacesFromString();
            FormattedInputPhrase();
            
            for (int i = 0; i < _formattedInputPhrase.Length; i++)
            {
                if (i == 0)
                {
                    //first iteration i=0
                    _previousChar = _formattedInputPhrase[i];
                    _word += _previousChar;
                    continue;
                }
                else if (i >= 1 && i < _formattedInputPhrase.Length - 1)
                {
                    //iterations between i = 1 and length -1
                    _currentChar = _formattedInputPhrase[i];
                    LogicPrevCharCurrentChar();
                }
                else
                {
                    _currentChar = _formattedInputPhrase[i];
                    //last iteration 
                    LogicPrevCharCurrentChar(true);
                }
                _previousChar = _currentChar;
            }
            return _outputStringList;
        }

        #region Utilities
            private void ObtainSubstringBeforeFirstSpecialCharacter()
            {
                if (_specialCharactersList != null && _specialCharactersList.Count >= 2)
                    _substringBeforeFirstSpecialChar = _inputPhrase.Substring(0, _specialCharactersList[0].IndexInString);
            }

            private void ObtainListOfSpecialCharactersFromString()
            {
                _specialCharactersList = _inputPhrase
                                        .Select((f, index) => new SpecialCharacters { SpecialChar = f, IndexInString = index })
                                        .Where(c => !char.IsLetterOrDigit(c.SpecialChar) && !char.IsWhiteSpace(c.SpecialChar))
                                        .ToList();
            }

            private void FormattedInputPhrase()
            {
                if (_inputPhrase != null && _inputPhrase != string.Empty)
                {
                    if (_substringBeforeFirstSpecialChar != string.Empty)
                    {
                        _formattedInputPhrase += _substringBeforeFirstSpecialChar;
                        _formattedInputPhrase += _specialCharactersList[0].SpecialChar;
                        _formattedInputPhrase += _inputPhrase.Substring(_inputPhrase.IndexOf(_specialCharactersList[0].SpecialChar) + 1);
                        _formattedInputPhrase += _substringBeforeFirstSpecialChar;
                    }
                    else
                    {
                        _formattedInputPhrase = _inputPhrase;
                    }
                }
            }

            private void RegexReplaceMultipleSpacesFromString()
            {
                _inputPhrase = Regex.Replace(_inputPhrase, @"\s{2,}", " ");
            }

            private void LogicPrevCharCurrentChar(bool isLastIndex = false)
            {
                if ((char.IsLetterOrDigit(_previousChar) && !char.IsLetterOrDigit(_currentChar))
                    || (!char.IsLetterOrDigit(_previousChar) && char.IsLetterOrDigit(_currentChar)))
                {
                    _outputStringList.Add(_word);
                    _word = _currentChar.ToString();
                }
                else if ((char.IsWhiteSpace(_previousChar) && !char.IsWhiteSpace(_currentChar))
                    || (!char.IsWhiteSpace(_previousChar) && char.IsWhiteSpace(_currentChar)))
                {
                    _outputStringList.Add(_word);
                    _word = _currentChar.ToString();
                }
                else
                {
                    _word += _currentChar;
                }

                if (isLastIndex) _outputStringList.Add(_word);
            }
        #endregion
    }
}
