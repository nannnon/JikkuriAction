using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject _followTarget;

    // Start is called before the first frame update
    void Start()
    {
    }

    void LateUpdate()
    {
        const int FreeAreaWidth = 7;
        const int FreeAreaHeight = 5;

        float diffX = _followTarget.transform.position.x - transform.position.x;
        float diffY = _followTarget.transform.position.y - transform.position.y;

        if (diffX < -FreeAreaWidth / 2f)
        {
            transform.position += new Vector3(diffX + FreeAreaWidth / 2f, 0, 0);
        }
        if (FreeAreaWidth / 2f < diffX)
        {
            transform.position += new Vector3(diffX - FreeAreaWidth / 2f, 0, 0);
        }
        if (diffY < -FreeAreaHeight / 2f)
        {
            transform.position += new Vector3(0, diffY + FreeAreaHeight / 2f, 0);
        }
        if (FreeAreaHeight / 2f < diffY)
        {
            transform.position += new Vector3(0, diffY - FreeAreaHeight / 2f, 0);
        }
    }
}
