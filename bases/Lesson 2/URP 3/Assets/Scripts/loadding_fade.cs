using System;
using UnityEngine;

public class loadding_fade : MonoBehaviour
{
    [SerializeField] private float time_out = 2f;
    private float cur_time;
    private CanvasGroup canv_group;

    private bool first_upd = true;

    private void Start()
    {
        canv_group = GetComponent<CanvasGroup>();
        if (canv_group == null) 
            canv_group = new CanvasGroup();
        cur_time = time_out;

    }

    void Update()
    {
        if (cur_time > 0)
        {
            cur_time = Math.Max(cur_time-Time.deltaTime, 0);
            canv_group.alpha = cur_time / time_out;
        }
    }
}
