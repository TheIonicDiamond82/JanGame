using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSceneLine : MonoBehaviour {

    public Transform From;
    public Transform To;

    private void OnDrawGizmosSelected()
    {
        if (From != null && To != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(From.position, To.position);
            Gizmos.DrawSphere(From.position, 0.15f);
            Gizmos.DrawSphere(To.position, 0.15f);

        }
    }
}
