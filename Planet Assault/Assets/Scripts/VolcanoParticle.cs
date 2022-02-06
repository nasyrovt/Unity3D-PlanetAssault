using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoParticle : MonoBehaviour
{
    [SerializeField] float bottomRange = 20;
    [SerializeField] float upperRange = 25;
    Rigidbody myRb;
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        float randomX = UnityEngine.Random.Range(-upperRange, upperRange);
        float randomY = UnityEngine.Random.Range(bottomRange, upperRange);
        float randomZ = UnityEngine.Random.Range(-upperRange, upperRange);
        myRb.velocity = new Vector3(randomX, randomY, randomZ);
        StartCoroutine("DestroyAfterSeconds");
    }

    private void OnCollisionEnter(Collision other)
    {
        string otherTag = other.gameObject.tag;
        if ((otherTag != "Volcano") && (otherTag != "PlayGround"))
            Destroy(gameObject);
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(10);

        Destroy(gameObject);

    }
}
