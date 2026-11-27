# UniFoundation

----------------------------

게임을 만들때 기본적으로 쓰이는 부분들을 제작해뒀습니다.  
현재 지원 기능
- UI 프레임 워크 (Dotween 기반, 애니메이션+, Template Method 패턴)
- Event-Driven 프레임 워크


차후 지원 기능  
- UI VFX
- Data-Driven 프레임 워크



---
**도메인**
도메인은 이벤트 버스의 각 Bus들을 구분 짓는 요소로써
`EventHub.Instance.Get<TDomain>` 로 가져올 수 있습니다.
EventHub에 요청한 TDomain이 존재하지 않을 시 자동으로 생성됩니다.
