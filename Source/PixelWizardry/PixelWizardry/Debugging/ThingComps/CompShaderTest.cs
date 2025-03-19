using PixelWizardry.CompProps;
using RimWorld;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class CompShaderTest : ThingComp
    {
        public CompProperties_ShaderTest Props => (CompProperties_ShaderTest)props;
        private bool ShouldOscillateColors => ShouldOscillateColorsForLUTAsset();
        
        private Mote _mote;
        private bool _isLUTAsset;
        private Material _moteMaterial;
        private Vector4[] _baseColors;
        private Vector4[] _targetColors;
        private float _lerpDuration = 1f;
        
        private static readonly int LUTTexID = Shader.PropertyToID("_LUTTex");
        private static readonly int ColorsID = Shader.PropertyToID("_Colors");
        private static readonly int ColorCountID = Shader.PropertyToID("_ColorCount");
        private static readonly int BlendStrengthID = Shader.PropertyToID("_BlendStrength");
        
        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            InitializeMoteAndShaderProps();
            
            if (!_isLUTAsset) return;
            InitializeColors();
            TrySetupLUTShaderProps();
        }
        
        public override void CompTick()
        {
            base.CompTick();
            _mote.Maintain();
        }
        
        public override void PostDraw()
        {
            base.PostDraw();
            if (ShouldOscillateColors)
            {
                LerpColors();
            }
        }
        
        private void InitializeMoteAndShaderProps()
        {
            if (parent.Map == null) return;
            if (_mote == null || _mote.Destroyed)
            {
                _mote = MoteMaker.MakeAttachedOverlay(parent, Props.moteDef, Vector3.zero);
                _mote.instanceColor = Props.moteColor;
                
                if (_mote.Graphic != null &&
                    _mote.def.graphicData.shaderType == PWShaderTypeDefOf.PWCutout_LUT)
                {
                    _isLUTAsset = true;
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
            _targetColors =
            [
                Props.color5Alt, Props.color6Alt, Props.color1Alt, 
                Props.color2Alt, Props.color3Alt, Props.color4Alt
            ];
        }

        private bool ShouldOscillateColorsForLUTAsset()
        {
            return _isLUTAsset && Props.oscillateColors;
        }
        
        private void LerpColors()
        {
            float t = Mathf.PingPong(Time.time / _lerpDuration, 1f); // oscillate between 0 and 1

            for (int i = 0; i < _baseColors.Length; i++)
            {
                _baseColors[i] = Vector4.Lerp(Props.GetColor(i), _targetColors[i], t);
            }
            TryUpdateLUTShaderProps();
        }
        
        private void TrySetupLUTShaderProps()
        {
            if (_moteMaterial == null) return;
            _moteMaterial.SetFloat(BlendStrengthID, Props.blendStrength);
            _moteMaterial.SetTexture(LUTTexID, PWContentDatabase.Noise_092);
            _moteMaterial.SetInt(ColorCountID, _baseColors.Length - 1);
            _moteMaterial.SetVectorArray(ColorsID, _baseColors);
        }
        
        private void TryUpdateLUTShaderProps()
        {
            if (_moteMaterial == null) return;
            _moteMaterial.SetVectorArray(ColorsID, _baseColors);
        }
    }
}