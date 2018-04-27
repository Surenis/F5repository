using UnityEngine;
using System.Collections;
 
public class respawn : MonoBehaviour {
    //value on the y axis of the "undermap"
    public float threshold;
    //position where the scripts tp
    public Vector3 initpos;

    private void Start()
    {
        //stores the tp value where the player starts.
        //TODO: Store this value when player hits a checkpoint
        initpos = transform.position;
    }

    void FixedUpdate ()
    {
        //if undermap=> tp
        if (transform.position.y < threshold - 5)
            transform.position = initpos;
    }
}