using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.Infrastructure.Controls
{
    public class ImageWithLongPressGesture : Image
    {
        public EventHandler LongPressActivated;

        public void HandleLongPress(object sender, EventArgs e)
        {
            //Handle LongPressActivated Event
        }
    }
}
