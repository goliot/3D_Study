# 3D_Study
### 골드메탈 3D 기초 강좌 학습
https://www.youtube.com/watch?v=WkMM7Uu2AoA&list=PLO-mt5Iu5TeYkrBzWKuTCl6IUm_bA6BKy
---
# 0417
- 인게임 상점 구현
- 상점 UI 구현
---
# 0416
- UI 틀 배치
---
# 0415
- 보스 몬스터 구현
    - 보스 패턴 3가지
        - 유도 미사일
            - navMeshAgent 활용
        - 돌 굴리기
        - 점프 공격
    - 패턴은 스위치문으로 확률 조정
    - 보스는 플레이어가 바라보는 방향 살짝 앞쪽을 겨냥하도록 구현
```c#
float h = Input.GetAxisRaw("Horizontal");
float v = Input.GetAxisRaw("Vertical");
lookVec = new Vector3(h, 0, v) * 5f;
transform.LookAt(target.position + lookVec);
```
---
# 0413
- 적 3가지 구현
    - 근접
    - 돌진
    - 원거리
- 원거리 전용 미사일 구현
    - 파티클
    - 자체 회전
- 적의 플레이어 추적
    - NavMeshAgent 활용
---
# 0412
- 수류탄 구현
    - 폭발 모션, 날아갈 때 회전하면서 날아가기
- 수류탄 폭발 구현
    - 레이캐스트 활용
- 수류탄 피격 구현
    - 사망시 날아가기
---
# 0409
- 플레이어가 사격 후 계속 회전하던 버그 수정
    - angularVelocity를 0으로
- 벽을 통과하던 버그 수정
```c#
isBorder = Physics.Raycast(transform.position, transform.forward, 5, LayerMask.GetMask("Wall"));
//레이캐스트를 쏴서 벽 근처에 있으면 움직임을 제한
```
- 적 피격 구현
- 적 사망시 넉백 구현
---
# 0408
- 원거리 공격 구현
- 총알 움직임 구현
- 탄피 배출 구현
- 재장전 구현
- 발사시 마우스 포인터 위치에 따라 몸 회전하도록 구현
---
# 0407
- 근접 공격 구현
- 드랍 아이템 구현, 아이템 획득 구현
- 플레이어 현재 가진 아이템, 체력 구현
- 무기 장착, 교체 구현
---
# 0406
- 기본 맵 구현
- 플레이어 이동, 구르기, 점프 구현
