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

* 배경,플레이어, 장애물 모두 이동에 관해 비슷한 코드를 작성함 => <span style="background-color: skyblue; color: black;">이동에 관한 클래스를 만든 후 이동을 구현하는 스크립트들을 모두 이 클래스를 상속하도록 함.</span>

  - Movement2D class

  ```c#
    public class Movement2D : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private Vector2 moveDirection = Vector2.zero;

        public void Update()
        {
            Move();
        }

        public void Move()
        {
            transform.position = (Vector2)transform.position + moveSpeed * Time.deltaTime * moveDirection;
        }

        public void InitMovement(float initSpeed, Vector2 initDirection)
        {
            moveSpeed = initSpeed;
            moveDirection = initDirection;
        }

        public void MoveTo(Vector2 direction)
        {
            moveDirection = direction;
        }

        public void Speed(float speed)
        {
            moveSpeed = speed;
        }
    }

  ```

  - 배경 스크롤
    - 추가적으로 Update내에 구현할 로직이 없으므로 오버라이드 안함. => Movement2D의 Update가 호출됨.

  ```C#
  public class BackgroundScroll : Movement2D
  {
      void Reset()
      {
          Init(3f, Vector2.up);
      }
  }

  ```

  - 플레이어 움직임
    - PlayerMove클래스느 Update함수에서 수행하는 동작이 있어서 메소드를 오버라이드 => Movement2D Move() 함수를 호출해주어 움직이도록 구현

  ```c#
   class PlayerMove : Movement2D
  {
      ...

      new void Update()
      {
          Move();

          if (!IsStartPosition) { return; }
  #if UNITY_EDITOR || UNITY_STANDALONE
          if (Input.GetMouseButtonDown(0))
          {
              ToggleDirection();
          }

  #endif

  #if UNITY_ANDROID || UNITY_IOS
          if (Input.touchCount > 0)
          {
              Touch touch = Input.GetTouch(0);
              if (touch.phase == TouchPhase.Began)
              {
                  ToggleDirection();
              }
          }
  #endif

      }
      ...
  }
  ```
