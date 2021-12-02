using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private Character character;
    void Start()
    {
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", character.GetVelocity());
    }
}
