using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelWizardry
{
    public static class PWColorUtility
    {
        // checks if a color channel is approximately equal to a target value
        public static bool IsChannelApproximately(Color color, ColorChannel channel, float targetValue, float tolerance = 0.1f)
        {
            float channelValue = 0f;
            switch (channel)
            {
                case ColorChannel.Red:
                    channelValue = color.r;
                    break;
                case ColorChannel.Green:
                    channelValue = color.g;
                    break;
                case ColorChannel.Blue:
                    channelValue = color.b;
                    break;
                case ColorChannel.Alpha:
                    channelValue = color.a;
                    break;
            }

            return Mathf.Abs(channelValue - targetValue) < tolerance;
        }

        // checks for the color channel with the highest value and if the difference from other channels is greater than a threshold
        public static bool IsChannelHighestWithThreshold(Color color, ColorChannel channel, float threshold = 0.1f)
        {
            float highestValue = 0f;
            float channelValue = 0f;

            switch (channel)
            {
                case ColorChannel.Red:
                    highestValue = color.r;
                    channelValue = Mathf.Max(color.g, color.b, color.a);
                    break;
                case ColorChannel.Green:
                    highestValue = color.g;
                    channelValue = Mathf.Max(color.r, color.b, color.a);
                    break;
                case ColorChannel.Blue:
                    highestValue = color.b;
                    channelValue = Mathf.Max(color.r, color.g, color.a);
                    break;
                case ColorChannel.Alpha:
                    highestValue = color.a;
                    channelValue = Mathf.Max(color.r, color.g, color.b);
                    break;
            }

            return highestValue - channelValue > threshold;
        }
    }

    public enum ColorChannel
    {
        Red,
        Green,
        Blue,
        Alpha
    }
}
