using System.Collections;
using UnityEngine;
namespace PPman
{
    public class Fadesystem : MonoBehaviour
    {
        /// <summary>
        /// �H�J�H�X
        /// </summary>
        /// <param name="group">�e���s�ճz����</param>
        /// <param name="�O�_�H�J">�O�_�H�J</param>
        /// <returns></returns>
        

        public static IEnumerator Fade(CanvasGroup group, bool �O�_�H�J = true)
        {
            //��"�W�[��"�ӱ���O�_�H�J�H�X �W��Ȭ�0.1
            float �W�[�� = �O�_�H�J ? +0.1f : -0.1f;

            //�ΰj�魫�ư���10��
            for (int i = 0; i < 10 ; i++)
            {
                //�z�����H�ɶ����W/����
                group.alpha += �W�[��;

                //���ܮɶ��]�w��0.03��
                yield return new WaitForSeconds(0.03f);

            }




        }
        
       

    }
}