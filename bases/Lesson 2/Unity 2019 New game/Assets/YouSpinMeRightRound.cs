using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouSpinMeRightRound : MonoBehaviour
{
    [SerializeField]
    private Transform YegorovTrans;
    // Start is called before the first frame update
    void Awake()
    {
        YegorovTrans = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        YegorovTrans.Rotate(new Vector3(5,0,0));
    }
}
