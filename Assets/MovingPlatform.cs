using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    public float travel_distance = 3f;
    private Vector3 init_position;
    private Vector3 target;


    void Start()
    {
        init_position = transform.position;
        target = new Vector3(transform.position.x, transform.position.y, transform.position.z + travel_distance);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target){
            if (target != init_position){
                target = init_position;
            } else{
                target = new Vector3(init_position.x, init_position.y, init_position.z + travel_distance);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.parent = this.transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.transform.parent = null;
    }

}
