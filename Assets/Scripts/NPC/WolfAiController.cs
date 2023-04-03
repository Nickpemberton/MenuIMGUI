using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

namespace NPC
{
    [RequireComponent(typeof(NavMeshAgent))]

    public class WolfAiController : MonoBehaviour
    {
        public Transform[] waypoints;
        private NavMeshAgent _agent;
        private WaitForSeconds _delay = new WaitForSeconds(2);
        private Animator _animator;
        public Transform target;
        private int _currentPoint;
        [SerializeField] private float attackRadius;
        [SerializeField] private float timer;
        [SerializeField] private float maxTimer;
        [SerializeField] private bool inRange;
        [SerializeField] private float runSpeed;
        [SerializeField] private float walkSpeed;
        private bool _coroutineActive;
        private State _state;


        void Start()
        {
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
            //StartCoroutine(waypointscycle());
        }

        private void FixedUpdate()
        {
            float distTo = Vector3.Distance(transform.position, target.position);

            if (distTo <= attackRadius)
            {
                timer += Time.deltaTime;

                if (timer >= maxTimer)
                {
                    if (_coroutineActive)
                    {
                        StopCoroutine(Waypointscycle());
                        _coroutineActive = false;
                    }

                    inRange = true;
                    
                    _agent.speed = runSpeed;
                    transform.LookAt(target);


                    if (distTo <= 5f && _state != State.Idle)
                    {
                        _animator.SetBool("Walk", false);
                        _animator.SetBool("Idle", true);
                        _animator.SetBool("Run", false);
                        _state = State.Idle;
                    }
                    if (distTo <= 3.3f)
                    {
                        //_animator.SetBool("Idle", true);
                        //_animator.SetBool("Run", false);
                        _agent.destination = transform.position;
                        //Start attacking
                    }else if (distTo > 5f)
                    {
                        if (_state != State.Run)
                        {
                            _animator.SetBool("Walk", false);
                            _animator.SetBool("Idle", false);
                            _animator.SetBool("Run", true);
                            _state = State.Run;
                        }
                        Vector3 moveTo = Vector3.MoveTowards(transform.position, target.position, 100f);
                        _agent.destination = moveTo;
                    }

                }
            } else if (distTo > attackRadius)
            {
                _agent.speed = walkSpeed;
                _animator.SetBool("Run", false);
                inRange = false;
                timer = 0;
                if (!_coroutineActive)
                {
                    StartCoroutine(Waypointscycle());
                }
                //Path();
            }

        }
/*
        void Path()
        {
            if (!inRange && _agent.remainingDistance < 0.5f)
            {
                
                _animator.SetBool("Walk", true);
                _agent.destination = waypoints[_currentPoint].position;
                UpdateCurrentPoint();
                
                
            }

        }*/



        



        void UpdateCurrentPoint()
        {
            if (_currentPoint == waypoints.Length - 1)
            {
                _currentPoint = 0;
            }
            else
            {
                _currentPoint++;
            }
            
            
        }


        
        IEnumerator Waypointscycle()
        {
            _coroutineActive = true;
                yield return _delay;
                _agent.destination = waypoints[_currentPoint].position;
                UpdateCurrentPoint();
                _animator.SetBool("Idle", false);
                _animator.SetBool("Walk", true);
                yield return new WaitUntil(() => Vector3.Distance(_agent.destination, transform.position) < 2f);
                _animator.SetBool("Walk", false);
                _animator.SetBool("Idle", true);
                StartCoroutine(Waypointscycle());
        }
        
        
        
        private enum State
        {
            Idle,
            Walk,
            Run,
            Attack
        }
        }
    }
