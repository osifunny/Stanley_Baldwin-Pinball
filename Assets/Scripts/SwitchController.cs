using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SwitchController : MonoBehaviour
{
    
    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;
    private Renderer render;
    private SwitchState state;
    public AudioManager audioManager;
    public GameObject switchObj;
    public ScoreManager scoreManager;
    public float score;

    private enum SwitchState{
        Off, On, Blink
    }

    private void Start(){
        render = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other){
        if (other == bola) Toggle();
    }

    private void Toggle(){
        scoreManager.AddScore(score);
        if (state == SwitchState.On) Set(false);
        else Set(true);
    }

    private void Set(bool active){
        if(active){
            state = SwitchState.On;
            render.material = onMaterial;
            audioManager.PlayON(switchObj.transform.position);
            StopAllCoroutines();
        }
        else{
            state = SwitchState.Off;
            render.material = offMaterial;
            audioManager.PlayOFF(switchObj.transform.position);
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private IEnumerator Blink(int times){
        state = SwitchState.Blink;
        for (int i = 0; i < times; i++){
            render.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            render.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }
        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time){
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
