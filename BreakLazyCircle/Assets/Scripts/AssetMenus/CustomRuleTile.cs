using UnityEngine;
using System;

[Obsolete("This method is obsolete. Use unity self-contained Rule Tile instead.", true)]
[CreateAssetMenu(fileName = "Custom Rule Tile", menuName = "Tiles/Custom Rule Tile")]
public class CustomTilingRuleTile : RuleTile
{
    public override Matrix4x4 ApplyRandomTransform(TilingRuleOutput.Transform type, Matrix4x4 original, float perlinScale, Vector3Int position)
    {
        if (type == TilingRuleOutput.Transform.MirrorX)
        {
            perlinScale = 0.9f;
        }

        return base.ApplyRandomTransform(type, original, perlinScale, position);
    }
}
