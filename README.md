# avoid obstacles

장애물 피하기 게임으로 카카오게임즈 스낵게임 흰 눈 사이로를 참고하여 만들었다.

## 목표

2D 장애물 피하기 게임을 제작함.

## 미션

장애물 사이를 피해서 코인을 많이 획득하라!

## 조작법

- 왼쪽 이동, 오른쪽 이동 : 마우스 왼쪽 버튼 토글
-     (사망 후) 게임 재시작 : 마우스 왼족 버튼

## 기능

1. 장애물은 무한 생성됨. 장애물의 생성 간격은 랜덤
2. 코인은 무한 생성됨. 코인의 생성 간격은 랜덤. 장애물 사이에 1개씩 일정 확률로 배치. 1개의 코인당 점수 10
3. 캐릭터가 코인을 먹을 때 마다 점수 추가.
4. 플레이어는 마우스 왼쪽 버튼으로 왼쪽, 오른쪽 이동 가능(토글 형태)
5. 무적 아이템 획득 시 쿨타임 동안 장애물에 부딪혀도 죽지 않음.

## 기술 스택

### 유니티 버전

Unity 2022.3.14f1

## 기능 개발 순서

1. 타일맵 생성 및 배경 스크롤
2. 플레이어 캐릭터 생성 및 이동
3. 장애물/코인, 장애물/코인 생성기 만들기
   - 코인은 회전하는 애니메이션까지
4. 캐릭터 , 장애물/코인 충돌 처리
5. 점수 UI
6. 인트로 씬, 게임 오버 씬
7. 씬 전환 설정
8. 플레이어 캐릭터 애니메이션(대기, 달리기, 사망)
9. 코인 획득 이펙트
10. BGM, 게임 효과음 추가
11. 무적 아이템 추가
    - 무적 아이템 오브젝트 및 생성기
    - 아이템 UI(쿨타임 표시)
    - 아이템 획득 이펙트
    - 아이템 획득 효과음

## 프로젝트하면서 고민한 점

- 플레이어 이동 시 Transform vs Rigidbody : 물리적 시뮬레이션(중력의 영향을 받는 등)이 필요하거나 다른 Rigidbody와의 상호작용이 아니고, 간단한 이동이나 위치 변환이므로 Transform을 사용

* 플레이어 조작 시 좌,우만 이동하는 데 **범위 내에서만 이동 가능하게** 구현 시 고려한 점

  1. 처음에 Mathf.Clamp()를 사용해서 x좌표를 제한하도록 코드를 작성하려고 했음.
  2. 그러나 게임을 처음 시작할 때 캐릭터가 최상단에서 중앙으로 이동하는 동작(y좌표 수정)이 한번 있음. 이때도 transform으로 이동을 구현해야 해서 <span style="background-color: skyblue; color: black;">이동이라는 같은 기능이므로 이동 함수를 따로 만듬</span>

  ```C#
    private void MovePosition(float speed, Vector2 direction)
  {
    transform.position = (Vector2)transform.position + speed * Time.deltaTime * direction;
  }
  ```

  3. 위 처럼 함수로 뺄 경우, X좌표에 Mathf.Clamp()를 사용해도 상관은 없지만(_어차피 게임 첫 시작 동작은 y만 움직이므로_) <span style="background-color: skyblue; color: black;">코드를 해석할 때 의미가 명확하지 않은 것 같아서</span> 사용 X
  4. IsMoveValidityCheck라는 프로퍼티를 생성해서 x좌표가 범위 내에 있어서 이동가능 한 상태인 지 체크

     - IsMoveValidityCheck 선언

       ```C#
        bool IsMoveValidityCheck
        {
            get
            {
                if (currentDirection == Vector2.left && transform.position.x <= minMoveRangeX
                    || currentDirection == Vector2.right && transform.position.x >= maxMoveRangeX)
                {
                    return false;
                }
                return true;
            }
        }

       ```

     - 이동 가능할 경우 MovePosition 호출

       ```C#
       if (IsMoveValidityCheck)
       {
           MovePosition(speedForXAxis, currentDirection);
       }
       ```
