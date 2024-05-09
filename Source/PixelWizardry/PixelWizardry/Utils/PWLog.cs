using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public static class PWLog
    {
        public static Color ErrorMsgCol = new(0.4f, 0.54902f, 1.0f);
        public static Color WarningMsgCol = new(0.70196f, 0.4f, 1.0f);
        public static Color MessageMsgCol = new(0.4f, 1.0f, 0.54902f);

        public static void Error(string msg)
        {
            Log.Error("[Pixel Wizardry] ".Colorize(ErrorMsgCol) + msg);
        }

        public static void Warning(string msg)
        {
            Log.Warning("[Pixel Wizardry] ".Colorize(WarningMsgCol) + msg);
        }

        public static void Message(string msg)
        {
            Log.Message("[Pixel Wizardry] ".Colorize(MessageMsgCol) + msg);
        }
    }
}
