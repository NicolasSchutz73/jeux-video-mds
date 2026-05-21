using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Ce script gere le deplacement du joueur en 2D.
// Il lit l'entree (Input System) puis applique une vitesse au Rigidbody2D.
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Vitesse du joueur (visible dans l'Inspector, entre 1 et 20).
    [SerializeField, Range(1f, 20f)]
    private float _speed = 10f;
    
    // Reference au composant physique du joueur.
    private Rigidbody2D _rb;

    // Direction de mouvement recue depuis le clavier/manette (x, y).
    private Vector2 _movement;
    private Animator _animator;
    private bool _canMove;

    // Awake est appelee une seule fois au demarrage de l'objet.
    // On recupere ici le Rigidbody2D attache au meme GameObject.
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator =  GetComponent<Animator>();
    }

    public void SetCanMove(bool canMove)
    {
        _canMove = canMove;
        if (!canMove) _movement = Vector2.zero;
    }

    // Methode appelee par l'action "Move" du nouveau Input System.
    // On stocke juste la direction demandee.
    private void OnMove(InputValue value)
    {
        if (!_canMove) return;
        _movement = value.Get<Vector2>();
    }

    // FixedUpdate est utilise pour la physique (Rigidbody2D).
    // On applique la vitesse finale: direction * vitesse.
    private void FixedUpdate()
    {
        _rb.linearVelocity = _movement * _speed;
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Velocity", _movement.sqrMagnitude);
        
        if (_movement.sqrMagnitude > 0.01f) 
        {
            _animator.SetFloat("LastHorizontal", _movement.x);
            _animator.SetFloat("LastVertical", _movement.y);
        }
    }
}
