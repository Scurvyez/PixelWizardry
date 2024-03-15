using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class TESTBUILDING : Building
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        public Vector4[] newColors;
        private float cachedDrawSize;

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);

            cachedDrawSize = def.graphicData.drawSize.x;
            newColors = new Vector4[15];
            Graphic.MatSingle.enableInstancing = true;
            if (Graphic.Shader == PWContentDatabase.TEST && newColors != null)
            {
                mpb.SetVectorArray("_Color", newColors);
                Log.Message($"Color: {newColors}");
            }
        }

        public override void Draw()
        {
            Matrix4x4[] matrices = new Matrix4x4[1];
            matrices[0] = Matrix4x4.TRS(Position.ToVector3Shifted(), Rotation.AsQuat, new Vector3(cachedDrawSize, 1, cachedDrawSize));
            Graphics.DrawMeshInstanced(MeshPool.plane10, 0, Graphic.MatSingle, matrices, 1, mpb, UnityEngine.Rendering.ShadowCastingMode.Off, false, 0);
        }
    }
}
