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
    [RequireComponent(typeof(Animator))]
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
        private bool _coroutineActive = false;
        [SerializeField] private State state;
        [SerializeField] private float attackTimer;
        private PlayerHandler _playerStats;
        [SerializeField] private float damageAmt;
        


        void Start()
        {
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
            _playerStats = target.GetComponent<PlayerHandler>();
        }

        void ChangeAnimatorState(State changeTo)
        {
            if (changeTo == State.Idle)
            {
                TurnOffCurrentState();
                _animator.SetBool("Idle", true);
                state = State.Idle;
                Debug.Log("Change State: Idle");
            } else if (changeTo == State.Run)
            {
                TurnOffCurrentState();
                _animator.SetBool("Run", true);
                state = State.Run;
                Debug.Log("Change State: Run");
            } else if (changeTo == State.Attack)
            {
                TurnOffCurrentState();
                _animator.SetBool("Attack", true);
                state = State.Attack;
                Debug.Log("Change State: Attack");
            } else if (changeTo == State.Walk)
            {
                TurnOffCurrentState();
                _animator.SetBool("Walk", true);
                state = State.Walk;
                Debug.Log("Change State: Walk");
            }
        }

        void TurnOffCurrentState()
        {
            if (state == State.Attack)
            {
                _animator.SetBool("Attack", false);
            } else if (state == State.Run)
            {
                _animator.SetBool("Run", false);
            } else if (state == State.Idle)
            {
                _animator.SetBool("Idle", false);
            } else if (state == State.Walk)
            {
                _animator.SetBool("Walk", false);
            }
        }


        public void BiteAttack()
        {
            
            attackTimer = 0;
            _playerStats.Damage(damageAmt);
            
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


                    if (distTo <= 3.3f)
                    {
                        _agent.destination = transform.position;
                        attackTimer += Time.deltaTime;

                        if ((state != State.Idle) && attackTimer < 2f)
                        {
                            ChangeAnimatorState(State.Idle);
                        }
                        if ((state != State.Attack) && attackTimer >= 1.4f)
                        {
                            ChangeAnimatorState(State.Attack);
                        }
                        
                        
                    }else if (distTo > 3.3f)
                    {
                        if (state != State.Run)
                        {
                            ChangeAnimatorState(State.Run);
                        }
                        
                        Vector3 moveTo = Vector3.MoveTowards(transform.position, target.position, 100f);
                        _agent.destination = moveTo;
                    }

                }
            } else if (distTo > attackRadius)
            {
                _agent.speed = walkSpeed;
                
                inRange = false;
                timer = 0;
                if (!_coroutineActive)
                {
                    _coroutineActive = true;
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
            while (_coroutineActive)
            {
                yield return _delay;
                _agent.destination = waypoints[_currentPoint].position;
                UpdateCurrentPoint();
                ChangeAnimatorState(State.Walk);
                Debug.Log("coroutine running");
                yield return new WaitUntil(() => Vector3.Distance(_agent.destination, transform.position) < 2f);
                ChangeAnimatorState(State.Idle);
            }

            
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
