using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Object_Controller : MonoBehaviour {

    

    public GameObject player; // 발사체가 회전 기준점을 잡을 플레이어
    private Vector3 pos; // 플레이어 포지션을 저장할 변수
    private bool rState; // 회전 상태
    private bool fState; // 발사 상태
    private float t;

    public GameObject warpE_Player;
    public GameObject warpE_Enemy;
    
    
    
    void Start () {
        rState = true;    // 시작시 바로 회전이 가능하게 회전 상태를 True
    }
	
	// Update is called once per frame
	void Update () {
        if (rState) // 회전상태가 True일 경우
        {
            pos = player.transform.position;
            transform.RotateAround(pos, Vector3.up, 100f * Time.deltaTime); // 플레이어 포지션을 기준으로 주위로 뺑뻉 돈다.
        }

        if (Input.GetKeyDown(KeyCode.Z)) // 발사 버튼을 눌렀을 때.
        {
            rState = false; // 회전을 멈추고
            fState = true; // 발사상태를 true한다.
            if (transform.parent != null) // 플레이어 하위오브젝트에 있을 때
            {
                transform.parent = transform.parent.parent;
                // 상위 오브젝트에서 벗어나 독립 오브젝트를 구성 (발사시 상위 오브젝트에 의해 강제적인 위치 변경을 당하지 않게 하기 위해. (transform.parent = null)
                // 다시 부모 오브젝트로 편입 시키려면 transform.parent = player.transform;
            }
         }

        if(!rState && fState) // 회전상태가 false이고 발사상태가 true이면 발사 합니다. 쓔쓔쓔슝슝ㅇ
        {
            t += Time.deltaTime;

            transform.Translate(Vector3.right * 10 * Time.deltaTime);
        }

     }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("부딪혔어");
        Transform ePos = collision.gameObject.GetComponent<Transform>();
        Transform pPos = player.transform;
        Vector3 temp;

        temp = pPos.position;
        pPos.position = ePos.position;
        ePos.position = temp;
        GameObject playerE = Instantiate(warpE_Player, pPos.position, warpE_Player.transform.rotation);
        GameObject enemyE = Instantiate(warpE_Enemy, ePos.position, warpE_Enemy.transform.rotation);

        Destroy(playerE, 1.5f);
        Destroy(enemyE, 1.5f);
        DestroyObject(this.gameObject);
    }
}
