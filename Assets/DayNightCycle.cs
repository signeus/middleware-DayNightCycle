using UnityEngine;

public class DayNightCycle : MonoBehaviour {
    [Header("Sun/Moon properties")]
    public float distanceSun = 0f;
    public float rotationSun = 90f;
    public float timeRotation = 5f;
    public bool realTime = false;

    private GameObject _sun;
    private GameObject _moon;

    void Start () {
		if(distanceSun == 0f)
        {
            distanceSun = 500f;
        }

        _sun = transform.GetChild(0).gameObject;
        _moon = transform.GetChild(1).gameObject;

        _sun.transform.position = new Vector3(0, distanceSun, 0);
        _moon.transform.position = new Vector3(0, distanceSun * -1, 0);

        _sun.transform.rotation = new Quaternion(rotationSun, 0, 0, _sun.transform.rotation.w);
        _moon.transform.rotation = new Quaternion(rotationSun * -1, 0, 0, _moon.transform.rotation.w);
    }
	
	void Update () {
        RotateElement(_sun);
        RotateElement(_moon);
    }

    private void RotateElement(GameObject element)
    {
        if (realTime)
        {
            element.transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime / timeRotation);
        }
        else
        {
            element.transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime * timeRotation);
        }
        element.transform.LookAt(Vector3.zero);
    }
}
