using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private ScoreController scoreController;
    public GameObject explosion;

    private void Start()
    {
        scoreController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.tag == "Spider")
        {
            scoreController.Score++;
        }

        GameObject createdExplosion = Instantiate(explosion, transform.position, transform.rotation);
        createdExplosion.transform.localScale = transform.localScale;

        Destroy(gameObject);
        Destroy(createdExplosion, 2f);
    }
}
