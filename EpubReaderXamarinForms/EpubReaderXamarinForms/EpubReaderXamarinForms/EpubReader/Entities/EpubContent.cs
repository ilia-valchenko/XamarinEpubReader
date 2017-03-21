﻿using System.Collections.Generic;

namespace EpubReaderXamarinForms.EpubReader.Entities
{
    public class EpubContent
    {
        public Dictionary<string, EpubTextContentFile> Html { get; set; }
        public Dictionary<string, EpubTextContentFile> Css { get; set; }
        public Dictionary<string, EpubByteContentFile> Images { get; set; }
        public Dictionary<string, EpubByteContentFile> Fonts { get; set; }
        public Dictionary<string, EpubContentFile> AllFiles { get; set; }
    }
}
