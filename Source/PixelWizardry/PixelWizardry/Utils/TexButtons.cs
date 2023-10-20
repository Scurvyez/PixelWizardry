using RimWorld;
using Verse;
using UnityEngine;

namespace PixelWizardry
{
    [StaticConstructorOnStartup]
    public static class TexButtons
    {
        public static readonly Texture2D BlackAndWhiteMode = ContentFinder<Texture2D>.Get("UI/Buttons/BlackAndWhiteMode");
        public static readonly Texture2D SepiaMode = ContentFinder<Texture2D>.Get("UI/Buttons/SepiaMode");
        public static readonly Texture2D SuperSaturatedMode = ContentFinder<Texture2D>.Get("UI/Buttons/SuperSaturatedMode");
        public static readonly Texture2D CyberpunkMode = ContentFinder<Texture2D>.Get("UI/Buttons/CyberpunkMode");
        public static readonly Texture2D RedMode = ContentFinder<Texture2D>.Get("UI/Buttons/RedMode");
        public static readonly Texture2D GreenMode = ContentFinder<Texture2D>.Get("UI/Buttons/GreenMode");
        public static readonly Texture2D BlueMode = ContentFinder<Texture2D>.Get("UI/Buttons/BlueMode");

        public static readonly Texture2D RadialGradientChange = ContentFinder<Texture2D>.Get("Map/Effects/RadialGradientChange");
        public static readonly Texture2D HeadLampTestingMask = ContentFinder<Texture2D>.Get("Map/Effects/HeadLampTestingMask");
    }
}
