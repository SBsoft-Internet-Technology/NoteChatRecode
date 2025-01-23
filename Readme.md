# NoteChatRecode

NoteChatRecode ��һ������ .NET ������Ӧ�ó��򣬰����ͻ��˺ͷ������ˡ�

## ��Ŀ�ṹ

- **NoteChatRecode-Client**: UWP�ͻ�����Ŀ��Ŀ����Ϊ .NET 8
- **NoteChatRecode-Client-WinForm**: �ͻ��� WinForm ��Ŀ��Ŀ����Ϊ .NET 8�����ڲ���
- **NoteChatRecode-Server**: ����������Ŀ��Ŀ����Ϊ .NET 8
- **NoteChatRecode-Common**: ��Ŀ�Ĺ��ô��룬Ŀ����Ϊ .NET 8

## ���л���

### �ͻ���

- .NET Framework 4.7.2 �� .NET 8
- Visual Studio 2022

### ��������

- .NET 8
- Visual Studio 2022

## ����������

### �ͻ���

1. �� `NoteChatRecode-Client` �� `NoteChatRecode-Client-WinForm` ���������
2. ���ɽ��������
3. ���� `NoteChatRecode-Client` �� `NoteChatRecode-Client-WinForm` ��Ŀ��

### ��������

1. �� `NoteChatRecode-Server` ���������
2. ���ɽ��������
3. ���� `NoteChatRecode-Server` ��Ŀ��

## ��Ŀ�ļ�˵��

### NoteChatRecode-Client

- `Program.cs`: Ӧ�ó��������ڵ㣬��ʼ�������������� `MainForm`��

### NoteChatRecode-Client-WinForm

- `Form1.cs`: �������࣬����Ӧ�ó������Ҫ�߼���

### NoteChatRecode-Server

- `Program.cs`: Ӧ�ó��������ڵ㣬���� WebSocket ��������
- `WebSocketServer.cs`: ���� WebSocket �������Ļ�����Ϣ�͹��ܡ�
- `Event.cs`: ����������˵��¼�ϵͳ��
- `DataPacketManager.cs`: �������ݰ���ע��ͽ�����

### NoteChatRecode-Common

- `Core/User/User.cs`: �û������ࡣ
- `Core/Room/Room.cs`: �����������ࡣ
- `Datapacket/Datapackets/S01TextMessagePacket.cs`: �ı���Ϣ���ݰ��ࡣ

## ����

��ӭ���״��룡���ύ Pull Request �򱨸����⡣

## ���֤

����Ŀʹ�� MIT ���֤����������� [LICENSE](LICENSE) �ļ���
