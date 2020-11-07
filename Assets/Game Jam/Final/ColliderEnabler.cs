using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnabler : MonoBehaviour
{
    public List<Collider> colliders;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);

        foreach (var collider in colliders)
        {
            collider.enabled = true;
        }
        
    }
}
