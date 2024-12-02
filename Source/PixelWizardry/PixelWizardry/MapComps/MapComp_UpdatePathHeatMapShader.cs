using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    /*public class MapComp_UpdatePathHeatMapShader : MapComponent
    {
        private ComputeShader _pathHeatMapShader;
        private ComputeBuffer _pawnBuffer;
        private RenderTexture _heatmapTexture;
        private Material _heatmapMaterial;
        private int _kernelIndex;

        public List<Vector2> pawnPositions = [];
        private static readonly int PawnPositions = Shader.PropertyToID("PawnPositions");
        private static readonly int HeatmapTexture = Shader.PropertyToID("HeatmapTexture");
        private static readonly int DeltaTime = Shader.PropertyToID("DeltaTime");
        private static readonly int FadeRate = Shader.PropertyToID("FadeRate");
        private static readonly int MapSize = Shader.PropertyToID("MapSize");

        private const float FadeRateValue = 0.5f;
        private const int HeatmapResolution = 512;

        public MapComp_UpdatePathHeatMapShader(Map map) : base(map)
        {
            _pathHeatMapShader = PWContentDatabase.PathHeatmap;
            
            if (_pathHeatMapShader == null) return;
            //_kernelIndex = _pathHeatMapShader.FindKernel("CSMain");
            
            //InitializeHeatmapTexture();
            //InitializeHeatmapMaterial();
        }

        // private void InitializeHeatmapTexture()
        // {
        //     _heatmapTexture = new RenderTexture(HeatmapResolution, HeatmapResolution, 0, RenderTextureFormat.ARGBFloat)
        //     {
        //         enableRandomWrite = true
        //     };
        //     _heatmapTexture.Create();
        // }

        // private void InitializeHeatmapMaterial()
        // {
        //     _heatmapMaterial = new Material(PWContentDatabase.HeatmapEffect);
        //     _heatmapMaterial.mainTexture = _heatmapTexture;
        // }
        
        public override void MapComponentTick()
        {
            base.MapComponentTick();

            if (_pathHeatMapShader == null /*|| _heatmapTexture == null#1#) return;

            // Update pawn positions
            pawnPositions = Find.CurrentMap.mapPawns.FreeColonists
                .Where(p => p.Spawned && p.Position.IsValid)
                .Select(p => new Vector2(p.DrawPos.x, p.DrawPos.z))
                .ToList();

            if (pawnPositions.Count == 0) return;

            // Update or create the ComputeBuffer
            if (_pawnBuffer == null || _pawnBuffer.count != pawnPositions.Count)
            {
                _pawnBuffer?.Dispose();
                _pawnBuffer = new ComputeBuffer(pawnPositions.Count, sizeof(float) * 2, ComputeBufferType.Default);
            }
            
            // Pass data to the compute shader
            //_pawnBuffer.SetData(pawnPositions);
            //_pathHeatMapShader.SetBuffer(_kernelIndex, PawnPositions, _pawnBuffer);

            // Update heatmap parameters
            // _pathHeatMapShader.SetTexture(_kernelIndex, HeatmapTexture, _heatmapTexture);
            // _pathHeatMapShader.SetFloat(DeltaTime, Time.deltaTime);
            // _pathHeatMapShader.SetFloat(FadeRate, FadeRateValue);
            // _pathHeatMapShader.SetFloats(MapSize, Find.CurrentMap.Size.x, Find.CurrentMap.Size.z);

            // Dispatch the compute shader
            // int threadGroupsX = Mathf.CeilToInt(HeatmapResolution / 8.0f);
            // int threadGroupsY = Mathf.CeilToInt(HeatmapResolution / 8.0f);
            // _pathHeatMapShader.Dispatch(_kernelIndex, threadGroupsX, threadGroupsY, 1);
        }

        // public override void MapComponentUpdate()
        // {
        //     base.MapComponentUpdate();
        //     //RenderHeatmap();
        // }
        
        // private void RenderHeatmap()
        // {
        //     if (_heatmapMaterial == null || _heatmapTexture == null) return;
        //
        //     // Render the heatmap using Graphics.Blit
        //     Graphics.Blit(null, _heatmapTexture, _heatmapMaterial);
        // }
        
        // public override void MapRemoved()
        // {
        //     base.MapRemoved();
        //     _pawnBuffer?.Dispose();
        //     _heatmapTexture?.Release();
        // }
    }*/
}