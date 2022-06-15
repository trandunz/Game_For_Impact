using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_TaskOrientShip : MonoBehaviour
{
    [SerializeField] Image ship;
    [SerializeField] Image destination;
    [SerializeField] Image SliderHandle;
    Vector3 ShipStartPos;

    private void Start()
    {
        
        ShipStartPos = ship.transform.position;
    }
    private void OnEnable()
    {
        destination.transform.position = new Vector3(destination.transform.position.x + Random.Range(-100, 100), destination.transform.position.y, destination.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        ship.transform.position = new Vector3(SliderHandle.transform.position.x, ship.transform.position.y, ship.transform.position.z);
        if (ship.transform.position.x <= destination.transform.position.x + 10
            && ship.transform.position.x >= destination.transform.position.x - 10)
        {
            GetComponent<Script_BaseTaskPanel>().CloseTask(true);
        }
    }
}
