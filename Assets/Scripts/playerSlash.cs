using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlash : attack
{
    [SerializeField] objectPooler slashPool;
    static int layerMask = 1 << 9;
    private void OnTriggerEnter2D(Collider2D col)
    {
        HPEntity HPScr = GetHPScr(col);
        if (HPScr.getEntityID() == 1) return;
        RaycastHit2D hit = Physics2D.Raycast(sourceTrfm.position, HPScr.GetPos()-sourceTrfm.position, 99, layerMask);
        for (int i = 0; i < 3; i++)
        {
            slashPool.Instantiate(hit.point, sourceTrfm.rotation);
        }
        _OnTriggerEnter2D(HPScr);
    }
}
