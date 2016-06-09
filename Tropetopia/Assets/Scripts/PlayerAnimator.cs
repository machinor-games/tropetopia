using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

    [SerializeField]
    private GameObject bodyUpper, bodyLower, head, hair, shoulderLeft, shoulderRight, elbowLeft, elbowRight,
        hipLeft, hipRight, kneeLeft, kneeRight;
    
    public AssetAnimation idle, run, shoot;
    [SerializeField]
    private float animationSpeed = 1.0f;
    public IEnumerator Anim(AssetAnimation anim)
    {
        while (idle.loopable)
        {
            foreach (Frame frame in anim.animationFrames)
            {
                foreach (Frame.bodyPart bodyPart in frame.altered)
                {
                    Vector3 pos = new Vector3(bodyPart.x, bodyPart.y, 0);
                    bodyPart.part.transform.localPosition = pos;

                    Quaternion rot = Quaternion.Euler(new Vector3(0, 0, bodyPart.rotation));
                    bodyPart.part.transform.localRotation = rot;

                    //bodyPart.part.GetComponent<SpriteRenderer>().sortingOrder = bodyPart.orderLayer;

                    if (bodyPart.flipX)
                    {
                        bool flipper = bodyPart.part.GetComponent<SpriteRenderer>().flipY;
                        flipper = !flipper;
                        bodyPart.part.GetComponent<SpriteRenderer>().flipY = flipper;
                    }
                    if (bodyPart.flipY)
                    {
                        bool flipper = bodyPart.part.GetComponent<SpriteRenderer>().flipX;
                        flipper = !flipper;
                        bodyPart.part.GetComponent<SpriteRenderer>().flipX = flipper;
                    }
                }
                yield return new WaitForSeconds(0.2f);
            }
            yield return null;
        }
    }
}
