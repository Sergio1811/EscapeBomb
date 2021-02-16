using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAlarm : MonoBehaviour
{
    IEnumerator Timer(float l_Timer)
    {
        yield return new WaitForSeconds(l_Timer);
        //do things
    }
}
