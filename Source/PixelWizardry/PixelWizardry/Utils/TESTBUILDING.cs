using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class TESTBUILDING : Building
    {
        Camera camera;
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        Color newColor = new Color(1, 0, 0, 1);

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);

            Graphic.MatSingle.enableInstancing = true;
            if (Graphic.Shader == PWContentDatabase.TEST)
            {
                mpb.SetColor("_Color", newColor);
                Log.Message($"Color: {newColor}");
            }
            if (GenScene.InPlayScene)
            {
                camera = Find.Camera;
            }
        }

        public override void Draw()
        {
            //base.Draw();
            Matrix4x4[] matrices = new Matrix4x4[1];
            matrices[0] = Matrix4x4.TRS(Position.ToVector3Shifted(), Rotation.AsQuat, new Vector3(1, 1, 1));
            Graphics.DrawMeshInstanced(MeshPool.plane10, 0, Graphic.MatSingle, matrices, 1, mpb, UnityEngine.Rendering.ShadowCastingMode.Off, false, 0, camera);
        }
    }
}
