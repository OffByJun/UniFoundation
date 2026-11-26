namespace UniFoundation.Scripts.UI.Panel.Type
{
    public enum ControlType
    {
        Modal, // 이 UI가 뜨면 다른 UI들의 조작을 차단함
        Overay, // 다른 UI위에 덮어지는 UI
        Tooltip, // 말그대로 툴팁
        Screen // 화면 전체에 적용되는 UI
    }
}