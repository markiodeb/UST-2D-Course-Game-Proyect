using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCuadro : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
    }
}
