using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    // Actor.cs 파일에서 상속받은 변수들과 메소드들을 사용할 수 있다.
    public string move()
    {
        return "플레이어는 움직입니다.";
    }
}
