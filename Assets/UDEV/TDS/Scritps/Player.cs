using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Actor
{

    [Header("Player Setting: ")]
    [SerializeField] private float m_accelerationSpeed;
    [SerializeField] private float m_maxMousePosDistance;
    [SerializeField] private Vector2 m_velocityLimit;//gioi han vtoc

    private float m_curSpeed;
    private Actor m_enemyTargeted;
    private PlayerStats m_playerStats;


    [Header("Player Event:")]
    public UnityEvent OnAddXp;
    public UnityEvent OnLevelUp;
    public UnityEvent OnLostLife;
    public PlayerStats PlayerStats { get => m_playerStats; private set => m_playerStats = value; }

    public override void Init()
    {
        LoadStats();
    }

    private void LoadStats()
    {
        if (statData == null) return;

        m_playerStats=(PlayerStats)statData;//ep kieu (lam nhu vay chac la de goi phuong thuc j do trong PlayerStats(ở đây là ép kiểu statsData sang kiểu dl PlayerStats rồi gán cho m_playerStats,vậy nó mới dùng
                                            //dc phương thức Load()

        m_playerStats.Load();
        CurHp = m_playerStats.hp;

    }
    void Update()
    {
        Move();
    }
    protected override void Move()
    {
       if(IsDead)return;
       Vector2 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 movingDir=mousePos-(Vector2)transform.position;
        movingDir.Normalize();

        if (!m_isKnockback)//neu k bi day lui
        {
            if(Input.GetMouseButton(0))
            {
                Run(mousePos, movingDir);
            }
            else
            {
                BackToIdle();
            }
            return;
        }
        ChangeAnim(AnimConst.PLAYER_IDLE_ANIM);
    }

    private void BackToIdle()
    {
       m_curSpeed -=m_accelerationSpeed*Time.deltaTime;
       m_curSpeed=Mathf.Clamp(m_curSpeed,0,m_curSpeed);
       m_rb.velocity = Vector2.zero;
       ChangeAnim(AnimConst.PLAYER_IDLE_ANIM);
    }

    private void Run(Vector2 mousePos, Vector2 movingDir)
    {
        m_curSpeed += m_accelerationSpeed * Time.deltaTime;
        m_curSpeed=Mathf.Clamp(m_curSpeed,0,m_playerStats.moveSpeed);
        float delta=m_curSpeed*Time.deltaTime;
        float distanceToMousePos=Vector2.Distance(transform.position, mousePos);
        distanceToMousePos = Mathf.Clamp(distanceToMousePos, 0, m_maxMousePosDistance / 3);
        delta*=distanceToMousePos;
        m_rb.velocity=movingDir*delta;
        float velocityLimitX = Mathf.Clamp(m_rb.velocity.x, -m_velocityLimit.x, m_velocityLimit.y);
        float velocityLimitY = Mathf.Clamp(m_rb.velocity.y, -m_velocityLimit.y, m_velocityLimit.y);
        m_rb.velocity=new Vector2(velocityLimitX, velocityLimitY);
        ChangeAnim(AnimConst.PLAYER_RUN_ANIM);

    }
}
