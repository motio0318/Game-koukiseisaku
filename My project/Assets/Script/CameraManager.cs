using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //Player��������E�Ɉړ��F�J�������E��
    //Player���E���獶�Ɉړ��F�J����������

    [SerializeField] Camera cam;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.transform.position.x > transform.position.x)
            {
                //�J�������E�Ɉړ�
                cam.transform.position = new Vector3(18, 0, -10);
            }
            else
            {
                //�J���������Ɉړ�
                cam.transform.position = new Vector3(0, 0, -10);
            }
        }
    }
}
