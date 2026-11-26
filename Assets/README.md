# UniFoundation

----------------------------

게임을 만들때 기본적으로 쓰이는 부분들을 제작해뒀습니다.  
현재 지원 기능
- UI 프레임 워크 (Dotween 기반, 애니메이션+)
- Event-Driven 프레임 워크


차후 지원 기능  
- UI VFX
- Data-Driven 프레임 워크
- 

---
**이벤트 버스**  
모든 이벤트 버스는 BootStrap을 통하여 EventHub에 Register 되어야합니다.  
이벤트 버스는 `EventHub.Instance.Get<TDomain>` 로 가져올 수 있으며,  
EventHub에 요청한 TDomain이 존재하지 않을 시 자동으로 생성됩니다.


API 정리

| 이름 | 반환 형식           | 설명                                               | 위치              |
| --- |---------------------|----------------------------------------------------|-------------------|
| Get | `EventBus<TDomain>` | 이벤트 버스를 가져옵니다.                          | EventHub          |
| Subscribe | `void` | 이벤트 버스에 메소드를 등록합니다.                 | EventBus.EventBus |
| UnSubscribe | `void` | 이벤트 버스에서 메소드를 등록 해제합니다.          | EventBus.EventBus |
| Publish | `void` | 이벤트 버스에 메소드를 실행하라는 명령을 내립니다. | EventBus.Eventbus |
| Register | `void` | 리퀘스트 버스에 메소드를 등록합니다.               | EventBus.RequestBus |
| UnRegister | `void` | 리퀘스트 버스에서 메소드를 등록해제합니다. | EventBus.RequestBus |
| Request | `void` | 리퀘스트를 보냅니다. 반환값은 req에 존재합니다. | EventBus.RequestBus |
| 