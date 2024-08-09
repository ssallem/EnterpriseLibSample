using PrismEnterpriseSample.Framework;
using System.Windows;

namespace SioDepolyment.Forms.UI.Controls
{
    public class FilePathText : ViewBaseMef
    {
        static FilePathText()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FilePathText), new FrameworkPropertyMetadata(typeof(FilePathText)));
        }
    }
}
