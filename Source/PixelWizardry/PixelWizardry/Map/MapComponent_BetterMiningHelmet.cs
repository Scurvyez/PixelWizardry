using UnityEngine;
using Verse;
using System.Collections.Generic;

namespace PixelWizardry
{
    [StaticConstructorOnStartup]
    public class MapComponent_BetterMiningHelmet : MapComponent
    {
        private static readonly Texture2D HeadLampTestingBase = ContentFinder<Texture2D>.Get("Map/Effects/HeadLampTestingBase");

        private List<Pawn> pawns;
        private Pawn targetPawn;

        private Material mapReactiveMat;
        private MaterialPropertyBlock propertyBlock;
        private float drawSizeFactor = 6f;

        public MapComponent_BetterMiningHelmet(Map map) : base(map)
        {

        }

        public override void FinalizeInit()
        {
            pawns = map.mapPawns.AllPawnsSpawned;

            if (targetPawn == null)
            {
                targetPawn = pawns.Find(pawn => pawn.IsColonistPlayerControlled);
            }

            mapReactiveMat = new Material(PWContentDatabase.LinearDodge);
            propertyBlock = new MaterialPropertyBlock();

            mapReactiveMat.SetTexture("_MainTex", HeadLampTestingBase);
        }

        public override void MapComponentTick()
        {
            base.MapComponentTick();
        }

        public override void MapComponentUpdate()
        {
            if (targetPawn != null)
            {
                Vector3 drawPosition = targetPawn.DrawPos;
                Rot4 drawRotation = targetPawn.Rotation;

                DrawMapEffect(mapReactiveMat, drawSizeFactor, drawPosition, drawRotation);
            }
        }
        
        public void DrawMapEffect(Material mat, float drawSizeFactor, Vector3 drawPos, Rot4 drawRot)
        {
            // Adjust drawPosition based on drawRotation
            switch (drawRot.AsInt)
            {
                case 0: // North
                    drawPos += new Vector3(0f, AltitudeLayer.VisEffects.AltitudeFor(), 3.5f);
                    break;
                case 1: // East
                    drawPos += new Vector3(3.5f, AltitudeLayer.VisEffects.AltitudeFor(), 0.5f);
                    break;
                case 2: // South
                    drawPos += new Vector3(0f, AltitudeLayer.VisEffects.AltitudeFor(), -3.2f);
                    break;
                case 3: // West
                    drawPos += new Vector3(-3.5f, AltitudeLayer.VisEffects.AltitudeFor(), 0.5f);
                    break;
            }

            Matrix4x4 matrix = Matrix4x4.TRS(drawPos, drawRot.AsQuat, new Vector3(drawSizeFactor, 1f, drawSizeFactor));
            Graphics.DrawMesh(MeshPool.plane10, matrix, mat, 0);
        }
    }
}
