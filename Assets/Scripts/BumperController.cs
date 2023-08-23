using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    private Renderer render;
    private Animator animator;
    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;
    public float score;

    private void Start(){
        render = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        render.material.color = color;
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.collider == bola){
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            animator.SetTrigger("Hit");
            audioManager.PlaySFX(collision.transform.position);
            vfxManager.PlayVFX(collision.transform.position);
            scoreManager.AddScore(score);
        }
    }
}
