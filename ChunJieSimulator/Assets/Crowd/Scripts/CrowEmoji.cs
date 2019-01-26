using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowEmoji : MonoBehaviour
{
    public Sprite[] normalSprites;
    public Sprite[] hitSprites;
    public Sprite smileSprite;
    public Sprite GetNormalSprite() {
        return normalSprites[Random.Range(0, normalSprites.Length)];
    }
    public Sprite GetHitSprite(int hitTime) {
        if (hitTime < 4) {
            return hitSprites[0];
        }
        return hitSprites[1];
    }
}
