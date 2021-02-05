using UnityEngine;
using UnityEngine.VFX;

public class explosion : MonoBehaviour
{

    public GameObject explosionObj;

    private VisualEffect exploseEffect;

    // Start is called before the first frame update
    void Start()
    {
        exploseEffect = explosionObj.GetComponent<VisualEffect>();
    }
}
