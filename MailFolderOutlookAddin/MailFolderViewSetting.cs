using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFolderOutlookAddin
{
    public static class MailFolderViewSetting
    {
        public static float BaseDpi { get; set; } = 96.0f;
        public static float CurrentAwarenessDpi { get; set; } = 96.0f;
        public static float CurrentGraphicsDpi { get; set; } = 96.0f;
        public static float BaseFontSize { get; set; } = 9f;
        public static float BaseSmallFontSize { get; set; } = 7f;
        public static float CurrentDpiScale => CurrentAwarenessDpi / BaseDpi;
        public static float CurrentGraphicsScale => CurrentAwarenessDpi / CurrentGraphicsDpi;
        public static float ScaledFontSize => BaseDpi * CurrentDpiScale;
        public static float ScaledGraphicFontSize => BaseFontSize * CurrentGraphicsScale;
        public static float ScaledGraphicSmallFontSize => BaseSmallFontSize * CurrentGraphicsScale;
    }
}
