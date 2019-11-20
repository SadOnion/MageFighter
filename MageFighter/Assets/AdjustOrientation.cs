using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustOrientation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 0) transform.localScale = new Vector3(-1, 1, 1);
    }

}
