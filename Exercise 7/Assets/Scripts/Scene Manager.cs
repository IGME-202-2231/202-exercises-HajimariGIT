using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<PhysicsObject> objects;
    Vector3 store = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        store = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        store.z = 0;

        objects[0].Apply(store);
    }
}
