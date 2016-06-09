using UnityEngine;
using System.Collections;

[System.Serializable]
public class AssetAnimation
{
    public Frame[] animationFrames;
    public bool loopable;
}
[System.Serializable]
public class Frame
{
    [System.Serializable]
    public struct bodyPart
    {
        public GameObject part;
        public float x, y;
        public float rotation;
        public bool flipX,flipY;
    };
    public bodyPart[] altered;

}

