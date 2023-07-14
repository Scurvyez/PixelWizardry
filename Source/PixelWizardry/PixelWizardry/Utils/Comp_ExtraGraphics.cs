using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;
using Verse.AI;
using UnityEngine;

namespace PixelWizardry
{
    public class Comp_ExtraGraphics : ThingComp
    {
        public CompProperties_ExtraGraphics Props => (CompProperties_ExtraGraphics)props;

        public override void PostDraw()
        {
            base.PostDraw();

            // if parentPawn exists, continue
            if (parent != null)
            {
                Rot4 rotation = parent.Rotation;
                Vector3 drawPos = parent.DrawPos;

                for (int i = 0; i < Props.graphics.Count; i++)
                {
                    Props.graphics[i].Graphic.Draw((drawPos + Props.graphics[i].drawOffset), rotation, parent);
                }
            }
        }
    }
}
