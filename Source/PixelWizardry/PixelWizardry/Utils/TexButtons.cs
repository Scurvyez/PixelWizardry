using Verse;
using UnityEngine;

namespace PixelWizardry
{
    [StaticConstructorOnStartup]
    public static class TexButtons
    {
        public static readonly Texture2D AchromatomalyMode = ContentFinder<Texture2D>.Get("UI/Buttons/AchromatomalyMode");
        public static readonly Texture2D AchromatopsiaMode = ContentFinder<Texture2D>.Get("UI/Buttons/AchromatopsiaMode");
        public static readonly Texture2D DeuteranomalyMode = ContentFinder<Texture2D>.Get("UI/Buttons/DeuteranomalyMode");
        public static readonly Texture2D DeuteranopiaMode = ContentFinder<Texture2D>.Get("UI/Buttons/DeuteranopiaMode");
        public static readonly Texture2D ProtanomalyMode = ContentFinder<Texture2D>.Get("UI/Buttons/ProtanomalyMode");
        public static readonly Texture2D ProtanopiaMode = ContentFinder<Texture2D>.Get("UI/Buttons/ProtanopiaMode");
        public static readonly Texture2D TritanomalyMode = ContentFinder<Texture2D>.Get("UI/Buttons/TritanomalyMode");
        public static readonly Texture2D TritanopiaMode = ContentFinder<Texture2D>.Get("UI/Buttons/TritanopiaMode");

        public static readonly Texture2D _SecondaryTex = ContentFinder<Texture2D>.Get("_SecondaryTex");
    }
}
