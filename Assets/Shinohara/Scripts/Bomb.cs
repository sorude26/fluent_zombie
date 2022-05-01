using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField, Header("爆発の中心")] Vector3 _explosionCenter = default;
    [SerializeField, Header("爆発半径")] float _explosionRadius = 5f;
    [SerializeField, Header("起動までの時間")] float _explosionTime = 3f;
    [SerializeField, Header("飛ばす時にかける力")] float _forcePower = 10f;

    private void OnDrawGizmosSelected() //爆発範囲のギズモを表示する
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetCenter(), _explosionRadius);
    }

    /// <summary>爆発の中心を取得する</summary>
    /// <returns>爆発の中心</returns>
    Vector3 GetCenter()
    {
        Vector3 center = this.transform.position + this.transform.forward * _explosionCenter.z
           + this.transform.up * _explosionCenter.y
           + this.transform.right * _explosionCenter.x;
        return center;
    }

    /// <summary>一定時間後爆弾を起爆させ敵にダメージを与える </summary>
    private IEnumerator StartUp()
    {
        yield return new WaitForSeconds(_explosionTime);
        Debug.Log("起爆");
        var cols = Physics.OverlapSphere(GetCenter(), _explosionRadius);   //当たっているオブジェクトを全て取得するする
    
        foreach (var c in cols)
        {
            if (c.gameObject.tag == "Enemy")   //当たっているオブジェクト名がEnemyだったら削除する
            {
                Destroy(c.gameObject);
                ScoreManager.AddScore();
            }
        }

        Destroy(this.gameObject);
    }

    /// <summary>オブジェクトに力を加えて飛ばす 生成した時に呼んで欲しい </summary>
    /// <param name="playerForward">プレイヤーの向いている方向</param>
    public void AddForce(Vector3 playerForward)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(playerForward * _forcePower, ForceMode.Impulse);
        StartCoroutine(StartUp());
    }
}
