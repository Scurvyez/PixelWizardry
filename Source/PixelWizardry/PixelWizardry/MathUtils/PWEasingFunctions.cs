using UnityEngine;

namespace PixelWizardry.MathUtils
{
    public static class PWEasingFunctions
    {
        public static float Linear(float t) => t;
        
        // Quadratic
        public static float EaseInQuad(float t) => t * t;
        public static float EaseOutQuad(float t) => t * (2 - t);
        public static float EaseInOutQuad(float t) => t < 0.5 ? 2 * t * t : -1 + (4 - 2 * t) * t;
        
        // Cubic
        public static float EaseInCubic(float t) => t * t * t;
        public static float EaseOutCubic(float t) => (--t) * t * t + 1;
        public static float EaseInOutCubic(float t) => t < 0.5 ? 4 * t * t * t : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1;
        
        // Quartic
        public static float EaseInQuart(float t) => t * t * t * t;
        public static float EaseOutQuart(float t) => 1 - (--t) * t * t * t;
        public static float EaseInOutQuart(float t) => t < 0.5 ? 8 * t * t * t * t : 1 - 8 * (--t) * t * t * t;
        
        // Quintic
        public static float EaseInQuint(float t) => t * t * t * t * t;
        public static float EaseOutQuint(float t) => 1 + (--t) * t * t * t * t;
        public static float EaseInOutQuint(float t) => t < 0.5 ? 16 * t * t * t * t * t : 1 + 16 * (--t) * t * t * t * t;
        
        // Sine
        public static float EaseInSine(float t) => 1 - Mathf.Cos(t * Mathf.PI / 2);
        public static float EaseOutSine(float t) => Mathf.Sin(t * Mathf.PI / 2);
        public static float EaseInOutSine(float t) => 0.5f * (1 - Mathf.Cos(Mathf.PI * t));
        
        // Exponential
        public static float EaseInExpo(float t) => t == 0 ? 0 : Mathf.Pow(2, 10 * (t - 1));
        public static float EaseOutExpo(float t) => Mathf.Approximately(t, 1) ? 1 : 1 - Mathf.Pow(2, -10 * t);
        public static float EaseInOutExpo(float t) => 
            t == 0 ? 0 : Mathf.Approximately(t, 1) ? 1 : t < 0.5 ? 0.5f * Mathf.Pow(2, 20 * t - 10) : 1 - 0.5f * Mathf.Pow(2, -20 * t + 10);
        
        // Circular
        public static float EaseInCirc(float t) => 1 - Mathf.Sqrt(1 - t * t);
        public static float EaseOutCirc(float t) => Mathf.Sqrt(1 - (--t) * t);
        public static float EaseInOutCirc(float t) => 
            t < 0.5 ? (1 - Mathf.Sqrt(1 - 4 * t * t)) / 2 : (Mathf.Sqrt(1 - (2 * t - 2) * (2 * t - 2)) + 1) / 2;
        
        // Elastic
        public static float EaseInElastic(float t) =>
            t == 0 ? 0 : Mathf.Approximately(t, 1) ? 1 : -Mathf.Pow(2, 10 * (t - 1)) * Mathf.Sin((t - 1.1f) * 5 * Mathf.PI);
        public static float EaseOutElastic(float t) =>
            t == 0 ? 0 : Mathf.Approximately(t, 1) ? 1 : Mathf.Pow(2, -10 * t) * Mathf.Sin((t - 0.1f) * 5 * Mathf.PI) + 1;
        public static float EaseInOutElastic(float t) => 
            t == 0 ? 0 : Mathf.Approximately(t, 1) ? 1 : t < 0.5 ? 
                -0.5f * Mathf.Pow(2, 10 * (2 * t - 1)) * Mathf.Sin((2 * t - 1.1f) * 5 * Mathf.PI) : 
                0.5f * Mathf.Pow(2, -10 * (2 * t - 1)) * Mathf.Sin((2 * t - 1.1f) * 5 * Mathf.PI) + 1;
        
        // Back
        public static float EaseInBack(float t) 
        {
            const float s = 1.70158f;
            return t * t * ((s + 1) * t - s);
        }
        public static float EaseOutBack(float t) 
        {
            const float s = 1.70158f;
            return --t * t * ((s + 1) * t + s) + 1;
        }
        public static float EaseInOutBack(float t) 
        {
            const float s = 1.70158f * 1.525f;
            return t < 0.5 ? (t * t * ((s + 1) * t - s)) * 2 : ((t - 1) * (t - 1) * ((s + 1) * (t - 1) + s) + 1) * 2;
        }
        
        // Bounce
        public static float EaseInBounce(float t) => 1 - EaseOutBounce(1 - t);
        public static float EaseOutBounce(float t)
        {
            if (t < 1 / 2.75f) return 7.5625f * t * t;
            if (t < 2 / 2.75f) return 7.5625f * (t -= 1.5f / 2.75f) * t + 0.75f;
            if (t < 2.5 / 2.75) return 7.5625f * (t -= 2.25f / 2.75f) * t + 0.9375f;
            return 7.5625f * (t -= 2.625f / 2.75f) * t + 0.984375f;
        }
        public static float EaseInOutBounce(float t) => 
            t < 0.5 ? (1 - EaseOutBounce(1 - 2 * t)) / 2 : (1 + EaseOutBounce(2 * t - 1)) / 2;
    }
}