﻿## 基于C#的Winform组件，开发的BMP图片隐写软件

由**DeepSeek**辅助开发

采用LSB隐写术，未做加密，仅供娱乐使用

隐写内容由20字节头内容，和文件内容组成；头内容的前4字节储存文件长度，接下来8字节为校验码：**SDSC0623**，最后8字节为后缀名

软件随意制作，代码未做优化，可能有Bug

*2025.02.23* 更新：修复了最大容量判断错误的BUG
