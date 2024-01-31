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
2. 코인은 무한 생성됨. 코인의 생성 간격은 랜덤. 1개의 코인당 점수 10
3. 캐릭터가 코인을 먹을 때 마다 점수 추가.
4. 플레이어는 마우스 왼쪽 버튼으로 왼쪽, 오른쪽 이동 가능(토글 형태)
5. 무적 아이템 획득 시 쿨타임 동안 장애물에 부딪혀도 죽지 않음.
6. 배경 스크롤 속도가 점점 증가함.

## 기술 스택

### 유니티 버전

Unity 2022.3.14f1

## 기능 개발 순서

1. 타일맵 생성 및 배경 스크롤
2. 플레이어 플레이어 생성 및 이동
3. 장애물/코인, 장애물/코인 생성기 만들기
4. 플레이어 , 장애물/코인 충돌 처리
5. 플레이어 플레이어 애니메이션(대기, 달리기, 사망) 생성
6. 점수 UI
7. 인트로 씬, 게임 오버 씬
    * TextMesh,Font 제작 및 Material 생성
    * 인트로 씬에 게임 플레이어 이미지 추가 및 점프하는 애니메이션 생성
8. 씬 전환 설정
9. 장애물, 코인 애니메이션 생성
    * 장애물 회전 애니메이션 : 플레이어가 아이템을 먹을 경우 무적 상태이므로 장애물이 날아갈 때 실행
    * 코인 회전 애니메이션
10. 무적 아이템(포션) 추가
    - 무적 아이템 오브젝트 및 생성기
    - 아이템 UI(쿨타임 표시)
    - 무적 아이템 UI 및 쿨타임 표시를 위해 포션이 점점 줄어드는 애니메이션 생성
    - 아이템, 플레이어 충돌 처리
    - 아이템 획득 시 플레이어/장애물 간 충돌 처리 추가
11. 게임 스크롤 속도 점점 빨라지도록
12. 코인, 아이템 획득 이펙트
13. BGM, 게임 효과음 추가


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

        void Update()
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

        // ...코드 생략
    }

  ```

  - 배경 스크롤
    - 추가적으로 Update내에 구현할 로직이 없으므로 오버라이드 안함. => Movement2D의 Update가 호출됨.

  ```C#
  public class BackgroundScroll : Movement2D
  {
      void Reset()
      {
          InitMovement(3f, Vector2.up);
      }
  }

  ```

  - 플레이어 움직임
    - PlayerMove클래스느 Update함수에서 수행하는 동작이 있어서 메소드를 오버라이드 => Movement2D Move() 함수를 호출해주어 움직이도록 구현

  ```c#
   class PlayerMove : Movement2D
  {
      //..코드생략

      void Update()
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
      //..코드생략
  }
  ```
  * 현재는 아이템이 하나 이지만 나중에 여러개일 경우를 고려하여 Item 추상 클래스를 생성하여 상속받아 사용하도록 구현
    * Item.cs
        * 공통 기능을 부모에서 구현 
            * 충돌 이벤트가 일어났을 때 Player인지 검사
            * 아이템 충돌 시 사라지도록
        * 아이템 별 기능은 자식 클래스가 구현하도록 Use 추상 메서드 선언 및 OnTriggerEnter2D()에서 Use() 호출
    ```c#
        public enum ItemType
        {
            Invincible
        }
        public abstract class Item : Movement2D
        {
            public abstract void Use();
            void OnTriggerEnter2D(Collider2D collision)
            {
                if (!collision.CompareTag("Player")) return;
                gameObject.SetActive(false);

                Use();
            }

        }

    ```
    * InvincibleItem.cs
    ```c#

    ```