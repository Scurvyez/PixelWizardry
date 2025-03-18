using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class MapComp_TESTING : MapComponent
    {
        //public ComputeShader _testingShader;
        //public int _kernelIndex;
        
        public MapComp_TESTING(Map map) : base(map)
        {
            //_testingShader = PWContentDatabase.TESTING;
            
            //if (_testingShader == null) return;
            //PWLog.Message($"Testing Shader pass 1: {_testingShader != null}, Kernel: {_kernelIndex}");
            //_kernelIndex = _testingShader.FindKernel("CSMain");
            //PWLog.Message($"Testing Shader  pass 2: {_testingShader != null}, Kernel: {_kernelIndex}");
        }
    }
}