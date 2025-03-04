﻿using System.Collections.Generic;
using System.Linq;

namespace BossMod.Endwalker.Savage.P5SProtoCarbuncle
{
    // this includes venom pools and raging claw/searing ray aoes
    class RubyGlow4 : RubyGlowRecolor
    {
        public override IEnumerable<AOEInstance> ActiveAOEs(BossModule module, int slot, Actor actor)
        {
            if (CurRecolorState != RecolorState.BeforeStones && MagicStones.Any())
                yield return new(ShapeHalf, module.Bounds.Center, Angle.FromDirection(QuadrantDir(AOEQuadrant)));
            foreach (var p in ActivePoisonAOEs(module))
                yield return p;

            if (module.PrimaryActor.CastInfo?.IsSpell(AID.RagingClaw) ?? false)
                yield return new(ShapeHalf, module.PrimaryActor.Position, module.PrimaryActor.CastInfo.Rotation, module.PrimaryActor.CastInfo.FinishAt);
            if (module.PrimaryActor.CastInfo?.IsSpell(AID.SearingRay) ?? false)
                yield return new(ShapeHalf, module.Bounds.Center, module.PrimaryActor.CastInfo.Rotation + 180.Degrees(), module.PrimaryActor.CastInfo.FinishAt);
        }
    }
}
