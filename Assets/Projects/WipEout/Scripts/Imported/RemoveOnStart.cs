using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnStart : MonoBehaviour
{
    /* Description--
     *  This script will destroy a object after a set time
     */
    /* Notes--
     *  This script will be usefull
     */

    [SerializeField] private float destroyDelay = 0.0f;

	void Start()
    {
        if(destroyDelay == 0.0f) Destroy(this.gameObject);
	}

    void Update()
    {
        destroyDelay -= Time.deltaTime;
        if (destroyDelay <= 0.0f) Destroy(this.gameObject);
    }
}
