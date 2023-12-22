using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawningPool : MonoBehaviour
{
    [SerializeField] int _monsterCount = 0;
    [SerializeField] int _reserveMonsterCount = 0;
    [SerializeField] int _keepMonsterCount = 0;

    [SerializeField] Vector3 _spawnPos;
    [SerializeField] float _spawnRadius = 10.0f;
    [SerializeField] float _spawnTime = 5.0f;


    public void AddMonsterCount(int value) { _monsterCount += value; }
    public void SetKeepMonsterCount(int count) { _keepMonsterCount = count; }

    void Start()
    {
        Managers.Game.OnSpawnEvent -= AddMonsterCount;
        Managers.Game.OnSpawnEvent += AddMonsterCount;        
    }


    void Update()
    {
        while(_monsterCount + _reserveMonsterCount < _keepMonsterCount)
        {
            StartCoroutine(ReserveSpawn());
        }
    }

    IEnumerator ReserveSpawn()
    {
        _reserveMonsterCount++;
        yield return new WaitForSeconds(Random.Range(0,_spawnTime));

        GameObject obj = Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");
        NavMeshAgent nma = obj.GetComponent<NavMeshAgent>();
        _spawnPos = obj.transform.position;

        Vector3 randPos;
        while(true)
        {
            Vector3 randDir = Random.insideUnitSphere * Random.Range(0, _spawnRadius);
            randDir.y = 0;
            randPos = _spawnPos + randDir;

            // 이동가능한 위치인지 체크 ex) 벽끼임 등
            NavMeshPath path = new NavMeshPath();
            if (nma.CalculatePath(randPos, path)) { break; }
        }
        
        obj.transform.position = randPos;
        _reserveMonsterCount--;
    }
}
