using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    // Update is called once per frame
    public void UpdateHealthBar(float currValue,float maxValue)
    {
        slider.value = currValue / maxValue;
    }
    void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position+offset;
    }
}
