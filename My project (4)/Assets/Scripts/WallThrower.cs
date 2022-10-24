using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallThrower : MonoBehaviour
{
    public float wallSpeed = 20f;
    private Transform prefab;
    private Vector3 targetPos;
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.up;
        this.transform.Translate(moveDir * wallSpeed * Time.deltaTime);
    }
}