using TMPro;
using UnityEngine;

namespace Balthazariy.Utilities
{
    public class TextWriterUtility
    {
        private TextMeshProUGUI _text;
        private int _characterIndex;
        private float _timePerCharacter;
        private float _timer;
        private string _textToWrite;
        private bool _isInvisibleCharacters;

        private bool _isActive;

        public TextWriterUtility(TextMeshProUGUI text)
        {
            _text = text;
            _characterIndex = 0;

            _isActive = false;
        }

        public TextWriterUtility(TextMeshProUGUI text, string textToWrite, float timePerCharacter, bool isInvisibleCharacters)
        {
            _text = text;
            _timePerCharacter = timePerCharacter;
            _textToWrite = textToWrite;
            _isInvisibleCharacters = isInvisibleCharacters;
            _characterIndex = 0;

            _isActive = false;
        }

        public void Update()
        {
            if (_isActive)
            {
                _timer -= Time.deltaTime;

                if (_timer <= 0f)
                {
                    _timer += _timePerCharacter;
                    _characterIndex++;
                    string text = _textToWrite.Substring(0, _characterIndex);

                    if (_isInvisibleCharacters)
                        text += "<color=#00000000>" + _textToWrite.Substring(_characterIndex) + "</color>";

                    _text.text = text;

                    if (CheckEndWriter())
                        StopWriter();
                }
            }
        }

        public void SetWriterSettings(string textToWrite, float timePerCharacter, bool isInvisibleCharacters)
        {
            _timePerCharacter = timePerCharacter;
            _textToWrite = textToWrite;
            _isInvisibleCharacters = isInvisibleCharacters;
            _characterIndex = 0;

            _isActive = false;
        }

        public void StartWriter()
        {
            _isActive = true;
        }

        public bool CheckEndWriter()
        {
            if (_characterIndex >= _textToWrite.Length) return true;
            return false;
        }

        public void StopWriter()
        {
            _isActive = false;
        }

        public void SkipWriter()
        {
            _isActive = false;

            _text.text = _textToWrite;
        }
    }
}