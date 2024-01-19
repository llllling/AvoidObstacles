/*
* 파일: StageData.cs
* 설명 
* : 현재 스테이지의 화면 내 범위
* : 에셋 데이터로 저장해두고 정보를 불러와서 사용
*/

using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [SerializeField]
    private Vector2 limitMin;

    [SerializeField] 
    private Vector2 limitMax;

    public void Deconstruct(out Vector2 Limitmin, out Vector2 Limitmax) {
        Limitmin = limitMin;
        Limitmax = limitMax;
    }
}

