using System;

namespace PixelWizardry
{
    public static class Main
    {
        static Main()
        {
            PWLog.Message($"[{DateTime.Now.Date.ToShortDateString()} " +
                          $"| 1.5 " +
                          $"| Older versions will no longer be maintained.]");
        }
    }
}