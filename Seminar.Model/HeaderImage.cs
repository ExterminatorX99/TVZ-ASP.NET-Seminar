using System;

namespace Seminar.Model
{
    public class Image : File
    {
        private string _contentType;

        public override string ContentType
        {
            get => _contentType;
            set
            {
                if (_contentType.StartsWith("image/"))
                    _contentType = value;
                else
                    throw new ArgumentException(nameof(value));
            }
        }
    }
}
