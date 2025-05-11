using UnityEngine;

public class HajimeInit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GardenEntranceCounter.entranceCount <= 1)
        {
           transform.position = new Vector2(0.15f, -15f); //初期位置を指定
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
