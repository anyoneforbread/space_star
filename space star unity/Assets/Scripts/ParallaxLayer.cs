using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;

    public void Move(float delta)
    {
        UnityEngine.Vector3 newPos = transform.localPosition;
        newPos.y -= delta * parallaxFactor;

        transform.localPosition = newPos;
    }

}

