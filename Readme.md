# NoteChatRecode

NoteChatRecode 是一个基于 .NET 的聊天应用程序，包含客户端和服务器端。

## 项目结构

- **NoteChatRecode-Client**: UWP客户端项目，目标框架为 .NET 8
- **NoteChatRecode-Client-WinForm**: 客户端 WinForm 项目，目标框架为 .NET 8，用于测试
- **NoteChatRecode-Server**: 服务器端项目，目标框架为 .NET 8
- **NoteChatRecode-Common**: 项目的共用代码，目标框架为 .NET 8

## 运行环境

### 客户端

- .NET Framework 4.7.2 或 .NET 8
- Visual Studio 2022

### 服务器端

- .NET 8
- Visual Studio 2022

## 构建和运行

### 客户端

1. 打开 `NoteChatRecode-Client` 或 `NoteChatRecode-Client-WinForm` 解决方案。
2. 生成解决方案。
3. 运行 `NoteChatRecode-Client` 或 `NoteChatRecode-Client-WinForm` 项目。

### 服务器端

1. 打开 `NoteChatRecode-Server` 解决方案。
2. 生成解决方案。
3. 运行 `NoteChatRecode-Server` 项目。

## 项目文件说明

### NoteChatRecode-Client

- `Program.cs`: 应用程序的主入口点，初始化并运行主窗体 `MainForm`。

### NoteChatRecode-Client-WinForm

- `Form1.cs`: 主窗体类，包含应用程序的主要逻辑。

### NoteChatRecode-Server

- `Program.cs`: 应用程序的主入口点，启动 WebSocket 服务器。
- `WebSocketServer.cs`: 定义 WebSocket 服务器的基本信息和功能。
- `Event.cs`: 定义服务器端的事件系统。
- `DataPacketManager.cs`: 管理数据包的注册和解析。

### NoteChatRecode-Common

- `Core/User/User.cs`: 用户数据类。
- `Core/Room/Room.cs`: 聊天室数据类。
- `Datapacket/Datapackets/S01TextMessagePacket.cs`: 文本消息数据包类。

## 贡献

欢迎贡献代码！请提交 Pull Request 或报告问题。

## 许可证

此项目使用 MIT 许可证。详情请参阅 [LICENSE](LICENSE) 文件。
