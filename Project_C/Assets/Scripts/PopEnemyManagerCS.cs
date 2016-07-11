using UnityEngine;
using System.Collections;
using System.Collections.Generic;   // List<>の使用
using UnityEngine.UI;


public class PopEnemyManagerCS : MonoBehaviour {

    public GameObject BossMasage;
    public GameObject Boss;
    public Slider moveSlider;                                   // 移動距離取得用
    public Transform[] popEnemyPos = new Transform[3];          // 出現位置取得用
    private float popIntervalTime;                              // 出現間隔管理用変数
    private Vector3 popPos;                                     // 出現位置
    private bool isBossStage;

    // データ読み込み用変数
    public int stageNum = 0;
    public EnemyPopDatabase enemyPopDatabase;
    private List<PopEnemyPercentage> popEnemyList = new List<PopEnemyPercentage>();
    private List<GameObject> enemyObjList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        popIntervalTime = 0;
        popPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        popPos.x += 2.0f;
        isBossStage = false;

        // オブジェクトデータ読み込み
        enemyObjList.AddRange(enemyPopDatabase.popEnemyDatabase[stageNum].popEnemyObj);

        // エネミー出現テーブル読み込み
        popEnemyList.AddRange(enemyPopDatabase.popEnemyDatabase[stageNum].popEnemyTable);
    }
	
	// Update is called once per frame
	void Update () {
        popIntervalTime += Time.deltaTime;
        if (isBossStage)
        {
            float posX = 20.0f;
            foreach (Transform child in transform)
            {
                if (posX > child.transform.position.x)
                {
                    posX = child.transform.position.x;
                }
            }
            if (posX > 0.0f)
            {
                // 出現メッセージ
                Instantiate(BossMasage);

                // ボス生成
                Instantiate(Boss);

                Destroy(this);
            }
            return;
        }
        // 2秒ごとに出現
        if (popIntervalTime > 2.0f) {
            popIntervalTime -= 2.0f;
            SummonEnemy();
        }
    }
    /// <summary>
    /// エネミー呼び出し
    /// </summary>
    void SummonEnemy() {

        // 出現位置決定
        int popSelect = Random.Range(0, popEnemyPos.Length);

        // 現在の進んだ距離の割合を取得
        float MovePercent = moveSlider.value * 100;

        // 進み切ったよ
        if (MovePercent >= 100)
        {
            // ボスステージ突入
            isBossStage = true;
            // 子オブジェクト取得
            foreach (Transform child in transform)
            {
                // 雑魚敵に撤退命令
                child.gameObject.GetComponent<EnemyFatRatCS>().StartReturn();
            }
            return;
        }

        // まだ呼び出すほど進んでない
        if (MovePercent < popEnemyList[0].MoveDistance)
            return;

        // どの表を使うか
        int Table;
        for (Table = 1; Table < popEnemyList.Count; Table++)
        {
            if (MovePercent < popEnemyList[Table].MoveDistance) {
                break;
            }
        }
        Table--;

        // 出現ロール(1D100)
        int popEnemyLate = Random.Range(0, 100);
        float selectEnemyLate = 0;
        int enemyCnt;
        for (enemyCnt = 0; enemyCnt < enemyObjList.Count; enemyCnt++) {
            selectEnemyLate += popEnemyList[Table].late[enemyCnt];
            if (popEnemyLate < selectEnemyLate) {
                break;
            }
        }

        // 範囲外検査
        if (enemyCnt >= enemyObjList.Count) {
            return;
        }

        // 生成
        GameObject obj =  (GameObject)Instantiate(enemyObjList[enemyCnt], new Vector3(popPos.x, popEnemyPos[popSelect].position.y, popEnemyPos[popSelect].position.z), transform.rotation);
        obj.transform.parent = this.transform;
    }

}
