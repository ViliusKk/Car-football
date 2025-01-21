using UnityEngine;

public class Boosting : MonoBehaviour
{
    public float boost = 100f;
    public float boostStrength = 15f;
    void Update()
    {
        if (boost < 0) boost = 0;
        else if (boost > 100f) boost = 100f;
    }
}
