using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Infrastructure
{
    public class PageSplitter
    {
        private int pageWidth;
        private int pageHeight;
        private float lineSpacingMultiplier;
        private float lineSpacingExtra;

        //private List<CharSequence> pages = new ArrayList<CharSequence>();
        //private SpannableStringBuilder mSpannableStringBuilder = new SpannableStringBuilder()

        public PageSplitter(int pageWidth, int pageHeight, float lineSpacingMultiplier, float lineSpacingExtra)
        {
            this.pageWidth = pageWidth;
            this.pageHeight = pageHeight;
            this.lineSpacingMultiplier = lineSpacingMultiplier;
            this.lineSpacingExtra = lineSpacingExtra;
        }


    }
}
