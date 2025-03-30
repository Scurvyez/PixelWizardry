using PixelWizardry.CompProps;
using PixelWizardry.MathUtils;
using RimWorld;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class CompShaderTest : ThingComp
    {
        public CompProperties_ShaderTest Props => (CompProperties_ShaderTest)props;
        private Mote _mote;
        private bool _isLUTAsset;
        private bool _isChromaticAberrationAsset;
        
        // LUT stuff
        private Material _moteMaterial;
        private Vector4[] _baseColors;
        
        // CA stuff
        private float _cAEffectStrength = 1f;
        private float _timeElapsed;
        private const float pulseDuration = 1f;
        
        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            InitializeMoteAndShaderProps();

            if (_isLUTAsset)
            {
                InitializeColors();
                TrySetupLUTShaderProps();
            }
        }
        
        public override void CompTick()
        {
            base.CompTick();
            _mote.Maintain();
            
            // if (_isChromaticAberrationAsset)
            // {
            //     UpdateEffectStrength();
            // }
        }

        public override void PostDraw()
        {
            base.PostDraw();
            if (_isChromaticAberrationAsset)
            {
                TryUpdateChromaticAberrationShaderProps();
            }
        }

        private void InitializeMoteAndShaderProps()
        {
            if (parent.Map == null) return;
            if (_mote == null || _mote.Destroyed)
            {
                _mote = MoteMaker.MakeAttachedOverlay(parent, Props.moteDef, Vector3.zero);
                _mote.instanceColor = Props.moteColor;
                
                if (_mote.Graphic == null) return;
                if (_mote.def.graphicData.shaderType == PWShaderTypeDefOf.PWCutout_LUT)
                {
                    _isLUTAsset = true;
                    _moteMaterial = _mote.Graphic.MatSingle;
                }
                else if (_mote.def.graphicData.shaderType == PWShaderTypeDefOf.PWBlendChromaticAberration)
                {
                    _isChromaticAberrationAsset = true;
                    _moteMaterial = _mote.Graphic.MatSingle;
                }
            }
        }
        
        private void InitializeColors()
        {
            _baseColors =
            [
                Props.color1, Props.color2, Props.color3, 
                Props.color4, Props.color5, Props.color6
            ];
        }
        
        private void TrySetupLUTShaderProps()
        {
            if (_moteMaterial == null) return;
            _moteMaterial.SetFloat(PWShaderPropertyIDs.BlendStrength_ID, Props.blendStrength);
            _moteMaterial.SetTexture(PWShaderPropertyIDs.LUTTex_ID, PWContentDatabase.Noise_092);
            _moteMaterial.SetInt(PWShaderPropertyIDs.ColorCount_ID, _baseColors.Length - 1);
            _moteMaterial.SetVectorArray(PWShaderPropertyIDs.Colors_ID, _baseColors);
        }
        
        private void UpdateEffectStrength()
        {
            _timeElapsed += Time.deltaTime;
            float t = (_timeElapsed % pulseDuration) / pulseDuration;
            float easedT = PWEasingFunctions.EaseInOutCubic(Mathf.Sin(t * Mathf.PI));
            _cAEffectStrength = Mathf.Clamp(easedT, 0f, 1f);
        }
        
        private void TryUpdateChromaticAberrationShaderProps()
        {
            if (_moteMaterial == null) return;
            _moteMaterial.SetFloat(PWShaderPropertyIDs.EffectStrength_ID, _cAEffectStrength);
        }
    }
}