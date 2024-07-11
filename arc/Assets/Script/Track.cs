using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class Track : MonoBehaviour
{
    public ARTrackedImageManager manager;
    public List<GameObject> list1 = new List<GameObject>();
    private Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    void Start()
    {
        foreach (GameObject o in list1)
        {
            dict1.Add(o.name, o);
        }
    }

    void OnEnable()
    {
        manager.trackedImagesChanged += OnChanged;
    }

    private void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage t in eventArgs.added)
        {
            UpdateImage(t);
        }

        foreach (ARTrackedImage t in eventArgs.updated)
        {
            UpdateImage(t);
        }
    }

    void UpdateImage(ARTrackedImage t)
    {
        string name = t.referenceImage.name;

        GameObject o = dict1[name];
        o.transform.position = t.transform.position;
        //o.transform.rotation = t.transform.rotation;
        o.SetActive(true);
    }

    void Update()
    {
        
    }
}
