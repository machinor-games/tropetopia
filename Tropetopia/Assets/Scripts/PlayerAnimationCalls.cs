using UnityEngine;
using System.Collections;

public class PlayerAnimationCalls : MonoBehaviour
{
    bool idle = false, run = false, jump = false, crouch = false;

    public void OnIdle(){ idle = true; run = false; jump = false; crouch = false;}

    public void OnRun() { idle = false; run = true; jump = false; crouch = false; }

    public void OnJump() { idle = false; run = false; jump = true; crouch = false; }

    public void OnCrouch() { idle = false; run = false; jump = false; crouch = true; }
}
